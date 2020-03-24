using System;
using System.Collections.Generic;
using CSharpLab4.Models;

namespace CSharpLab4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddUser(Person user);

        void ChangeUser(Person changedPerson);

        Person GetUser(Guid guid);

        void DeleteUser(Guid guid);

        void Generate_50_TestUsers();

        List<Person> UsersList { get; }
    }
}
