﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator {
    using DolphinControllerAutomator;
    using MeleeAutomator.Cursors;
    using MeleeAutomator.VSMode;
    using MeleeAutomator.VSMode.Tournament;
    using MeleeAutomator.VSMode.Melee;
    using MeleeAutomator.Options;
    using System.Threading.Tasks;

    public class MenuSelector : BaseMeleeState<StartMenu> {
        private VerticalMenuCursor menuCursor;

        public MenuSelector(MeleeStates states, StartMenu state) : base(states, state) {
            this.menuCursor = new VerticalMenuCursor(mainController, 5);
        }

        public async Task<VSMenu> versus() {
            await menuCursor.moveTo(2);
            await mainController.press(DolphinButton.A).execute();
            return states.vsMenu;
        }

        public async Task<OptionsMenu> options() {
            await menuCursor.moveTo(4);
            await mainController.press(DolphinButton.A).execute();
            return states.optionsMenu;
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
