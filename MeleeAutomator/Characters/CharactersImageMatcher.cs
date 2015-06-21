// Comparing bitmap from :
// http://www.dotnetexamples.com/2012/07/fast-bitmap-comparison-c.html

namespace MeleeAutomator.Characters {
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using MeleeAutomator.Characters;
    using Images;

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

        public Character findCharacterInTournament(Bitmap compared) {
            Character foundCharacter = null;
            bool found = false;
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    Character currentCharacter = allCharacters[x, y];
                    using (Bitmap characterBitmap = ImageHelper.resize(currentCharacter.tournamentBitmap, compared.Size)) {
                        if (ImageHelper.areSimilar(characterBitmap, compared)) {
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
