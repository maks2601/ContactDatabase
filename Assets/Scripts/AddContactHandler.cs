using TMPro;
using UnityEngine;

public class AddContactHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField surnameField;
    [SerializeField] private TMP_InputField phoneField;
    
    public void AddContact()
    {
        DatabaseControl.Instance.AddContact(nameField.text, surnameField.text, phoneField.text);
        
        CloseMenu();
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
