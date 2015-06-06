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
        private Character[] characters = new Character[2];
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
            stageCursor = new MeleeStageCursor(states.mainController);
        }

        public MeleeMenu setCharacter(int player, Character character) {
            if (player < 1 || player > numberOfPlayers) {
                throw new ArgumentOutOfRangeException("Player number must be between 1 and " + numberOfPlayers);
            }
            int playerIndex = player - 1;
            characters[playerIndex] = character;
            return this;
        }

        public MeleeMenu setStage(Stage stage) {
            this.stage = stage;
            return this;
        }

        public override void reset() {
            base.reset();

        }

        public async Task confirm() {
            await Task.WhenAll(
                confirmPlayer(0),
                confirmPlayer(1)
            );
            await states.mainController.press(DolphinButton.START).wait(1000).execute();
            await stageCursor.select(stage);
            await states.mainController.press(DolphinButton.A).execute();
        }

        private async Task confirmPlayer(int i) {
            if (i < numberOfPlayers) {
                await portraits[i].forceCalibration();
                await portraits[i].changeToCPU();
                await portraits[i].changeToLevel(9);
                await portraits[i].select(characters[i]);
            }
        }
    }
}
