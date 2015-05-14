using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode.Tournament {
    using System.Drawing;

    using DolphinControllerAutomator;
    using MeleeAutomator.Characters;
    using MeleeAutomator.Helpers;

    public class TournamentPlayer {
        private Character character;
        private String name;
        
        public TournamentPlayer(Character character, string name) {
            this.name = name;
            this.character = character;
        }

        public void confirm(MeleeStates states, DolphinController controller){
            Bitmap portrait = states.getWindowCapture().captureCPUTournamentPortrait();
            Character currentCharacter = states.getCharactersImageMatcher().findCharacterInTournament(portrait);
            Point currentPosition = states.getCharacters().getTournamentPosition(currentCharacter);
            Point destination = states.getCharacters().getTournamentPosition(character);
            controller.press(DolphinButton.A);
            MenuCursor menuCursor = new MenuCursor(controller, new Point(5, 5), currentPosition);
            menuCursor.moveTo(destination);
            controller.press(DolphinButton.A).press(DolphinPOVButton.RIGHT).press(DolphinButton.A);
            // Ici le textMenuCursor !
            controller.press(DolphinButton.B).press(DolphinPOVButton.LEFT);
        }
    }
}
