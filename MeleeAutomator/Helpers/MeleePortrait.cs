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
        private readonly PointF RELATIVEPOSITION = new PointF(200f, 130f);
        private readonly PointF OFFSET = new PointF(100, 110);
        private readonly int LEVELBARWIDTH = 320;
        private readonly int LEVELBAROFFSET = 95;
        private MeleeCursor cursor;
        private DolphinAsyncController controller;
        private int player;
        private int countNumberOfMovements = 0;
        private enum PortraitState {
            HMN, CPU, NA
        };

        private PortraitState currentState;
        private int level = 1;

        public MeleePortrait(DolphinAsyncController controller, int player) {
            this.cursor = new MeleeCursor(controller, player);
            this.controller = controller;
            this.player = player;
            this.currentState = PortraitState.NA;
        }

        public async Task changeToCPU() {
            switch (currentState) {
                case PortraitState.NA:
                    await changeController();
                    await changeController();
                    break;
                case PortraitState.HMN:
                    await changeController();
                    break;
                default:
                    break;
            }
            currentState = PortraitState.CPU;
        }

        private async Task changeController() {
            await cursor.getTo(new PointF(45 + ((player - 1) * 420), 530));
            await controller.press(DolphinButton.A).execute();
        }

        public async Task changeToLevel(int level) {
            await changeToCPU();
            await changeCPULevel(level);
        }

        private async Task changeCPULevel(int level){
            if (this.level != level) {
                float initialPct = this.level * LEVELBARWIDTH / 9;
                float targetPct = level * LEVELBARWIDTH / 9;
                await cursor.getTo(new PointF(LEVELBAROFFSET + initialPct + ((player - 1) * 420), 770));
                await controller.press(DolphinButton.A).execute();
                await cursor.getTo(new PointF(LEVELBAROFFSET + targetPct + ((player - 1) * 420), 770));
                await controller.press(DolphinButton.A).execute();
                this.level = level;
            }
        }

        public async Task getTo(Character character) {
            await cursor.getTo(convertCharacterPosition(character.cssPosition));
            await controller.press(DolphinButton.B).then().press(DolphinButton.A).then().wait(100).execute();
            countNumberOfMovements++;
            if (countNumberOfMovements > NUMBEROFMOVEMENTSTORECALIBRATE) {
                countNumberOfMovements = 0;
                await cursor.calibrate();
            }
        }

        public async Task forceCalibration() {
            await cursor.calibrate();
        }

        private PointF convertCharacterPosition(Point position) {
            return addOffset(getRelativeCharacterPosition(position));
        }

        private PointF addOffset(PointF position) {
            return new PointF(position.X + OFFSET.X, position.Y + OFFSET.Y);
        }

        private PointF getRelativeCharacterPosition(Point charPosition) {
            return new PointF(charPosition.X * RELATIVEPOSITION.X, charPosition.Y * RELATIVEPOSITION.Y);
        }
    }
}
