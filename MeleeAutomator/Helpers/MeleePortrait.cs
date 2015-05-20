using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    public class MeleePortrait {
        private readonly int LEVELBARWIDTH = 320;
        private readonly int LEVELBAROFFSET = 95;
        private MeleeCursor cursor;
        private DolphinAsyncController controller;
        private int player;
        private enum PortraitState {
            HMN, CPU, NA
        };

        private PortraitState currentState;
        private int level = 1;

        public MeleePortrait(MeleeCursor cursor, DolphinAsyncController controller, int player) {
            this.cursor = cursor;
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
    }
}
