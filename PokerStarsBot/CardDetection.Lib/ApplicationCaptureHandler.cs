using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace CardDetection.Lib
{
    public class ApplicationCaptureHandler
    {
        public static Bitmap CaptureApplication(string procName)
        {
            var proc = Process.GetProcessesByName(procName)[0];

            var rect = new User32.Rect();
            User32.GetWindowRect(proc.MainWindowHandle, ref rect);

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bmp);
            User32.SetForegroundWindow(proc.MainWindowHandle);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

            return bmp;
        }

        /*
            Bitmap PokerStarsWindow = ApplicationCaptureHandler.CaptureApplication("PokerStars");
            pictureBox1.Width = PokerStarsWindow.Width;
            pictureBox1.Height = PokerStarsWindow.Height;
            pictureBox1.BackgroundImage = PokerStarsWindow;
         */
    }
}
