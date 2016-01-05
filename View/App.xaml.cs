using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var directoryCatalog = new DirectoryCatalog(".");
            var assemblyCatalog = new AssemblyCatalog(GetType().Assembly);
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(directoryCatalog);
            aggregateCatalog.Catalogs.Add(assemblyCatalog);

            var container = new CompositionContainer(aggregateCatalog);
            var locator = new MefServiceLocator(container);
            container.ComposeExportedValue<IServiceLocator>(locator);

            container.ComposeParts(this);

            var qqq = locator.GetInstance<IViewManager>();
            var userViewModel = locator.GetInstance<UserViewModel>();
        }
    }
}
