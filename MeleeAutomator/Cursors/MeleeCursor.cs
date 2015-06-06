using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Cursors {
    using DolphinControllerAutomator;
    using System.Drawing;
    using DolphinControllerAutomator.Controllers;
    using System.Threading.Tasks;

    public class MeleeCursor {
        private readonly PointF CURSORSPEEDPER100MS = new PointF(210f, 150f);
        private readonly float DIAGONALMULTIPLICATOR = 1.5f;
        protected DolphinAsyncController controller;
        protected PointF position;
        private readonly Rectangle bounds;

        public MeleeCursor(DolphinAsyncController controller, Rectangle bounds) {
            this.controller = controller;
            this.bounds = bounds;
        }

        protected async Task getTo(PointF targetPosition) {
            float waitTimeX = msToTarget(position.X, targetPosition.X, CURSORSPEEDPER100MS.X);
            float waitTimeY = msToTarget(position.Y, targetPosition.Y, CURSORSPEEDPER100MS.Y);
            float diagonalDelta = waitTimeX - waitTimeY;

            if (diagonalDelta != 0) {
                waitTimeX *= DIAGONALMULTIPLICATOR;
                waitTimeY *= DIAGONALMULTIPLICATOR;
            }
            if (diagonalDelta > 0) {
                waitTimeX -= Math.Abs(diagonalDelta * 0.5f);
            } else if (diagonalDelta < 0) {
                waitTimeY -= Math.Abs(diagonalDelta * 0.5f);
            }

            if (position.X < targetPosition.X) {
                controller.hold(DolphinJoystick.RIGHT).forMilliseconds((int)waitTimeX);
            } else if (position.X > targetPosition.X) {
                controller.hold(DolphinJoystick.LEFT).forMilliseconds((int)waitTimeX);
            }
            if (position.Y > targetPosition.Y) {
                controller.hold(DolphinJoystick.UP).forMilliseconds((int)waitTimeY);
            } else if (position.Y < targetPosition.Y) {
                controller.hold(DolphinJoystick.DOWN).forMilliseconds((int)waitTimeY);
            }
            await controller.execute();
            position = targetPosition;
            clamp();
        }


        private void clamp() {
            if (position.X < bounds.Left) {
                position.X = bounds.Left;
            }
            if (position.X > bounds.Right) {
                position.X = bounds.Right;
            }
            if (position.Y < bounds.Top) {
                position.Y = bounds.Top;
            }
            if (position.Y > bounds.Bottom) {
                position.Y = bounds.Bottom;
            }
        }

        protected float msToTarget(float position, float target, float speed) {
            float distance = Math.Abs(position - target);
            return distance * 100 / speed;
        }

        protected void setPosition(float x, float y) {
            position = new PointF(x, y);
        }
    }
}
