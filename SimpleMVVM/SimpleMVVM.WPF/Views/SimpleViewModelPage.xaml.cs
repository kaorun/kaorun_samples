using kaorun.samples.SimpleMVVM.WPF.ViewModels;
using System.Windows.Controls;

namespace kaorun.samples.SimpleMVVM.WPF.Views
{
    /// <summary>
    /// SimpleViewModelPage.xaml の相互作用ロジック
    /// </summary>
    public partial class SimpleViewModelPage : Page
    {
        public SimpleViewModelPage()
        {
            InitializeComponent();

            var p = new PersonViewModel()
            {
                FirstName = "Tadafumi",
                LastName = "Iriya",
                Age = 17,
            };

            this.DataContext = p;
        }
    }
}
