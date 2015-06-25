using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Menus.VSMode.Melee {
    using DolphinControllerAutomator;
    using Characters;
    using Cursors;
    public class MeleePortrait {
        private readonly int NUMBEROFMOVEMENTSTORECALIBRATE = 10;
        private DolphinAsyncController controller;
        private MeleeCharacterCursor cursor;
        private int countNumberOfMovements = 0;
        private Character currentCharacter;
        private enum PortraitState {
            HMN, CPU, NA
        };

        private PortraitState currentState;
        private int level = 1;

        public MeleePortrait(DolphinAsyncController controller, int player) {
            this.controller = controller;
            this.cursor = new MeleeCharacterCursor(controller, player);
            this.currentState = PortraitState.NA;
        }

        public async Task changeToCPU() {
            switch (currentState) {
                case PortraitState.NA:
                    await cursor.changeController();
                    await cursor.changeController();
                    break;
                case PortraitState.HMN:
                    await cursor.changeController();
                    break;
                default:
                    break;
            }
            currentState = PortraitState.CPU;
        }

        public async Task changeToHuman() {
            switch (currentState) {
                case PortraitState.CPU:
                    await cursor.changeController();
                    await cursor.changeController();
                    break;
                case PortraitState.NA:
                    await cursor.changeController();
                    break;
                default:
                    break;
            }
            currentState = PortraitState.CPU;
        }

        public async Task changeToLevel(int level) {
            await changeToCPU();
            await changeCPULevel(level);
        }

        private async Task changeCPULevel(int level){
            if (this.level != level) {
                await cursor.changeLevel(this.level, level);
                this.level = level;
            }
        }

        public async Task select(Character character) {
            currentCharacter = character;
            await cursor.select(character);
            countNumberOfMovements++;
            if (countNumberOfMovements > NUMBEROFMOVEMENTSTORECALIBRATE) {
                countNumberOfMovements = 0;
                await cursor.calibrate();
            }
        }

        public async Task applyStageModifier() {
            if (currentCharacter.name == "Shiek") {
                await controller.hold(DolphinButton.A).forMilliseconds(5000).execute();
            }
        }

        public async Task forceCalibration() {
            await cursor.calibrate();
        }

        public void reset() {
            cursor.reset();
        }
    }
}
