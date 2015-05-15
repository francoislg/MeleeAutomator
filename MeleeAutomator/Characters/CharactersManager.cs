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
        private readonly Dictionary<String, Point> cssPosition = new Dictionary<string, Point>() {
            {"DrMario", new Point(0,0) }, {"Mario", new Point(1,0) },{"Luigi", new Point(2,0) }, {"Bowser", new Point(3,0) }, {"Peach", new Point(4,0) }, {"Yoshi", new Point(5,0) }, {"DK", new Point(6,0) }, {"CaptainFalcon", new Point(7,0) }, {"Ganondorf", new Point(8,0) }, 
            {"Falco", new Point(0,1) }, {"Fox", new Point(1,1) },{"Ness", new Point(2,1) }, {"IceClimbers", new Point(3,1) }, {"Kirby", new Point(4,1) }, {"Samus", new Point(5,1) }, {"Zelda", new Point(6,1) }, {"Shiek", new Point(6,1) }, {"Link", new Point(7,1) }, {"YoungLink", new Point(8,1) }, 
                {"Pichu", new Point(1,2) },  {"Pikachu", new Point(2,2) },  {"Jigglypuff", new Point(3,2) },  {"Mewtwo", new Point(4,2) },  {"GameAndWatch", new Point(5,2) },  {"Marth", new Point(6,2) },  {"Roy", new Point(7,2) }
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
                Character character = new Character(name, charactersTournamentPosition[name], cssPosition[name]);
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
    }
}
