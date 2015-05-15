using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    using Characters;
    using System.Drawing;
    using DolphinControllerAutomator.Controllers;
    using System.Threading.Tasks;

    public class MeleeCursor {
        private readonly Rectangle BOUNDS = new Rectangle(0, 0, 1820, 1000);
        private readonly PointF CURSORSPEEDPER100MS = new PointF(165f, 165f);
        private readonly PointF RELATIVEPOSITION = new PointF(165f, 128f);
        private readonly PointF OFFSET = new PointF(100, 70);
        private DolphinAsyncController controller;
        private PointF position;

        public MeleeCursor(DolphinAsyncController controller) : this(controller, 1) { }

        public MeleeCursor(DolphinAsyncController controller, int initialPlayer) {
            this.controller = controller;
            setPosition(BOUNDS.Left, BOUNDS.Height);
            // Player doesn't do anything yet.
        }

        public async Task getTo(Character character) {
            PointF targetPosition = convertCharacterPosition(character.cssPosition);
            if (position.X < targetPosition.X) {
                int waitTime = msToTarget(position.X, targetPosition.X, CURSORSPEEDPER100MS.X);
                controller.hold(DolphinJoystick.RIGHT).forMilliseconds(waitTime);
                position.X = targetPosition.X;
            } else if (position.X > targetPosition.X) {
                int waitTime = msToTarget(position.X, targetPosition.X, CURSORSPEEDPER100MS.X);
                controller.hold(DolphinJoystick.LEFT).forMilliseconds(waitTime);
                position.X = targetPosition.X;
            }
            if (position.Y > targetPosition.Y) {
                int waitTime = msToTarget(position.Y, targetPosition.Y, CURSORSPEEDPER100MS.Y);
                controller.hold(DolphinJoystick.UP).forMilliseconds(waitTime);
                position.Y = targetPosition.Y;
            } else if (position.Y < targetPosition.Y) {
                int waitTime = msToTarget(position.Y, targetPosition.Y, CURSORSPEEDPER100MS.Y);
                controller.hold(DolphinJoystick.DOWN).forMilliseconds(waitTime);
                position.Y = targetPosition.Y;
            }
            await controller.then().press(DolphinButton.B).then().press(DolphinButton.A).execute();
            float dummy = targetPosition.X;
        }

        private int msToTarget(float position, float target, float speed) {
            float distance = Math.Abs(position - target);
            return (int)(distance / speed * 100);
        }

        private PointF convertCharacterPosition(Point position) {
            return addOffset(getRelativeCharacterPosition(position));
        }

        private PointF addOffset(PointF position) {
            return new PointF(position.X + OFFSET.X, position.Y + OFFSET.Y);
        }

        private PointF getRelativeCharacterPosition(Point position) {
            return new PointF(position.X * RELATIVEPOSITION.X, position.Y * RELATIVEPOSITION.Y);
        }

        private void setPosition(float x, float y) {
            position = new PointF(x, y);
        }

        public async Task calibrate() {
            setPosition(BOUNDS.Left, BOUNDS.Height);
            await controller.hold(DolphinJoystick.DOWN).hold(DolphinJoystick.LEFT).forMilliseconds(1500).execute();
        }
    }
}
