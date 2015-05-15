using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Characters {
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Xml;

    public class Character {
        public String name {
            get;
            private set;
        }
        public Bitmap tournamentBitmap {
            get;
            private set;
        }
        public Point tournamentPosition {
            get;
            private set;
        }
        public Point cssPosition {
            get;
            private set;
        }

        public Character(string name, Point tournamentPosition, Point cssPosition) {
            this.name = name;
            this.tournamentPosition = tournamentPosition;
            this.cssPosition = cssPosition;
            this.tournamentBitmap = Load(name);
        }

        private Bitmap Load(string name) {
            Bitmap bitmap = (Bitmap)MeleeAutomator.TournamentCharacters.ResourceManager.GetObject(name);
            using (Bitmap newBmp = new Bitmap(bitmap)) {
                Bitmap targetBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format32bppRgb);
                return targetBmp;
            }
        }
    }
}
