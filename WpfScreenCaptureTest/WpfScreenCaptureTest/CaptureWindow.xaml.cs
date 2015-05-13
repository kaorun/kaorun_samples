using System;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Interop;

namespace kaorun.samples
{
    /// <summary>
    /// Screen capture window class by selecting rectangle by Mouse with Rx event handling
    /// </summary>
    public partial class CaptureWindow : Window
    {
        public CaptureWindow()
        {
            InitializeComponent();
            
            Cursor = Cursors.Cross;
            var origin = new System.Windows.Point();
            
            var mouseDown = Observable.FromEventPattern<MouseEventArgs>(this, "MouseLeftButtonDown");
            var mouseMove = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove");
            var mouseUp = Observable.FromEventPattern<MouseEventArgs>(this, "MouseLeftButtonUp");

            mouseDown
                .Do(e => { origin = e.EventArgs.GetPosition(LayoutRoot); })
                .SelectMany(mouseMove)
                .TakeUntil(mouseUp)
                .Do(e =>
                {
                    var rect = BoundsRect(origin.X, origin.Y, e.EventArgs.GetPosition(LayoutRoot).X, e.EventArgs.GetPosition(LayoutRoot).Y);
                    selectionRect.Margin = new Thickness(rect.Left, rect.Top, this.Width - rect.Right, this.Height - rect.Bottom);
                    selectionRect.Width = rect.Width;
                    selectionRect.Height = rect.Height;
                })
                .LastAsync()
                .Subscribe(e =>
                {
                    this.Hide();

                    // Offsetting selection boundery, because transpalent WPF window shifted few pixel from screen coordinats
                    MainWindow.Captured = CaptureScreen(Rect.Offset(BoundsRect(origin.X, origin.Y, e.EventArgs.GetPosition(LayoutRoot).X, e.EventArgs.GetPosition(LayoutRoot).Y), this.Left, this.Top));
                    
                    Cursor = Cursors.Arrow;
                    this.Close();
                });
        }

        private static Rect BoundsRect(double left, double top, double right, double bottom)
        {
            return new Rect(Math.Min(left, right), Math.Min(top, bottom), Math.Abs(right - left), Math.Abs(bottom - top));
        }

        public static BitmapSource CaptureScreen(Rect rect)
        {
            using (var screenBmp = new Bitmap((int)rect.Width, (int)rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (var bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen((int)rect.X, (int)rect.Y, 0, 0, screenBmp.Size);
                    return Imaging.CreateBitmapSourceFromHBitmap(screenBmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
            }
        }
    }
}
