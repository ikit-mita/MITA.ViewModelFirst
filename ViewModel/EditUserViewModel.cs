using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;
using Model;
using ViewModel.Annotations;

namespace ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditUserViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public EditUserViewModel(IViewModelManager viewModelManager)
            : base(viewModelManager)
        {
        }

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }
    }
}