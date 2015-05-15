// Comparing bitmap from :
// http://www.dotnetexamples.com/2012/07/fast-bitmap-comparison-c.html

namespace MeleeAutomator.Characters {
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using MeleeAutomator.Characters;

    public class CharactersImageMatcher {
        private Character[,] allCharacters = new Character[5,5];
        private CharactersManager characters;

        public CharactersImageMatcher(CharactersManager characters) {
            this.characters = characters;
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    allCharacters[x, y] = characters.getCharacter(characters.characterNames[(x * 5) + y]);
                }
            }
        }

        private Bitmap Load(Bitmap bitmap) {
            using (Bitmap newBmp = new Bitmap(bitmap)) {
                Bitmap targetBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format32bppRgb);
                return targetBmp;
            }
        }

        private Bitmap resizeBitmap(Bitmap bitmap, Size size) {
            return Load(new Bitmap(bitmap, size));
        }

        public Character findCharacterInTournament(Bitmap compared) {
            Character foundCharacter = null;
            bool found = false;
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    Character currentCharacter = allCharacters[x, y];
                    using (Bitmap characterBitmap = resizeBitmap(currentCharacter.tournamentBitmap, compared.Size)) {
                        bool result = true;
                        for (int i = 0; i < characterBitmap.Size.Width - 1; i++) {
                            for (int j = 0; j < characterBitmap.Size.Height - 1; j++) {
                                if (characterBitmap.GetPixel(i, j) != compared.GetPixel(i, j)) {
                                    result = false;
                                    break;
                                }
                            }
                            if (result == false) break;
                        }
                        if (result) {
                            foundCharacter = currentCharacter;
                            found = true;
                            break;
                        }
                    }
                }
                if (found) break;
            }
            if (foundCharacter == null) throw new CouldNotMatchCharacterException();
                
            return foundCharacter;
        }
    }
}
