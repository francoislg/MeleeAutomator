using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Menus.VSMode.Tournament {
    using System.Drawing;
    using StateEngine;
    using DolphinControllerAutomator;
    using MeleeAutomator.Characters;
    using MeleeAutomator.Cursors;
    using System.Threading.Tasks;

    public class TournamentPlayer {
        private Character currentCharacter;
        private String name;
        
        public TournamentPlayer(Character character, string name) {
            this.name = name;
            this.currentCharacter = character;
        }

        public async Task confirm(MeleeStates states, DolphinAsyncController controller) {
            Bitmap portrait = states.dolphinWindowCapturer.captureCPUTournamentPortrait();
            Character newCharacter = states.imageMatcher.findCharacterInTournament(portrait);
            controller.press(DolphinButton.A);
            MenuCursor menuCursor = new MenuCursor(controller, new Point(5, 5), currentCharacter.tournamentPosition);
            await menuCursor.moveTo(newCharacter.tournamentPosition);
            await controller.press(DolphinButton.A).then().press(DolphinPOVButton.RIGHT).then().press(DolphinButton.A).execute();
            // Ici le textMenuCursor !
            await controller.press(DolphinButton.B).then().press(DolphinPOVButton.LEFT).execute();
        }
    }
}
