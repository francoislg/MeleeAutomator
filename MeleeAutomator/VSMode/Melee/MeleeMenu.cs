using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.VSMode.Melee {
    public class MeleeMenu : MeleeState<VSMenu> {
        public MeleeMenu(MeleeStates states, VSMenu state)
            : base(states, state) { 
            
        }
    }
}
