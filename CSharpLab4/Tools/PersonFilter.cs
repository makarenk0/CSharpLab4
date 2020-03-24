using CSharpLab4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CSharpLab4.Tools
{
    class PersonFilter
    {
        public PersonFilter()
        {
            
        }
        public string _name = "";
        public string _surname = "";
        public string _email = "";
        public DateTime _birthDate = DateTime.Now.Date;
        public string _userChineseZodiac = "All";
        public string _userWesternZodiac = "All";

        public string _isAdult = "All";
        public string _isBirthday = "All";

        public ObservableCollection<Person> FilterUsers(ref ObservableCollection<Person> Users)
        {
            IEnumerable<Person> selectedUsers = Users;

            selectedUsers = from user in selectedUsers
                            where CheckUser(user)
                            select user;

            return new ObservableCollection<Person>(selectedUsers);
        }

        public bool CheckUser(Person p)
        {
            bool result = true;
            if (_name != ""&&_name != p.Name)
            {
                result = false;
            }
            if (_surname != ""&&_surname != p.Surname)
            {
                result = false;
            }
            if (_email != ""&&_email!= p.Email)
            {
                result = false;
            }
            if (_birthDate != DateTime.Now.Date&& _birthDate != p.BirthDate)
            {
                result = false;
            }
            bool IsAdult = (_isAdult == "Adult");
            if (_isAdult != "All"&& (p.IsAdult != IsAdult))
            {
                result = false;
            }
            bool IsBirthDay = (_isBirthday == "Yes");
            if (_isBirthday != "All"&& (p.IsBirthday != IsBirthDay))
            {
                result = false;
            }
            if (_userChineseZodiac != "All"&& p.ChineseSign != _userChineseZodiac)
            {
                result = false;
            }
            if (_userWesternZodiac != "All"&& p.SunSign != _userWesternZodiac)
            {
                result = false;
            }

            return result;
        }
    }
}
