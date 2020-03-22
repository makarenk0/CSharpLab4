using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpLab4.Models;
using CSharpLab4.Tools.Managers;
using CSharpLab4.ViewModel.Registration;

namespace CSharpLab4.Tools.DataStorage
{
    internal class SerializedDataStorage:IDataStorage
    {
        private readonly List<Person> _users;

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
            }
        }


        public void AddUser(Person user)
        {
            _users.Add(user);
            SaveChanges();
        }

        public Person getLastAddedUser()
        {
            return _users.Last();
        }

        public List<Person> UsersList
        {
            get { return _users.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }
    }
}

