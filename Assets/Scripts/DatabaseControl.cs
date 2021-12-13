using System;
using System.IO;
using SQLite;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseControl : MonoBehaviour
{
	[SerializeField] private string databaseName;

	[Header("Add contact")] 
	[SerializeField] private TMP_InputField nameField;
	[SerializeField] private TMP_InputField surnameField;
	[SerializeField] private TMP_InputField phoneField;
	
	[Header("Get contact")] 
	[SerializeField] private TMP_InputField idField;
	
	private SQLiteConnection db;
	
	private void Awake()
	{
		SetupDatabase();
	}

	private void SetupDatabase()
	{
		var databasePath = Application.dataPath + '/' + databaseName;
		Debug.Log(databasePath);
		
		db = new SQLiteConnection(databasePath);

		db.CreateTable<Contact>();
	}

	public void AddContact()
	{
		AddContact(db, nameField.text, surnameField.text, phoneField.text);
	}

	public void GetContact()
	{
		var contacts = GetContact(db, int.Parse(idField.text));
		
		Debug.Log(contacts[0].Name);
	}

	private Contact[] GetContact(SQLiteConnection c, int id)
    {
    	var q = from f in c.Table<Contact>()
    				where f.Id == id
    				select f;
    	return q.ToArray();
    }
    
	private void AddContact(SQLiteConnection c, string name, string surname, string phone)
    {
	    var fav = new Contact() 
	    {
		    Name = name,
		    Surname = surname,
		    Phone = phone
	    };
	    c.Insert(fav);
    }
}
