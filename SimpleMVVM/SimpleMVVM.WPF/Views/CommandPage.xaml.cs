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
    /// CommandPage.xaml の相互作用ロジック
    /// </summary>
    public partial class CommandPage : Page
    {
        public CommandPage()
        {
            InitializeComponent();

            var p = new PersonCommandViewModel()
            {
                FirstName = "Tadafumi",
                LastName = "Iriya",
                Age = 17,
            };

            this.DataContext = p;
        }
    }
}
