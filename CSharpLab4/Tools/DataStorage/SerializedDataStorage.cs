using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpLab4.Models;
using CSharpLab4.Tools.Managers;

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

        public void Generate_50_TestUsers()
        {
            for(int i = 0; i<10; i++)
            {
                _users.Add(new Person("Oleg", "Olegov", "oleg@gmail.com", new DateTime(2001, 12, 10)));
                _users.Add(new Person("Andrej", "Andrejev", "Andrej@gmail.com", new DateTime(1990, 5, 19)));
                _users.Add(new Person("Dmitrij", "Dmitrov", "dima@gmail.com", new DateTime(2012, 1, 1)));
                _users.Add(new Person("Jenia", "J", "jen@gmail.com", new DateTime(2019, 3, 10)));
                _users.Add(new Person("Masha", "M", "ma@gmail.com", DateTime.Now.Date));
            }
            SaveChanges();
        }


    }
}

