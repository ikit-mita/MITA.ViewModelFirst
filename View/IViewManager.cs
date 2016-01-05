using ViewModel;

namespace View
{
    public interface IViewManager
    {
        void ShowViewForViewModel(ViewModelBase vm);

        void CloseViewForViewModel(ViewModelBase vm);
    }
}
