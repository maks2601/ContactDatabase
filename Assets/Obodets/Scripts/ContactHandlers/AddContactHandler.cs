using Obodets.Scripts.Databases;

namespace Obodets.Scripts.ContactHandlers
{
    public sealed class AddContactHandler : ContactHandler
    {
        public void AddContact()
        {
            if (FillErrorHandler.NameErrorChecking(nameField.text, nameErrorText)) return;
            if (FillErrorHandler.NameErrorChecking(surnameField.text, surnameErrorText)) return;
            if (FillErrorHandler.PhoneErrorChecking(phoneField.text, phoneErrorText)) return;
        
            DatabaseControl.Instance.AddContact(nameField.text, surnameField.text, phoneField.text);
        
            CloseMenu();
        }
    }
}
