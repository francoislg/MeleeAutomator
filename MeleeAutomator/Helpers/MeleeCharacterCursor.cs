using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    using System.Drawing;
    using DolphinControllerAutomator.Controllers;
    using System.Threading.Tasks;
    using Characters;

    public class MeleeCharacterCursor : MeleeCursor {
        private static readonly Rectangle BOUNDS = new Rectangle(0, 0, 1700, 900);
        private readonly PointF RELATIVEPOSITION = new PointF(200f, 130f);
        private readonly PointF OFFSET = new PointF(100, 110);
        private readonly int LEVELBARWIDTH = 320;
        private readonly int LEVELBAROFFSET = 95;
        private int player;

        public MeleeCharacterCursor(DolphinAsyncController controller, int initialPlayer) : base(controller, BOUNDS) {
            this.controller = controller;
            setPosition(BOUNDS.Left, BOUNDS.Bottom);
            this.player = initialPlayer;
            // TODO : Add initialPlayerPosition
        }

        public async Task changeController() {
            await getTo(new PointF(45 + ((player - 1) * 420), 530));
            await controller.press(DolphinButton.A).wait(200).execute();
        }

        public async Task changeLevel(int fromLevel, int toLevel) {
            float initialPct = fromLevel * LEVELBARWIDTH / 9;
            float targetPct = toLevel * LEVELBARWIDTH / 9;
            await getTo(new PointF(LEVELBAROFFSET + initialPct + ((player - 1) * 420), 770));
            await controller.press(DolphinButton.A).execute();
            await getTo(new PointF(LEVELBAROFFSET + targetPct + ((player - 1) * 420), 770));
            await controller.press(DolphinButton.A).execute();
        }

        public async Task select(Character character) {
            await getTo(convertCharacterPosition(character.cssPosition));
            await controller.press(DolphinButton.B).then().press(DolphinButton.A).then().wait(100).execute();
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

        public async Task calibrate() {
            float x = BOUNDS.Left;
            float y = BOUNDS.Bottom;
            if (position.X < BOUNDS.Width / 2) {
                controller.hold(DolphinJoystick.LEFT);
            } else {
                x = BOUNDS.Right;
                controller.hold(DolphinJoystick.RIGHT);
            }
            if (position.Y > BOUNDS.Height / 2) {
                controller.hold(DolphinJoystick.DOWN);
            } else {
                y = BOUNDS.Top;
                controller.hold(DolphinJoystick.UP);
            }
            await controller.forMilliseconds(1500).execute();
            setPosition(x, y);
        }
    }
}
