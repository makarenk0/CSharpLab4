using CSharpLab4.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace CSharpLab4.Models
{
    [Serializable]
    class Person
    {
        private Guid _guid;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        private string[] _chineseZodiac = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private string[] _westernZodiac = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };



        public Person(string name, string surname, string email, DateTime birthDate)
        {
            _guid = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
        }
        public Person(string name, string surname, string email)
        {
            _guid = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
        }
        public Person(string name, string surname, DateTime birthDate)
        {
            _guid = Guid.NewGuid();
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set {
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (!regex.IsMatch(value)) throw new InvalidEmailException(value);
                _email = value;
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set {
                if (DateTime.Today < value) throw new FutureBirthDateException(value);
                else if (new DateTime(DateTime.Today.Subtract(value).Ticks).Year > 135) throw new OldBirthDateException(value);
                _birthDate = value; 
            }
        }
        public bool IsAdult
        {
            get { return new DateTime(DateTime.Today.Subtract(BirthDate).Ticks).Year > 18; }
        }
        public string SunSign
        {
            get {switch (_birthDate.Month) {
                    case 1:
                        return _birthDate.Day <= 20 ? _westernZodiac[0] : _westernZodiac[1];
                    case 2:
                        return _birthDate.Day <= 19 ? _westernZodiac[1] : _westernZodiac[2];
                    case 3:
                        return _birthDate.Day <= 20 ? _westernZodiac[2] : _westernZodiac[3];
                    case 4:
                        return _birthDate.Day <= 20 ? _westernZodiac[3] : _westernZodiac[4];
                    case 5:
                        return _birthDate.Day <= 20 ? _westernZodiac[4] : _westernZodiac[5];
                    case 6:
                        return _birthDate.Day <= 21 ? _westernZodiac[5] : _westernZodiac[6];
                    case 7:
                        return _birthDate.Day <= 22 ? _westernZodiac[6] : _westernZodiac[7];
                    case 8:
                        return _birthDate.Day <= 23 ? _westernZodiac[7] : _westernZodiac[8];
                    case 9:
                        return _birthDate.Day <= 23 ? _westernZodiac[8] : _westernZodiac[9];
                    case 10:
                        return _birthDate.Day <= 22 ? _westernZodiac[9] : _westernZodiac[10];
                    case 11:
                        return _birthDate.Day <= 22 ? _westernZodiac[10] : _westernZodiac[11];
                    case 12:
                        return _birthDate.Day <= 21 ? _westernZodiac[11] : _westernZodiac[0];
                    default:
                        return null;
                }
            }
        }
        public string ChineseSign
        {
            get
            {
                uint chzodiac = (uint)((_birthDate.Year - 4) % 12);
                return _chineseZodiac[chzodiac];
            }
        }
        public bool IsBirthday
        {
            get { return DateTime.Today == BirthDate.Date; }
        }
    }
}
