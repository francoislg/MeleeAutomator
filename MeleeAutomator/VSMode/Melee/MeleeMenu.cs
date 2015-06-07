using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode.Melee {
    using DolphinControllerAutomator;
    using MeleeAutomator.Cursors;
    using MeleeAutomator.Characters;
    using MeleeAutomator.Stages;
    using MeleeAutomator.VSMode;
    using System.Threading.Tasks;

    public class MeleeMenu : BaseMeleeState<VSMenu> {
        private MeleePlayer[] players = new MeleePlayer[2];
        private MeleePortrait[] portraits;
        private MeleeStageCursor stageCursor;
        private Stage stage = Stage.BattleField;
        private int numberOfPlayers = 2;

        public MeleeMenu(MeleeStates states, VSMenu state)
            : base(states, state) {
            portraits = new MeleePortrait[] {
                new MeleePortrait(new MeleeCharacterCursor(states.controllers[0], 1)),
                new MeleePortrait(new MeleeCharacterCursor(states.controllers[1], 2))
            };
            stageCursor = new MeleeStageCursor(mainController);
        }

        public MeleeMenu setPlayerOnPort(MeleePlayer player, int port) {
            if (port < 1 || port > numberOfPlayers) {
                throw new ArgumentOutOfRangeException("Player number must be between 1 and " + numberOfPlayers);
            }
            int playerIndex = port - 1;
            players[playerIndex] = player;
            return this;
        }

        public MeleeMenu setStage(Stage stage) {
            this.stage = stage;
            return this;
        }

        public override void reset() {
            base.reset();
        }

        public async Task<FinishedDuelMatch> confirm() {
            await Task.WhenAll(
                confirmPlayer(0),
                confirmPlayer(1)
            );
            await states.mainController.press(DolphinButton.START).wait(1000).execute();
            await stageCursor.select(stage);
            await states.mainController.press(DolphinButton.A).execute();
            ActiveDuelMatch match = new ActiveDuelMatch(players[0], players[1], states.dolphinWindowCapturer);
            FinishedDuelMatch finishedMatch = await match.finish();
            await mainController.press(DolphinButton.A).execute();
            return finishedMatch;
        }

        private async Task confirmPlayer(int i) {
            if (i < numberOfPlayers) {
                await portraits[i].forceCalibration();
                await portraits[i].changeToCPU();
                await portraits[i].changeToLevel(9);
                await portraits[i].select(players[i].character);
            }
        }
    }
}
