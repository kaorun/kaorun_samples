using System.Windows.Controls;
using kaorun.samples.SimpleMVVM.WPF.Models;

namespace kaorun.samples.SimpleMVVM.WPF.Views
{
    public partial class SimpleModelPage : Page
    {
        public SimpleModelPage()
        {
            InitializeComponent();

            var p = new Person()
            {
                FirstName = "Tadafumi",
                LastName = "Iriya",
                Age = 17,
            };

            this.DataContext = p;
        }
    }
}
