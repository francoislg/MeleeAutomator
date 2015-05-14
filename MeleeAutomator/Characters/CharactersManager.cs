using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Characters {
    using System.Drawing;

    public class CharactersManager {
        private Dictionary<String, Character> characters = new Dictionary<string,Character>();
        private Dictionary<String, Point> charactersTournamentPosition = new Dictionary<string, Point>();
        private Random randomizer;
        public readonly string[] characterNames = { 
            "CaptainFalcon", "DK", "Fox", "Kirby", "Bowser", 
            "Link", "Mario", "Ness", "Pikachu", "IceClimbers", 
            "Zelda", "Yoshi", "Samus", "Peach", "GameAndWatch", 
            "DrMario", "Luigi", "Jigglypuff", "Mewtwo", "Marth",
            "Ganondorf", "YoungLink", "Falco", "Pichu", "Roy"
        };

        public CharactersManager() {
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {
                    charactersTournamentPosition.Add(characterNames[(5 * x) + y], new Point(x + 1, y + 1));
                }
            }
        }
        
        public Character getCharacter(string name) {
            if (!characters.ContainsKey(name)) {
                Character character = new Character(name);
                characters.Add(name, character);
            }
            return characters[name];
        }

        public Character getRandomCharacter() {
            if (randomizer == null) {
                randomizer = new Random();
            }
            int randomNumber = randomizer.Next(0, characterNames.Count());
            return getCharacter(characterNames[randomNumber]);
        }

        public Point getTournamentPosition(Character character) {
            return charactersTournamentPosition[character.getName()];
        }
    }
}
