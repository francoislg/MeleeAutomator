using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DolphinControllerAutomator;

namespace MeleeAutomator.Options {
    public class OptionsMenu : MeleeState<MenuSelector> {
        public OptionsMenu(MeleeStates states, MenuSelector state) : base(states, state) { }
    }
}
