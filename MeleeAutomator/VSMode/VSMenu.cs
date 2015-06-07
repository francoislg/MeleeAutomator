using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode {
    using DolphinControllerAutomator;
    using MeleeAutomator.Cursors;
    using Options;
    using MeleeAutomator.VSMode.Tournament;
    using MeleeAutomator.VSMode.Melee;
    using System.Threading.Tasks;

    public class VSMenu : BaseMeleeState<MenuSelector> {
        private VerticalMenuCursor menuCursor;

        public VSMenu(MeleeStates states, MenuSelector state) : base(states, state) {
            menuCursor = new VerticalMenuCursor(mainController, 5);
        }

        public async Task<MeleeMenu> meleeMode() {
            await menuCursor.moveTo(1);
            await mainController.press(DolphinButton.A).execute();
            return states.meleeMenu;
        }

        public async Task<OptionsMenu> optionsMenu() {
            await menuCursor.moveTo(4);
            await mainController.press(DolphinButton.A).execute();
            return states.optionsMenu;
        }

        public async Task<TournamentMenu> tournamentMode() {
            await menuCursor.moveTo(2);
            await mainController.press(DolphinButton.A).execute();
            return states.tournamentMenu;
        }

        public override void reset() {
            menuCursor.resetCursor();
        }
    }
}
