
namespace MeleeAutomator.Images {
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
        private readonly Rectangle[] PlayersWinningRibbons = new Rectangle[] {
            new Rectangle(375, 858, 90, 5),
            new Rectangle(810, 858, 90, 5)
        };
        private readonly Rectangle EndOfMatchWindow = new Rectangle(780, 515, 150, 64);

        private IntPtr mainWindowHandle;
        private WindowCapture capture;

        public DolphinWindowCapture() {
            Process[] p = Process.GetProcessesByName("Dolphin");
            if (p.Length <= 0) {
                throw new CouldNotFindDolphinWindowException();
            }
            mainWindowHandle = p[0].MainWindowHandle;
            capture = new WindowCapture();
        }

        public void focus(){
            SetForegroundWindow(mainWindowHandle);
        }

        public Bitmap captureWindow() {
            return capture.CaptureWindow(mainWindowHandle);
        }

        public Bitmap captureEndOfMatchWindow() {
            return capture.CaptureRegion(mainWindowHandle, applyRatio(EndOfMatchWindow));
        }

        public Bitmap captureCPUTournamentPortrait() {
            return capture.CaptureRegion(mainWindowHandle, applyRatio(CPUTournamentPortrait));
        }

        public Bitmap captureWinningRibbon(int player) {
            if (player < 0 || player > 4) {
                throw new ArgumentOutOfRangeException("This game only has 4 players");
            }
            if (player > PlayersWinningRibbons.Length) {
                throw new NotSupportedException("This ribbon player is not yet supported");
            }
            return capture.CaptureRegion(mainWindowHandle, applyRatio(PlayersWinningRibbons[player - 1]));
        }

        private Rectangle applyRatio(Rectangle rect) {
            return new Rectangle((int)(rect.Left * 1), (int)(rect.Top * 1), (int)(rect.Width * 1), (int)(rect.Height * 1));
        }

        private void recalibrate() {

        }
    }
}
