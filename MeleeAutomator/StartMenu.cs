using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DolphinControllerAutomator;

namespace MeleeAutomator {
    public class StartMenu {
        private DolphinController controller;
        private MeleeStates meleeStates;

        public StartMenu(DolphinController controller) {
            this.controller = controller;
            this.meleeStates = new MeleeStates(this, controller);
        }

        public MenuSelector pressStart(){
            controller.press(DolphinButton.A).delay(1000).press(DolphinButton.START);
            return meleeStates.getMenuSelector();
        }

        public MeleeStates getMeleeStates() {
            return meleeStates;
        }
    }
}
