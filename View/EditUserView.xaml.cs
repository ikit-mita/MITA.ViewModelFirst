using System.ComponentModel.Composition;

namespace View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    [Export("EditUserView", typeof(ViewBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EditUserView : ViewBase
    {
        public EditUserView()
        {
            InitializeComponent();
        }
    }
}
