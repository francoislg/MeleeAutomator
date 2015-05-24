using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DolphinControllerAutomator;

namespace MeleeAutomator.Options {
    public class OptionsMenu : MeleeState<MenuSelector> {
        public enum MatchType {
            Time=0,
            Stock=1,
            Coin=2,
            Bonus=3
        }

        private int stocks;
        private float damageRatio;

        private MatchType currentType;
        
        public OptionsMenu(MeleeStates states, MenuSelector state) : base(states, state) { }

        public void setMatchType(MatchType type) {
            currentType = type;
        }

        public void setStocks(int stocks){
            if (stocks < 1 || stocks > 99) {
                throw new ArgumentOutOfRangeException("Stocks should be between 1 and 99");
            }
            setMatchType(MatchType.Stock);
            this.stocks = stocks;
        }

        public void setDamageRatio(float damageRatio) {
            if (damageRatio < 0.5 || damageRatio > 2) {
                throw new ArgumentOutOfRangeException("damageRatio should be between 0.5 and 2");
            }
            this.damageRatio = damageRatio;
        }
    }
}
