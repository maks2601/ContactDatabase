using SQLite;
using TMPro;
using System;
using UnityEngine;

public class DatabaseControl : MonoBehaviour
{
	public static DatabaseControl Instance;
	
	public event Action<Contact[]> OnContactsUpdated;
	
	[SerializeField] private string databaseName;

	private SQLiteConnection _db;
	
	private void Awake()
	{
		if (Instance == null) Instance = this;
		else Destroy(this);
		
		SetupDatabase();
	}

	private void Start()
	{
		UpdateContacts(this, null);
	}

	private void SetupDatabase()
	{
		var databasePath = Application.dataPath + '/' + databaseName;

		_db = new SQLiteConnection(databasePath);
		_db.CreateTable<Contact>();
		_db.TableChanged += UpdateContacts;
	}

	public void FindContactsByName(string name)
    {
	    var contacts = _db.Query<Contact> ("select * from Contact where Name like '" + name + "%'");
    	
        OnContactsUpdated?.Invoke(contacts.ToArray());
    }

	private Contact[] GetAllContacts()
	{
		var contacts = _db.Query<Contact> ("select * from Contact");
		return contacts.ToArray();
	}
    
	public void AddContact(string name, string surname, string phone)
    {
	    var fav = new Contact() 
	    {
		    Name = name,
		    Surname = surname,
		    Phone = phone
	    };
	    
	    _db.Insert(fav);
    }

	private void UpdateContacts(object sender, NotifyTableChangedEventArgs e)
	{
		var contacts = GetAllContacts();
		OnContactsUpdated?.Invoke(contacts);
	}
}
