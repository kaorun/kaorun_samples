using System.Windows.Controls;
using kaorun.samples.SimpleMVVM.WPF.Models;

namespace kaorun.samples.SimpleMVVM.WPF.Views
{
    public partial class FieldMemberModelPage : Page
    {
        public FieldMemberModelPage()
        {
            InitializeComponent();

            var p = new PersonFieldMember()
            {
                FirstName = "Tadafumi",
                LastName = "Iriya",
                Age = 17,
            };

            this.DataContext = p;
        }
    }
}
