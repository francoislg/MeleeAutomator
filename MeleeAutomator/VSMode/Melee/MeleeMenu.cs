using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode.Melee {
    using MeleeAutomator.Cursors;
    using MeleeAutomator.Characters;
    using MeleeAutomator.VSMode;

    public class MeleeMenu : BaseMeleeState<VSMenu> {
        private MeleePortrait[] portraits;
        public MeleeMenu(MeleeStates states, VSMenu state)
            : base(states, state) {
            portraits = new MeleePortrait[] {
                new MeleePortrait(new MeleeCharacterCursor(states.controllers[0], 1)),
                new MeleePortrait(new MeleeCharacterCursor(states.controllers[1], 2))
            };
        }
    }
}
