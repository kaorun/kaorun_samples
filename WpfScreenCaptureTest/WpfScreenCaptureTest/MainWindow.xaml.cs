using System.Windows;
using System.Windows.Media.Imaging;

namespace kaorun.samples
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;

        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new CaptureWindow();
            this.Visibility = Visibility.Hidden;
            wnd.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        public static BitmapSource Captured
        {
            get { return (BitmapSource)instance.GetValue(CapturedProperty); }
            set { instance.SetValue(CapturedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Captured.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CapturedProperty =
            DependencyProperty.Register("Captured", typeof(BitmapSource), typeof(MainWindow), new PropertyMetadata(null));

    }
}
