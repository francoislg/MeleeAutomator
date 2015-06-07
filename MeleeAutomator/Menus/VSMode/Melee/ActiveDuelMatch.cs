using MeleeAutomator.Characters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Menus.VSMode.Melee {
    using MeleeAutomator.Images;
    public class ActiveDuelMatch {
        public MeleePlayer player1 { get; private set; }
        public MeleePlayer player2 { get; private set; }
        private DolphinWindowCapture capturer;
        private MatchImageMatcher matcher = new MatchImageMatcher();

        public ActiveDuelMatch(MeleePlayer player1, MeleePlayer player2, DolphinWindowCapture capturer) {
            this.player1 = player1;
            this.player2 = player2;
            this.capturer = capturer;
        }

        public async Task<FinishedDuelMatch> finish() {
            return await Task <FinishedDuelMatch>.Run(() => {
                return waitForMatchToFinish();
            });
        }

        private FinishedDuelMatch waitForMatchToFinish() {
            Bitmap bitmap = capturer.captureEndOfMatchWindow();
            int count = 0;
            while (!matcher.isEndOfMatch(bitmap)) {
                Console.WriteLine(count++ + " - End Of Match : No");
                System.Threading.Thread.Sleep(200);
                bitmap = capturer.captureEndOfMatchWindow();
            };
            bitmap.Dispose();
            Bitmap bitmapP1 = capturer.captureWinningRibbon(1);
            Bitmap bitmapP2 = capturer.captureWinningRibbon(2);
            while (!matcher.playerWon(bitmapP1) && !matcher.playerWon(bitmapP2)) {
                Console.WriteLine(count++ + " - Ribbon : No");
                System.Threading.Thread.Sleep(200);
                bitmapP1 = capturer.captureWinningRibbon(1);
                bitmapP2 = capturer.captureWinningRibbon(2);
            };
            if (matcher.playerWon(bitmapP1)) {
                return new FinishedDuelMatch(player1, player2);
            } else if (matcher.playerWon(bitmapP2)) {
                return new FinishedDuelMatch(player2, player1);
            } else {
                throw new InvalidOperationException("Match has been won by a player, but it was not player 1 or player 2");
            }
        }
    }
}
