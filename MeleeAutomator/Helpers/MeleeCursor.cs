using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    using System.Drawing;
    using DolphinControllerAutomator.Controllers;
    using System.Threading.Tasks;

    public class MeleeCursor {
        private readonly Rectangle BOUNDS = new Rectangle(0, 0, 1700, 900);
        private readonly PointF CURSORSPEEDPER100MS = new PointF(210f, 150f);
        private readonly float DIAGONALMULTIPLICATOR = 1.5f;
        private DolphinAsyncController controller;
        private int player;
        private PointF position;

        public MeleeCursor(DolphinAsyncController controller, int initialPlayer) {
            this.controller = controller;
            setPosition(BOUNDS.Left, BOUNDS.Bottom);
            this.player = initialPlayer;
            // TODO : Add initialPlayerPosition
        }

        public async Task getTo(PointF targetPosition) {
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
            if (position.X < BOUNDS.Left) {
                position.X = BOUNDS.Left;
            }
            if (position.X > BOUNDS.Right) {
                position.X = BOUNDS.Right;
            }
            if (position.Y < BOUNDS.Top) {
                position.Y = BOUNDS.Top;
            }
            if (position.Y > BOUNDS.Bottom) {
                position.Y = BOUNDS.Bottom;
            }
        }

        private float msToTarget(float position, float target, float speed) {
            float distance = Math.Abs(position - target);
            return distance * 100 / speed;
        }

        private void setPosition(float x, float y) {
            position = new PointF(x, y);
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
