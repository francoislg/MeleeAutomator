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
    using System.Threading.Tasks;

    public class MenuSelector : MeleeState<StartMenu> {
        private VerticalMenuCursor menuCursor;

        public MenuSelector(MeleeStates states, StartMenu state) : base(states, state) {
            this.menuCursor = new VerticalMenuCursor(controller, 5);
        }

        public async Task<VSMenu> versus() {
            await menuCursor.moveTo(2);
            await controller.press(DolphinButton.A).execute();
            return states.getVSMenu();
        }

        public async Task<OptionsMenu> options() {
            await menuCursor.moveTo(4);
            await controller.press(DolphinButton.A).execute();
            return states.getOptionsMenu();
        }

        public async Task<TournamentMenu> tournamentmode() {
            VSMenu vsMenu = await versus();
            return await vsMenu.tournamentMode();
        }

        public async Task<MeleeMenu> meleeMode() {
            VSMenu vsMenu = await versus();
            return await vsMenu.meleeMode();
        }
    }
}
