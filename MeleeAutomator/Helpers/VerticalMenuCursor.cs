
namespace MeleeAutomator.Helpers {
    using System;
    using DolphinControllerAutomator;
    using System.Threading.Tasks;

    public class VerticalMenuCursor {
        protected int initialPosition;
        protected int currentPosition;
        protected int menuElements;
        protected DolphinAsyncController controller;

        public VerticalMenuCursor(DolphinAsyncController controller, int menuElements, int initialPosition = 1) {
            this.controller = controller;
            this.menuElements = menuElements;
            this.currentPosition = initialPosition;
            this.initialPosition = initialPosition;
        }

        public async Task moveDown() {
            await controller.press(DolphinPOVButton.DOWN).execute();
            currentPosition = wrapY(currentPosition + 1);
        }

        public async Task moveUp() {
            await controller.press(DolphinPOVButton.UP).execute();
            currentPosition = wrapY(currentPosition - 1);
        }

        public async Task moveTo(int position) {
            if (position == currentPosition) return;
            int distanceUp = wrapY(currentPosition - position);
            int distanceDown = wrapY(position - currentPosition);
            if (distanceDown < distanceUp) {
                while (currentPosition != position) {
                    await moveDown();
                }
            } else {
                while (currentPosition != position) {
                    await moveUp();
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
