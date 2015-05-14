using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode.Tournament {
    using DolphinControllerAutomator;
    using MeleeAutomator.Characters;

    public class TournamentPlayers : MeleeState<TournamentMenu> {
        private int numberOfPlayers;
        private TournamentPlayer[] players;

        public TournamentPlayers(MeleeStates states, TournamentMenu state, int numberOfPlayers) : base(states, state) {
            this.numberOfPlayers = numberOfPlayers;
            this.players = new TournamentPlayer[numberOfPlayers];
            for (int i = 0; i < players.Count(); i++) {
                players[i] = new TournamentPlayer(states.getCharacters().getRandomCharacter(), "CPU" + i);
            }
        }

        public void confirm() {
            for (int i = 0; i < players.Count(); i++) {
                players[i].confirm(states, controller);
                controller.press(DolphinPOVButton.DOWN);
            }
            controller.press(DolphinButton.START).press(DolphinButton.A);
        }
    }
}
