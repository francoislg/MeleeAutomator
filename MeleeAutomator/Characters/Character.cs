using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Characters {
    using System.Drawing;
    using System.Drawing.Imaging;

    public class Character {
        private Bitmap tournamentBitmap;
        private String name;

        public Character(string name) {
            this.name = name;
            this.tournamentBitmap = Load(name);
        }

        private Bitmap Load(string name) {
            Bitmap bitmap = (Bitmap)MeleeAutomator.TournamentCharacters.ResourceManager.GetObject(name);
            using (Bitmap newBmp = new Bitmap(bitmap)) {
                Bitmap targetBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format32bppRgb);
                return targetBmp;
            }
        }

        public Bitmap getTournamentBitmap() {
            return tournamentBitmap;
        }

        public string getName() {
            return name;
        }
    }
}
