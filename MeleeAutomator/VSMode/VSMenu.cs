using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode {
    using DolphinControllerAutomator;
    using MeleeAutomator.Helpers;
    using MeleeAutomator.VSMode.Tournament;
    using MeleeAutomator.VSMode.Melee;
    using System.Threading.Tasks;

    public class VSMenu : MeleeState<MenuSelector> {
        private VerticalMenuCursor menuCursor;

        public VSMenu(MeleeStates states, MenuSelector state) : base(states, state) {
            menuCursor = new VerticalMenuCursor(controller, 5);
        }

        public async Task<MeleeMenu> meleeMode() {
            await menuCursor.moveTo(1);
            await controller.press(DolphinButton.A).execute();
            return states.getMeleeMenu();
        }

        public async Task<TournamentMenu> tournamentMode() {
            await menuCursor.moveTo(2);
            await controller.press(DolphinButton.A).execute();
            return states.getTournamentMenu();
        }

        internal void resetCursor(){
            menuCursor.resetCursor();
        }
    }
}
