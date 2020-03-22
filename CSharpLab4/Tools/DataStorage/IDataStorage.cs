using System.Collections.Generic;
using CSharpLab4.Models;

namespace CSharpLab4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddUser(Person user);

        Person getLastAddedUser();

        List<Person> UsersList { get; }
    }
}
