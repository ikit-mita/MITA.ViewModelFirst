using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using ViewModel;

namespace View
{
    [Export(typeof(IViewManager))]
    public class ViewManager : IViewManager
    {
        [ImportingConstructor]
        public ViewManager(IViewModelManager viewModelManager
            , IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            viewModelManager.ViewModelShown += ShowViewForViewModel;
            viewModelManager.ViewModelClosed += CloseViewForViewModel;
        }

        private readonly IServiceLocator _serviceLocator;
        private readonly Dictionary<ViewModelBase, ViewBase> _openView
            = new Dictionary<ViewModelBase, ViewBase>();

        public void ShowViewForViewModel(ViewModelBase vm)
        {
            var typeVm = vm.GetType();
            var view = ResolveView(typeVm);



            view.DataContext = vm;
            view.Show();
            _openView.Add(vm, view);
        }

        public void CloseViewForViewModel(ViewModelBase vm)
        {
            if (_openView.ContainsKey(vm))
            {
                var view = _openView[vm];
                view.Close();
                _openView.Remove(vm);
            }
        }

        private ViewBase ResolveView(Type vmType)
        {
            var viewName = vmType.Name.Replace("ViewModel", "View");

            var view = _serviceLocator.GetInstance<ViewBase>(viewName);
            return view;
        }
    }
}