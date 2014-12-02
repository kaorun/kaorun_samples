using System.Windows.Controls;
using kaorun.samples.SimpleMVVM.WPF.Models;

namespace kaorun.samples.SimpleMVVM.WPF.Views
{
    public partial class FullNameModelPage : Page
    {
        public FullNameModelPage()
        {
            InitializeComponent();

            var p = new PersonFullName()
            {
                FirstName = "Tadafumi",
                LastName = "Iriya",
                Age = 17,
            };

            this.DataContext = p;
        }
    }
}
