using kaorun.samples.SimpleMVVM.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kaorun.samples.SimpleMVVM.WPF.Views
{
    /// <summary>
    /// ViewModelIncrementAgePage.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewModelIncrementAgePage : Page
    {
        private PersonViewModel p;

        public ViewModelIncrementAgePage()
        {
            InitializeComponent();

            p = new PersonViewModel()
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
