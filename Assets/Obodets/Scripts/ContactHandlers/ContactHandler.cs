using Obodets.Scripts.Animations;
using Obodets.Scripts.Databases;
using TMPro;
using UnityEngine;

namespace Obodets.Scripts.ContactHandlers
{
    public class ContactHandler : MonoBehaviour
    {
        [SerializeField] protected TMP_InputField nameField;
        [SerializeField] protected TextMeshProUGUI nameErrorText;
    
        [SerializeField] protected TMP_InputField surnameField;
        [SerializeField] protected TextMeshProUGUI surnameErrorText;
    
        [SerializeField] protected TMP_InputField phoneField;
        [SerializeField] protected TextMeshProUGUI phoneErrorText;

        private const float HideTime = 0.4f;
        
        private Vector3 _startPosition;

        protected virtual void Awake()
        {
            SetupFields();

            _startPosition = transform.position;
            
            transform.Hide(0);
        }

        private void SetupFields()
        {
            nameField.onValueChanged.AddListener(delegate
            {
                HideError(nameErrorText);
            });
            surnameField.onValueChanged.AddListener(delegate
            {
                HideError(surnameErrorText);
            });
            phoneField.onValueChanged.AddListener(delegate
            {
                HideError(phoneErrorText);
            });
            HideError(nameErrorText);
            HideError(surnameErrorText);
            HideError(phoneErrorText);
        }

        private void HideError(TextMeshProUGUI errorText)
        {
            errorText.text = default;
        }

        public virtual void CloseMenu()
        {
            ClearFields();
            transform.Hide(HideTime);
        }

        public void ShowMenu()
        {
            transform.FloatingTo(_startPosition.x);
        }

        protected void MakeInteractable(bool isInteractable)
        {
            nameField.interactable = isInteractable;
            surnameField.interactable = isInteractable;
            phoneField.interactable = isInteractable;
        }

        protected Contact CreateContact()
        {
            if (FillErrorHandler.NameErrorChecking(nameField.text, nameErrorText)) return null;
            if (FillErrorHandler.NameErrorChecking(surnameField.text, surnameErrorText)) return null;
            if (FillErrorHandler.PhoneErrorChecking(phoneField.text, phoneErrorText)) return null;
            
            var contact = new Contact() 
            {
                Name = nameField.text,
                Surname = surnameField.text,
                Phone = phoneField.text
            };

            return contact;
        }

        private void ClearFields()
        {
            nameField.text = default;
            surnameField.text = default;
            phoneField.text = default;
        }
    }
}