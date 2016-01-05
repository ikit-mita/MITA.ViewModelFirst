using System.ComponentModel.Composition;

namespace View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    [Export("UserView", typeof(ViewBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class UserView : ViewBase
    {
        public UserView()
        {
            InitializeComponent();
        }
    }
}
