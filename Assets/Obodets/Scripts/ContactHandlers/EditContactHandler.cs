using Obodets.Scripts.Databases;

namespace Obodets.Scripts.ContactHandlers
{
    public sealed class EditContactHandler : ContactHandler
    {
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
        
        private void SetFieldValues(Contact contact)
        {
            nameField.text = contact.Name;
            surnameField.text = contact.Surname;
            phoneField.text = contact.Phone;
        }
    }
}