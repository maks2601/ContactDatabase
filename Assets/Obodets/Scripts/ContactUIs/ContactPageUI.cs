using Obodets.Scripts.ContactHandlers;
using Obodets.Scripts.Databases;
using TMPro;
using UnityEngine;

namespace Obodets.Scripts.ContactUIs
{
    public class ContactPageUI : MonoBehaviour
    {
        [SerializeField] private AddContactHandler addContactMenu;

        [SerializeField] private TMP_InputField searchField;

        private void Start()
        {
            searchField.onValueChanged.AddListener(delegate
            {
                DatabaseControl.Instance.ContactSearchRequest(searchField.text);
            });
        }

        public void OpenAddContactMenu()
        {
            addContactMenu.ShowMenu();
        }
    }
}