namespace ViewModel
{
    public interface IViewModelManager
    {
        void ShowViewModel(ViewModelBase vm);

        void CloseViewModel(ViewModelBase vm);

        event ViewModelEventHandler ViewModelShown;

        event ViewModelEventHandler ViewModelClosed;
    }

    public delegate void ViewModelEventHandler(ViewModelBase vm);
}
