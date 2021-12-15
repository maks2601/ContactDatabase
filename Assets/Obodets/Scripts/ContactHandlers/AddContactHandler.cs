using Obodets.Scripts.Databases;

namespace Obodets.Scripts.ContactHandlers
{
    public sealed class AddContactHandler : ContactHandler
    {
        protected override void Awake()
        {
            base.Awake();
            
            MakeInteractable(true);
        }
        
        public void AddContact()
        {
            var contact = CreateContact();
            if(contact == null) return;
        
            DatabaseControl.Instance.AddContact(contact);
        
            CloseMenu();
        }
    }
}
