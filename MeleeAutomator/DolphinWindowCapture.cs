
namespace MeleeAutomator {
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Diagnostics;

    public class DolphinWindowCapture {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);

        private readonly Point DEFAULTSIZE = new Point(1920,1080);
        private readonly Rectangle CPUTournamentPortrait = new Rectangle(855, 261, 150, 64);

        private IntPtr mainWindowHandle;
        private WindowCapture capture;
        private float ratioX;
        private float ratioY;

        public DolphinWindowCapture() {
            Process[] p = Process.GetProcessesByName("Dolphin");
            if (p.Length <= 0) {
                throw new CouldNotFindDolphinWindowException();
            }
            mainWindowHandle = p[0].MainWindowHandle;
            capture = new WindowCapture();
            Bitmap reference = capture.CaptureWindow(mainWindowHandle);
            ratioX = (float)reference.Width / (float)DEFAULTSIZE.X;
            ratioY = (float)reference.Height / (float)DEFAULTSIZE.Y;
        }

        public void focus(){
            SetForegroundWindow(mainWindowHandle);
        }

        public Bitmap captureWindow() {
            return capture.CaptureWindow(mainWindowHandle);
        }

        public Bitmap captureCPUTournamentPortrait() {
            return capture.CaptureRegion(mainWindowHandle, applyRatio(CPUTournamentPortrait));
        }

        private Rectangle applyRatio(Rectangle rect) {
            return new Rectangle((int)(rect.Left * ratioX), (int)(rect.Top * ratioY), (int)(rect.Width * ratioX), (int)(rect.Height * ratioY));
        }
    }
}
