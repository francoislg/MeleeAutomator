using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DolphinControllerAutomator;
using System.Threading.Tasks;

namespace MeleeAutomator {
    public class StartMenu {
        private DolphinAsyncController controller;
        private MeleeStates meleeStates;

        public StartMenu(DolphinAsyncController controller) {
            this.controller = controller;
            this.meleeStates = new MeleeStates(this, controller);
        }

        public async Task<MenuSelector> pressStart(){
            await controller.hold(DolphinButton.A).forMilliseconds(1000).then().press(DolphinButton.START).execute();
            return meleeStates.getMenuSelector();
        }

        public MeleeStates getMeleeStates() {
            return meleeStates;
        }
    }
}
