using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    using Characters;
    public class MeleePortrait {
        private readonly int NUMBEROFMOVEMENTSTORECALIBRATE = 10;
        private MeleeCharacterCursor cursor;
        private int countNumberOfMovements = 0;
        private enum PortraitState {
            HMN, CPU, NA
        };

        private PortraitState currentState;
        private int level = 1;

        public MeleePortrait(MeleeCharacterCursor cursor) {
            this.cursor = cursor;
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

        public async Task getTo(Character character) {
            await cursor.select(character);
            countNumberOfMovements++;
            if (countNumberOfMovements > NUMBEROFMOVEMENTSTORECALIBRATE) {
                countNumberOfMovements = 0;
                await cursor.calibrate();
            }
        }

        public async Task forceCalibration() {
            await cursor.calibrate();
        }
    }
}
