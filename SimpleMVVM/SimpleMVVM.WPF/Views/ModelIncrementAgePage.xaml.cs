using kaorun.samples.SimpleMVVM.WPF.Models;
using System.Windows;
using System.Windows.Controls;

namespace kaorun.samples.SimpleMVVM.WPF.Views
{
    public partial class ModelIncrementAgePage : Page
    {
        private Person p;

        public ModelIncrementAgePage()
        {
            InitializeComponent();

            p = new Person()
            {
                FirstName = "Tadafumi",
                LastName = "Iriya",
                Age = 17,
            };

            this.DataContext = p;
        }

        private void cmdIncrementAge_Click(object sender, RoutedEventArgs e)
        {
            p.Age++;
        }
    }
}
