
namespace MeleeAutomator.Helpers {
    using System;
    using System.Drawing;
    using DolphinControllerAutomator;

    public class MenuCursor : VerticalMenuCursor {
        private int initialPositionX;
        private int currentPositionX;
        private int menuElementsX;

        public MenuCursor(DolphinController controller, Point menuElements, Point initialPosition) : base(controller, menuElements.Y, initialPosition.Y) {
            this.menuElementsX = menuElements.X;
            this.currentPositionX = initialPosition.X;
            this.initialPositionX = initialPosition.X;
        }

        public void moveLeft() {
            controller.press(DolphinPOVButton.LEFT);
            currentPositionX = wrapX(currentPositionX + 1);
        }

        public void moveRight() {
            controller.press(DolphinPOVButton.RIGHT);
            currentPositionX = wrapX(currentPositionX - 1);
        }

        public void moveTo(Point position) {
            moveTo(position.Y);
            if (position == new Point(currentPositionX, currentPosition)) return;
            int distanceLeft = wrapX(currentPositionX - position.X);
            int distanceRight = wrapX(position.X - currentPositionX);
            if (distanceLeft < distanceRight) {
                while (currentPositionX != position.X) {
                    moveLeft();
                }
            } else {
                while (currentPositionX != position.X) {
                    moveRight();
                }
            }
        }

        protected int wrapX(int value) {
            if (value > menuElementsX) {
                return value -= menuElementsX;
            }else if(value < 1){
                return value += menuElementsX;
            }else{
                return value;
            }
        }

        public override void resetCursor() {
            this.currentPositionX = initialPositionX;
            base.resetCursor();
        }
    }
}
