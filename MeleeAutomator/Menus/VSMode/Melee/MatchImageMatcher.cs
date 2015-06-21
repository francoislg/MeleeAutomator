// Comparing bitmap from :
// http://www.dotnetexamples.com/2012/07/fast-bitmap-comparison-c.html

namespace MeleeAutomator.Characters {
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using MeleeAutomator.Characters;
    using Images;

    public class MatchImageMatcher {
        private Bitmap endOfMatchBitmap = MeleeAutomator.MatchRessources.EndOfMatch;
        private Bitmap[] ribbonBitmaps = new Bitmap[] {
            MeleeAutomator.MatchRessources.Ribbon,
             MeleeAutomator.MatchRessources.Ribbon2
        };
        public MatchImageMatcher() {
             
        }

        public bool isEndOfMatch(Bitmap compared) {
            return ImageHelper.areSimilar(endOfMatchBitmap, compared);
        }

        public bool playerWon(Bitmap compared) {
            foreach (Bitmap bitmap in ribbonBitmaps) {
                if (ImageHelper.areSimilar(bitmap, compared)) {
                    return true;
                }
            }
            return false;
        }
    }
}
