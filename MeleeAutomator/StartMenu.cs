using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DolphinControllerAutomator;
using System.Threading.Tasks;

namespace MeleeAutomator {
    public class StartMenu : MeleeState {
        private DolphinAsyncController controller;
        public MeleeStates meleeStates { get; private set; }

        public StartMenu(DolphinAsyncController[] controllers) {
            this.meleeStates = new MeleeStates(this, controllers);
            this.controller = this.meleeStates.mainController;
        }

        public void reset() {}

        public async Task<MenuSelector> pressStart(){
            await controller.hold(DolphinButton.A).forMilliseconds(1000).then().press(DolphinButton.START).execute();
            return meleeStates.menuSelector;
        }
    }
}
