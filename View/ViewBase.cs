using System;
using System.ComponentModel;
using System.Windows;
using ViewModel;

namespace View
{
    public class ViewBase : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!((ViewModelBase)DataContext).IsClosed)
            {
                e.Cancel = true;
                Dispatcher.BeginInvoke(new Action(() => ((ViewModelBase)DataContext).Close()));
            }
        }
    }
}