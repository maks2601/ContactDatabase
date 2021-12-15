using Obodets.Scripts.Animations;
using Obodets.Scripts.Databases;
using TMPro;
using UnityEngine;

namespace Obodets.Scripts
{
    public class AddContactHandler : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameField;
        [SerializeField] private TextMeshProUGUI nameErrorText;
    
        [SerializeField] private TMP_InputField surnameField;
        [SerializeField] private TextMeshProUGUI surnameErrorText;
    
        [SerializeField] private TMP_InputField phoneField;
        [SerializeField] private TextMeshProUGUI phoneErrorText;

        private Vector3 _startPosition;

        private void Awake()
        {
            SetupFields();

            _startPosition = transform.position;
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

        public void AddContact()
        {
            if (FillErrorHandler.NameErrorChecking(nameField.text, nameErrorText)) return;
            if (FillErrorHandler.NameErrorChecking(surnameField.text, surnameErrorText)) return;
            if (FillErrorHandler.PhoneErrorChecking(phoneField.text, phoneErrorText)) return;
        
            DatabaseControl.Instance.AddContact(nameField.text, surnameField.text, phoneField.text);
        
            CloseMenu();
        }

        private void HideError(TextMeshProUGUI errorText)
        {
            errorText.text = default;
        }

        public void CloseMenu()
        {
            transform.Hide(0.25f);
        }

        public void ShowMenu()
        {
            transform.FloatingTo(_startPosition.x);
        }
    }
}
