using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using Model;

namespace ViewModel
{
    [Export]
    public class UserViewModel : ViewModelBase
    {
        private readonly IServiceLocator _serviceLocator;

        [ImportingConstructor]
        public UserViewModel(IViewModelManager viewModelManager, 
            IServiceLocator serviceLocator)
            : base(viewModelManager)
        {
            _serviceLocator = serviceLocator;
        }

        private RelayCommand _editUserViewCommand;
        private List<User> _users;

        public User SelectedUser { get; set; }

        public List<User> Users => _users ?? (_users = new List<User>
        {
            new User
            {
                Name = "FirstUser",
                Issues = new List<Issue>
                {
                    new Issue {Title = "Task1"},
                    new Issue {Title = "Task2"}
                }
            }
        });

        public RelayCommand EditUserViewCommand => _editUserViewCommand ?? (
            _editUserViewCommand = new RelayCommand(
                OnEditUserViewModelCreate, CanExecute));

        private bool CanExecute(object obj)
        {
            return SelectedUser != null;
        }

        private void OnEditUserViewModelCreate(object obj)
        {
            var editUserViewModel = 
                _serviceLocator.GetInstance<EditUserViewModel>();
            editUserViewModel.CurrentUser = SelectedUser;
        }
    }
}