using System;
using TMPro;
using UnityEngine;

public class ContactPageUI : MonoBehaviour
{
    [SerializeField] private GameObject addContactMenu;

    [SerializeField] private TMP_InputField searchField;

    private void Start()
    {
        searchField.onValueChanged.AddListener(delegate
        {
            DatabaseControl.Instance.FindContactsByName(searchField.text);
        });
    }

    public void OpenAddContactMenu()
    {
        addContactMenu.SetActive(true);
    }
}