
namespace MeleeAutomator.Helpers {
    using System;
    using DolphinControllerAutomator;

    public class VerticalMenuCursor {
        protected int initialPosition;
        protected int currentPosition;
        protected int menuElements;
        protected DolphinController controller;

        public VerticalMenuCursor(DolphinController controller, int menuElements, int initialPosition = 1) {
            this.controller = controller;
            this.menuElements = menuElements;
            this.currentPosition = initialPosition;
            this.initialPosition = initialPosition;
        }

        public void moveDown() {
            controller.press(DolphinPOVButton.DOWN);
            currentPosition = wrapY(currentPosition + 1);
        }

        public void moveUp() {
            controller.press(DolphinPOVButton.UP);
            currentPosition = wrapY(currentPosition - 1);
        }

        public void moveTo(int position) {
            if (position == currentPosition) return;
            int distanceUp = wrapY(currentPosition - position);
            int distanceDown = wrapY(position - currentPosition);
            if (distanceDown < distanceUp) {
                while (currentPosition != position) {
                    moveDown();
                }
            } else {
                while (currentPosition != position) {
                    moveUp();
                }
            }
        }

        protected int wrapY(int value) {
            if (value > menuElements) {
                return value -= menuElements;
            }else if(value < 1){
                return value += menuElements;
            }else{
                return value;
            }
        }

        public virtual void resetCursor() {
            this.currentPosition = initialPosition;
        }
    }
}
