using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace GettingStartedLib
{
    public class ScreenShotMaker
    {
        public static MemoryStream MakeScreenshot()
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics graphics = Graphics.FromImage(printscreen as Image);

            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            //printscreen.Save(@"C:\Temp\printscreen.jpg", ImageFormat.Jpeg);
            MemoryStream ms = new MemoryStream();
            printscreen.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            return ms;
        }
    }
}
