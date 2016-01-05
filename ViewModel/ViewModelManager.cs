using System;
using System.ComponentModel.Composition;
using System.Threading;

namespace ViewModel
{
    [Export(typeof(IViewModelManager))]
    public class ViewModelManager : IViewModelManager
    {
        public ViewModelManager()
        {
            
        }

        public void ShowViewModel(ViewModelBase vm)
        {
            OnViewModelShown(vm);
        }

        public void CloseViewModel(ViewModelBase vm)
        {
            OnViewModelClosed(vm);
        }

        public event ViewModelEventHandler ViewModelShown;

        public event ViewModelEventHandler ViewModelClosed;

        private void OnViewModelShown(ViewModelBase vm)
        {
            //ViewModelShown?.Invoke(vm);

            var handler = ViewModelShown;
            if (handler != null)
            {
                handler.Invoke(vm);
            }
        }

        private void OnViewModelClosed(ViewModelBase vm)
        {
            ViewModelClosed?.Invoke(vm);
        }
    }
}