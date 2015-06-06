
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
        private readonly Rectangle[] PlayersWinningRibbons = new Rectangle[] {
            new Rectangle(375, 858, 90, 5),
            new Rectangle(810, 858, 90, 5)
        };
        private readonly Rectangle EndOfMatchWindow = new Rectangle(780, 515, 150, 64);

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

        public List<Bitmap> test(int player) {
            if (player < 0 || player > 4) {
                throw new ArgumentOutOfRangeException("This game only has 4 players");
            }
            if (player > PlayersWinningRibbons.Length) {
                throw new NotSupportedException("This ribbon player is not yet supported");
            }
            List<Bitmap> t = new List<Bitmap>();
            Rectangle rec = PlayersWinningRibbons[player - 1];
            for (int i = -50; i < 50; i++) {
                t.Add(capture.CaptureRegion(mainWindowHandle, applyRatio(rec)));
                    rec.X = PlayersWinningRibbons[player - 1].X + i;
            }
            return t;
        }

        private Rectangle applyRatio(Rectangle rect) {
            return new Rectangle((int)(rect.Left * ratioX), (int)(rect.Top * ratioY), (int)(rect.Width * ratioX), (int)(rect.Height * ratioY));
        }
    }
}
