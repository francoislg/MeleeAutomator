using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    using Characters;
using System.Drawing;

    public class MeleeCursor {
        private readonly Rectangle BOUNDS = new Rectangle(0, 0, 1820, 960);
        private readonly PointF CURSORSPEEDPER100MS = new PointF(205f, 170f);
        private readonly PointF RELATIVEPOSITION = new PointF(180f, 128f);
        private readonly PointF OFFSET = new PointF(100, 80);
        private DolphinController controller;
        private PointF position;

        public MeleeCursor(DolphinController controller) : this(controller, 1) { }

        public MeleeCursor(DolphinController controller, int initialPlayer) {
            this.controller = controller;
            setPosition(BOUNDS.Left, BOUNDS.Height);
            // Player doesn't do anything yet.
        }

        public void getTo(Character character) {
            PointF targetPosition = convertCharacterPosition(character.getMeleeSelectionScreenPosition());
            if (position.X < targetPosition.X) {
                int waitTime = msToTarget(position.X, targetPosition.X, CURSORSPEEDPER100MS.X);
                controller.joystickRight().forMilliseconds(waitTime);
                position.X = targetPosition.X;
            }
            while (position.Y > targetPosition.Y) {
                int waitTime = msToTarget(position.Y, targetPosition.Y, CURSORSPEEDPER100MS.Y);
                controller.joystickUp().forMilliseconds(waitTime);
                position.Y = targetPosition.Y;
            }
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
            position = new PointF(x,y);
        }

        public void calibrate() {
            setPosition(BOUNDS.Left, BOUNDS.Height);
            controller.joystickDown().joystickLeft().forMilliseconds(1000);
        }
    }
}
