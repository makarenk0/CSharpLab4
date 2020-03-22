
using CSharpLab4.Models;
using CSharpLab4.Tools.MVVM;
using System.Collections.ObjectModel;
using CSharpLab4.Tools.Managers;
using CSharpLab4.Tools.Navigation;
using System;

namespace CSharpLab4.ViewModel.Registration
{
    internal class UsersTableViewModel : BaseViewModel
    {

        private RelayCommand<object> _addingCommand;

        #region RelayCommands
        public RelayCommand<object> AddingCommand
        {
            get
            {
                return _addingCommand ?? (_addingCommand = new RelayCommand<object>(ToUserAddingState,
                    o => true));
            }
        }
        #endregion
        private void ToUserAddingState(object o)
        {
            NavigationManager.Instance.Navigate(ViewType.UserAdding);
           
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
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
           
        }
    }
}
