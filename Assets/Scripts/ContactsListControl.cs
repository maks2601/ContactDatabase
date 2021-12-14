using System;
using UnityEngine;

public class ContactsListControl : MonoBehaviour
{
    [SerializeField] private Transform content;
    
    [SerializeField] private ContactUI contactPrefab;

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
            contactUI.Initialize(contact.Name, contact.Surname);
        }
    }

    private void ScaleContent(int elementsCount)
    {
        var rt = content.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, ElementSize * elementsCount);
    }
}
