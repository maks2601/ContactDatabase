using Obodets.Scripts.ContactHandlers;
using Obodets.Scripts.Databases;
using UnityEngine;

namespace Obodets.Scripts.ContactUIs
{
    public class ContactsListControl : MonoBehaviour
    {
        [SerializeField] private Transform content;
    
        [SerializeField] private ContactUI contactPrefab;

        [SerializeField] private EditContactHandler editContactHandler;
        
        private const int ElementSize = 200;

        private void Start()
        {
            DatabaseControl.Instance.OnContactsUpdated += ShowContacts;
        }

        private void ShowContacts(Contact[] contacts)
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }

            ScaleContent(contacts.Length);

            foreach (var contact in contacts)
            {
                var contactUI = Instantiate(contactPrefab, content);
                contactUI.Initialize(contact.Name, contact.Surname, delegate
                {
                    editContactHandler.ContactId = contact.Id;
                    editContactHandler.ShowMenu();
                });
            }
        }

        private void ScaleContent(int elementsCount)
        {
            var rt = content.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, ElementSize * elementsCount);
        }
    }
}
