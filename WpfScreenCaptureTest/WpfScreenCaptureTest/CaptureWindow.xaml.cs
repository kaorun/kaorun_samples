using System;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Threading;

namespace kaorun.samples
{
    /// <summary>
    /// マウスでドラッグして選択するウインドウクラス
    /// </summary>
    public partial class CaptureWindow : Window
    {
        public CaptureWindow()
        {
            InitializeComponent();
            Cursor = Cursors.Cross;

            var mouseDownEvents = Observable.FromEventPattern<MouseEventArgs>(this, "MouseLeftButtonDown");
            var mouseMoveEvents = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove");
            var mouseUpEvents = Observable.FromEventPattern<MouseEventArgs>(this, "MouseLeftButtonUp");

            var startPos = new System.Windows.Point();
            var drag = mouseDownEvents.SelectMany(down =>
            {
                startPos = down.EventArgs.GetPosition(LayoutRoot);
                return mouseMoveEvents;
            }).TakeUntil(mouseUpEvents).Select(e => BoundsRect(startPos.X, startPos.Y, e.EventArgs.GetPosition(LayoutRoot).X, e.EventArgs.GetPosition(LayoutRoot).Y));
            drag.Subscribe(e =>
            {
                Canvas.SetLeft(selectionRect, e.X);
                Canvas.SetTop(selectionRect, e.Y);
                selectionRect.Width = e.Width;
                selectionRect.Height = e.Height;
            });
            mouseUpEvents.Subscribe(e =>
            {
                this.Hide();
                // WPFのウインドウを枠無しで最大化すると微妙にオフセットするので補正している。
                var bmp = CaptureScreen(Rect.Offset(BoundsRect(startPos.X, startPos.Y, e.EventArgs.GetPosition(LayoutRoot).X, e.EventArgs.GetPosition(LayoutRoot).Y), this.Left, this.Top));
                MainWindow.Captured = bmp;
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
                    return Imaging.CreateBitmapSourceFromHBitmap(
                        screenBmp.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                }
            }
        }
    }
}
