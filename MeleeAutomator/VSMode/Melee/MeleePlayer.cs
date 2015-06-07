using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.VSMode.Melee {
    using Characters;
    public class MeleePlayer {
        public Character character { get; private set; }
        public String name { get; private set; }
        public MeleePlayer(Character character, string name) {
            this.character = character;
            this.name = name;
        }

        public override string ToString() {
            return name + " with " + character;
        }
    }
}
