
using CSharpLab4.Models;
using CSharpLab4.Tools.MVVM;
using System.Collections.ObjectModel;
using CSharpLab4.Tools.Managers;
using CSharpLab4.Tools.Navigation;
using System;
using CSharpLab4.Tools.DataStorage;
using CSharpLab4.Tools;
using System.Threading.Tasks;

namespace CSharpLab4.ViewModel.Registration
{
    internal class UsersTableViewModel : BaseViewModel
    {
        private PersonFilter _filter;
        private RelayCommand<object> _addingCommand;
        private RelayCommand<object> _deletingCommand;
        private RelayCommand<object> _editingCommand;
        private RelayCommand<object> _filteringCommand;
        private RelayCommand<object> _clearingFilterCommand;

        #region FilterProperties
        public string NameFilter{
            get { return _filter._name; }
            set { _filter._name = value; }
        }
        public string SurnameFilter
        {
            get { return _filter._surname; }
            set { _filter._surname = value; }
        }
        public string EmailFilter
        {
            get { return _filter._email; }
            set { _filter._email = value; }
        }
        public DateTime BirthDateFilter
        {
            get { return _filter._birthDate; }
            set { _filter._birthDate = value; }
        }
        public string ChineseZodiacFilter
        {
            get { return _filter._userChineseZodiac; }
            set { _filter._userChineseZodiac = value; }
        }
        public string WesternZodiacFilter
        {
            get { return _filter._userWesternZodiac; }
            set { _filter._userWesternZodiac = value; }
        }
        public string IsAdultFilter
        {
            get { return _filter._isAdult; }
            set { _filter._isAdult = value; }
        }
        public string IsBirthdayFilter
        {
            get { return _filter._isBirthday; }
            set { _filter._isBirthday = value; }
        }
        #endregion

        #region RelayCommands
        public RelayCommand<object> AddingCommand
        {
            get
            {
                return _addingCommand ?? (_addingCommand = new RelayCommand<object>(ToUserAddingState,
                    o => true));
            }
        }

        public RelayCommand<object> DeletingCommand
        {
            get
            {
                return _deletingCommand ?? (_deletingCommand = new RelayCommand<object>(DeleteUser,
                    o => true));
            }
        }

        public RelayCommand<object> EditingCommand
        {
            get
            {
                return _editingCommand ?? (_editingCommand = new RelayCommand<object>(EditUser,
                    o => true));
            }
        }

        public RelayCommand<object> FilteringCommand
        {
            get
            {
                return _filteringCommand ?? (_filteringCommand = new RelayCommand<object>(FilterUsers,
                    o => true));
            }
        }

        public RelayCommand<object> ClearingFilterCommand
        {
            get
            {
                return _clearingFilterCommand ?? (_clearingFilterCommand = new RelayCommand<object>(ClearFilter,
                    o => true));
            }
        }
        #endregion
        private void ToUserAddingState(object o)
        {
        
            NavigationManager.Instance.Navigate(ViewType.UserAdding);
           
        }

        private async void DeleteUser(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                StationManager.DataStorage.DeleteUser(new Guid(o.ToString()));
                FillObservableCollection();
            });
            LoaderManager.Instance.HideLoader();
        }

        private void EditUser(object o)
        {
            TableUpdate.userToChange = new Guid(o.ToString());
            NavigationManager.Instance.Navigate(ViewType.UserEditing);
        }

        private async void FilterUsers(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                FillObservableCollection();
                Users = _filter.FilterUsers(ref _users);
            });
            LoaderManager.Instance.HideLoader();
        }

        private async void ClearFilter(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                _filter = new PersonFilter();
                FillObservableCollection();
            });
            LoaderManager.Instance.HideLoader();
        }

        private ObservableCollection<Person> _users;
        public ObservableCollection<Person> Users
        {
            get => _users;
            private set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public UsersTableViewModel()
        {
            _filter = new PersonFilter();
            StationManager.DataStorage.Generate_50_TestUsers();
            TableUpdate.Update = FillObservableCollection;
        }
        private void FillObservableCollection()
        {
            Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }
    }
}
