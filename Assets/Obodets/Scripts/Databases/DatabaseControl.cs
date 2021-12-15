using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using UnityEngine;

namespace Obodets.Scripts.Databases
{
	public sealed class DatabaseControl : MonoBehaviour
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
#if UNITY_ANRDOID
			var openPath = "jar:file://" + Application.dataPath + "!/assets/" + databaseName;
			var www = new WWW(openPath);
			while(!www.isDone) {}
			File.WriteAllBytes(databasePath, www.bytes);
#else
			var openPath = Application.dataPath + "/StreamingAssets/" + databaseName;
			File.Copy(openPath, databasePath);
#endif
			_db = new SQLiteConnection(databasePath);
			_db.CreateTable<Contact>();
			_db.TableChanged += UpdateContacts;
		}

		public void ContactSearchRequest(string request)
		{
			var requests = request.Split(' ');
			var contacts = new List<Contact>();

			if (requests.Length == 1)
			{
				contacts = _db.Query<Contact>("select * from Contact where Name like '" + requests[0] +
				                              "%' union select * from Contact where Surname like '" + requests[0] + "%'");
			}
			else if (requests.Length == 2)
			{
				contacts = _db.Query<Contact>("select * from Contact where Name like '" + requests[0] +
				                              "%' and Surname like '" + requests[1] + "%'");
			}
		
			OnContactsUpdated?.Invoke(contacts.ToArray());
		}
	
		private Contact[] GetAllContacts()
		{
			var contacts = _db.Query<Contact> ("select * from Contact");
			return contacts.ToArray();
		}
    
		public void AddContact(Contact contact) => _db.Insert(contact);

		public Contact GetContactById(int id)
		{
			var contacts = _db.Query<Contact> ("select * from Contact where Id=" + id);
			return contacts[0];
		}

		public void DeleteContactById(int id) => _db.Delete(id, new TableMapping(typeof(Contact)));

		public void UpdateContact(Contact contact) => _db.Update(contact);

		private void UpdateContacts(object sender, NotifyTableChangedEventArgs e)
		{
			var contacts = GetAllContacts();
			OnContactsUpdated?.Invoke(contacts);
		}
	}
}
