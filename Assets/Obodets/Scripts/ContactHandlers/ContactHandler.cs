using Obodets.Scripts.Animations;
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

        private void Awake()
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

        public void CloseMenu()
        {
            transform.Hide(HideTime);
        }

        public void ShowMenu()
        {
            transform.FloatingTo(_startPosition.x);
        }
    }
}