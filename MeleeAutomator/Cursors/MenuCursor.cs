
namespace MeleeAutomator.Cursors {
    using System;
    using System.Drawing;
    using DolphinControllerAutomator;
    using System.Threading.Tasks;

    public class MenuCursor : VerticalMenuCursor {
        private int initialPositionX;
        private int currentPositionX;
        private int menuElementsX;

        public MenuCursor(DolphinAsyncController controller, Point menuElements, Point initialPosition) : base(controller, menuElements.Y, initialPosition.Y) {
            this.menuElementsX = menuElements.X;
            this.currentPositionX = initialPosition.X;
            this.initialPositionX = initialPosition.X;
        }

        public async Task moveLeft() {
            await controller.press(DolphinPOVButton.LEFT).execute();
            currentPositionX = wrapX(currentPositionX + 1);
        }

        public async Task moveRight() {
            await controller.press(DolphinPOVButton.RIGHT).execute();
            currentPositionX = wrapX(currentPositionX - 1);
        }

        public async Task moveTo(Point position) {
            await moveTo(position.Y);
            if (position == new Point(currentPositionX, currentPosition)) return;
            int distanceLeft = wrapX(currentPositionX - position.X);
            int distanceRight = wrapX(position.X - currentPositionX);
            if (distanceLeft < distanceRight) {
                while (currentPositionX != position.X) {
                    await moveLeft();
                }
            } else {
                while (currentPositionX != position.X) {
                    await moveRight();
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
