using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Menus.VSMode.Melee {
    public class FinishedDuelMatch {
        public MeleePlayer winner { get; private set; }
        public MeleePlayer loser { get; private set; }
        public FinishedDuelMatch(MeleePlayer winner, MeleePlayer loser) {
            this.winner = winner;
            this.loser = loser;
        }
    }
}
