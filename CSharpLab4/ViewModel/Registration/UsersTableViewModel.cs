
using CSharpLab4.Models;
using CSharpLab4.Tools.MVVM;
using System.Collections.ObjectModel;
using CSharpLab4.Tools.Managers;
using CSharpLab4.Tools.Navigation;
using System;
using CSharpLab4.Tools.DataStorage;

namespace CSharpLab4.ViewModel.Registration
{
    internal class UsersTableViewModel : BaseViewModel
    {
        //private delegate void StorageChanged();
        private RelayCommand<object> _addingCommand;
        private RelayCommand<object> _deletingCommand;
        private RelayCommand<object> _editingCommand;

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
        #endregion
        private void ToUserAddingState(object o)
        {
        
            NavigationManager.Instance.Navigate(ViewType.UserAdding);
           
        }

        private void DeleteUser(object o)
        {
            StationManager.DataStorage.DeleteUser(new Guid(o.ToString()));
            FillObservableCollection();
        }

        private void EditUser(object o)
        { 
            TableUpdate.userToChange = new Guid(o.ToString());
            NavigationManager.Instance.Navigate(ViewType.UserEditing);
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
            TableUpdate.Update = FillObservableCollection;
        }
        private void FillObservableCollection()
        {
            Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }
    }
}
