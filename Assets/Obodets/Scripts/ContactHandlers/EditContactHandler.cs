using Obodets.Scripts.Databases;
using UnityEngine;

namespace Obodets.Scripts.ContactHandlers
{
    public sealed class EditContactHandler : ContactHandler
    {
        [SerializeField] private GameObject submitEditing;
        
        private bool isEditing;

        private int contactId;

        public int ContactId
        {
            get => contactId;
            set
            {
                contactId = value;
                var contact = DatabaseControl.Instance.GetContactById(value);
                SetFieldValues(contact);
            }
        }
        
        protected override void Awake()
        {
            base.Awake();
            
            EnableEditing(false);
        }
        
        private void SetFieldValues(Contact contact)
        {
            nameField.text = contact.Name;
            surnameField.text = contact.Surname;
            phoneField.text = contact.Phone;
        }

        public void DeleteContact()
        {
            DatabaseControl.Instance.DeleteContactById(ContactId);
            CloseMenu();
        }

        public void EnableEditing()
        {
            isEditing = !isEditing;
            MakeInteractable(isEditing);
            submitEditing.SetActive(isEditing);
        }
        
        private void EnableEditing(bool active)
        {
            isEditing = active;
            MakeInteractable(active);
            submitEditing.SetActive(active);
        }

        public override void CloseMenu()
        {
            base.CloseMenu();

            EnableEditing(false);
        }

        public void SubmitEditing()
        {
            var contact = CreateContact();
            if(contact == null) return;

            contact.Id = ContactId;
            DatabaseControl.Instance.UpdateContact(contact);
            
            CloseMenu();
        }
    }
}