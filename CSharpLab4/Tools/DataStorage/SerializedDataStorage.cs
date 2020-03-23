using System;
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

        public void ChangeUser(Person changedPerson)
        {
            Guid g = _users.Find(  //test
            delegate (Person p)
            {
                return p.Guid == changedPerson.Guid;
            }
            ).Guid;
            DeleteUser(g);
            AddUser(changedPerson);
        }

        public Person GetUser(Guid guid)
        {
            return _users.Find(  //test
            delegate (Person p)
            {
                return p.Guid == guid;
            }
            );
        }

        public void AddUser(Person user)
        {
            _users.Add(user);
            SaveChanges();
        }

        public void DeleteUser(Guid guid)
        {
            foreach (Person user in _users)
            {
                if (user.Guid == guid)
                {
                    _users.Remove(user);
                    break;
                }
            }
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

