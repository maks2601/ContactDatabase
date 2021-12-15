using System;
using TMPro;
using UnityEngine;

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
        
        addContactMenu.transform.Hide(0);
    }

    public void OpenAddContactMenu()
    {
        addContactMenu.ShowMenu();
    }
}