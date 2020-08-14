using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Web_API_Exercise1.Models;

namespace Web_API_Exercise1.Services
{
	public class ContactRepository
	{
		private const string databaseFileName = "database.json";

		public List<Contact> GetAllContacts()
        {
			string jsonData = System.IO.File.ReadAllText(databaseFileName);
			return string.IsNullOrEmpty(jsonData) 
				? new List<Contact>() 
				: JsonConvert.DeserializeObject<List<Contact>>(jsonData);
		}

		public Contact GetContactById(int id)
		{
			List<Contact> contacsList = GetAllContacts();

			foreach (Contact c in contacsList){
				if (c.Id == id) return c;
            }

			return null;
		}

		public bool SaveContact(string name)
        {
			List<Contact> contacsList = GetAllContacts();
			contacsList.Add(new Contact
			{
				Id = contacsList.Count + 1,
				Name = name

			}
			);

			//JsonSerializer serializer = new JsonSerializer();
			//serialize object directly into file stream
			string json = JsonConvert.SerializeObject(contacsList);

			//write string to file
			System.IO.File.WriteAllText(databaseFileName, json);


			return true;

		}

		public bool ChangeContact(int id, string name)
		{
			List<Contact> contacsList = GetAllContacts();
			foreach (Contact c in contacsList)
			{
				if (c.Id == id)
				{
					c.Name = name;
					string json = JsonConvert.SerializeObject(contacsList);

					//write string to file
					System.IO.File.WriteAllText(databaseFileName, json);


					return true;

				}
			}

			//JsonSerializer serializer = new JsonSerializer();
			//serialize object directly into file stream

			return false;
		}
	}

}
