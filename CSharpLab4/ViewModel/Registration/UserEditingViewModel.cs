using CSharpLab4.Exceptions;
using CSharpLab4.Models;
using CSharpLab4.Tools.DataStorage;
using CSharpLab4.Tools.Managers;
using CSharpLab4.Tools.MVVM;
using CSharpLab4.Tools.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpLab4.ViewModel.Registration
{
    internal class UserEditingViewModel : BaseViewModel
    {
        private Person _person;

        private string _nameField;   //fields from view that needed to be processed by validator (Model is created only when there is correct data)
        private string _surnameField;
        private string _emailField;
        private DateTime _birthDateField = System.DateTime.UtcNow;

        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _editCommand;
        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _closeCommand;

        public UserEditingViewModel()
        {
            TableUpdate.InitEdit = StartEditingUser;
        }

        public void StartEditingUser()
        {
            Person p = StationManager.DataStorage.GetUser(TableUpdate.userToChange);
            NameField = p.Name;
            SurnameField = p.Surname;
            EmailField = p.Email;
            BirthDateField = p.BirthDate;
            ProceedInplementation(new object());
        }
        #region Properties

        #region FieldsDataFromView
        public string NameField
        {
            set
            {
                _nameField = value;
                OnPropertyChanged();
            }
            get { return _nameField; }
        }
        public string SurnameField
        {
            set
            {
                _surnameField = value;
                OnPropertyChanged();
            }
            get { return _surnameField; }
        }
        public string EmailField
        {
            set
            {
                _emailField = value;
                OnPropertyChanged();
            }
            get { return _emailField; }
        }
        public DateTime BirthDateField
        {
            set
            {
                _birthDateField = value;
                OnPropertyChanged();
            }
            get { return _birthDateField; }
        }
        #endregion

        #region ModelDataGetters
        //all data converts to string
        public string Name
        {
            get { return _person?.Name; }
        }
        public string Surname
        {
            get { return _person?.Surname; }
        }
        public string Email
        {
            get { return _person?.Email; }
        }
        public string BirthDate
        {
            get { return _person?.BirthDate.ToString(); }
        }
        public string IsAdult
        {
            get { if (_person == null) { return ""; } return _person.IsAdult ? "adult" : "child"; }
        }
        public string SunSign
        {
            get { return _person?.SunSign; }
        }
        public string ChineseSign
        {
            get { return _person?.ChineseSign; }
        }
        public string IsBirthday
        {
            get { if (_person == null) { return ""; } return _person.IsBirthday ? "Today is your birtday!!!" : ""; }
        }
        #endregion

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(ProceedInplementation,
                    o => CanExecuteProceedCommand()));
            }
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand<object>(EditInplementation,
                    o => CanExecuteConfirmCommand()));
            }
        }

        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(BackToTable,
                    o => true));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

        private void BackToTable(object obj)
        {
            ClearFields();
            NavigationManager.Instance.Navigate(ViewType.UsersTable);
        }

        async private void ProceedInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => ProceedData());
            LoaderManager.Instance.HideLoader();
        }

        private void ProceedData()
        {
            try
            {
                _person = new Person(NameField, SurnameField, EmailField, BirthDateField);

                if (_person.IsBirthday) { MessageBox.Show($"Happy birthday, {Name} !"); }
                #region Change Properties
                OnPropertyChanged("Name");
                OnPropertyChanged("Surname");
                OnPropertyChanged("Email");
                OnPropertyChanged("BirthDate");
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
                OnPropertyChanged("IsBirthday");
                #endregion

            }
            catch (FutureBirthDateException exp)
            {
                MessageBox.Show($"Error: {exp.Message} !\n Your input: {exp.Value}");
            }
            catch (OldBirthDateException exp)
            {
                MessageBox.Show($"Error: {exp.Message} !\n Your input: {exp.Value}");
            }
            catch (InvalidEmailException exp)
            {
                MessageBox.Show($"Error: {exp.Message} !\n Your input: {exp.Value}");
            }
        }

        async private void EditInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool result = await Task.Run(() => {
                _person.Guid = TableUpdate.userToChange;
                StationManager.DataStorage.ChangeUser(_person);  //TO DO try catch for dublicating users
                _person = null;
                return true;
            });
            LoaderManager.Instance.HideLoader();
            ClearFields();
            if (result) NavigationManager.Instance.Navigate(ViewType.UsersTable);
        }
        #endregion
        private void ClearFields()
        {
            NameField = null;
            SurnameField = null;
            EmailField = null;
            BirthDateField = System.DateTime.UtcNow;
        }

        private bool CanExecuteProceedCommand()
        {
            return !string.IsNullOrWhiteSpace(NameField) && !string.IsNullOrWhiteSpace(SurnameField) && !string.IsNullOrWhiteSpace(EmailField);
        }

        private bool CanExecuteConfirmCommand()
        {
            return _person == null ? false : true;
        }
    }
}
