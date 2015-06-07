using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode.Tournament {
    using DolphinControllerAutomator;
    using MeleeAutomator.Characters;
    using System.Threading.Tasks;

    public class TournamentPlayers : BaseMeleeState<TournamentMenu> {
        private int numberOfPlayers;
        private TournamentPlayer[] players;

        public TournamentPlayers(MeleeStates states, TournamentMenu state, int numberOfPlayers) : base(states, state) {
            this.numberOfPlayers = numberOfPlayers;
            this.players = new TournamentPlayer[numberOfPlayers];
            for (int i = 0; i < players.Count(); i++) {
                players[i] = new TournamentPlayer(states.characters.getRandomCharacter(), "CPU" + i);
            }
        }

        public async Task confirm() {
            for (int i = 0; i < players.Count(); i++) {
                await players[i].confirm(states, mainController);
                await mainController.press(DolphinPOVButton.DOWN).execute();
            }
            await mainController.press(DolphinButton.START).then().press(DolphinButton.A).execute();
        }
    }
}
