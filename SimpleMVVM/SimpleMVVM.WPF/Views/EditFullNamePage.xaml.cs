using System.Windows.Controls;
using kaorun.samples.SimpleMVVM.WPF.ViewModels;

namespace kaorun.samples.SimpleMVVM.WPF.Views
{
    public partial class EditFullNamePage : Page
    {
        public EditFullNamePage()
        {
            InitializeComponent();

            var p = new PersonFullNameViewModel()
            {
                FirstName = "Tadafumi",
                LastName = "Iriya",
                Age = 17,
            };

            this.DataContext = p;
        }
    }
}
