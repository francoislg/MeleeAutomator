using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode {
    using DolphinControllerAutomator;
    using MeleeAutomator.Helpers;
    using MeleeAutomator.VSMode.Tournament;
    using MeleeAutomator.VSMode.Melee;

    public class VSMenu : MeleeState<MenuSelector> {
        private VerticalMenuCursor menuCursor;

        public VSMenu(MeleeStates states, MenuSelector state) : base(states, state) {
            menuCursor = new VerticalMenuCursor(controller, 5);
        }

        public MeleeMenu meleeMode() {
            menuCursor.moveTo(1);
            controller.press(DolphinButton.A);
            return states.getMeleeMenu();
        }

        public TournamentMenu tournamentMode() {
            menuCursor.moveTo(2);
            controller.press(DolphinButton.A);
            return states.getTournamentMenu();
        }

        internal void resetCursor(){
            menuCursor.resetCursor();
        }
    }
}
