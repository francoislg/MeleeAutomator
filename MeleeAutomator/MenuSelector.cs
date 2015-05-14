using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator {
    using DolphinControllerAutomator;
    using MeleeAutomator.Helpers;
    using MeleeAutomator.VSMode;
    using MeleeAutomator.VSMode.Tournament;
    using MeleeAutomator.VSMode.Melee;
    using MeleeAutomator.Options;

    public class MenuSelector : MeleeState<StartMenu> {
        private VerticalMenuCursor menuCursor;

        public MenuSelector(MeleeStates states, StartMenu state) : base(states, state) {
            this.menuCursor = new VerticalMenuCursor(controller, 5);
        }

        public VSMenu versus() {
            menuCursor.moveTo(2);
            controller.press(DolphinButton.A);
            return states.getVSMenu();
        }

        public OptionsMenu options() {
            menuCursor.moveTo(4);
            controller.press(DolphinButton.A);
            return states.getOptionsMenu();
        }

        public TournamentMenu tournamentmode() {
            return versus().tournamentMode();
        }

        public MeleeMenu meleeMode() {
            return versus().meleeMode();
        }
    }
}
