using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DolphinControllerAutomator;

namespace MeleeAutomator.VSMode.Tournament {
    public class TournamentMenu : BaseMeleeState<VSMenu> {
        public enum Entrants {
            _02=0, 
            _04=1, 
            _08=2, 
            _12=3,
            _16=4,
            _24=-4,
            _32=-3,
            _48=-2,
            _64=-1
        }
        Entrants entrants = Entrants._64;

        public enum StageSelection {
            SingleRandom, AlwaysDifferent
        }
        StageSelection stageSelection = StageSelection.AlwaysDifferent;

        public enum CPULevel {
            Level1 = 1,
            Level2 = 2,
            Level3 = 3,
            Level4 = 4,
            Level5 = 5,
            Level6 = -4,
            Level7 = -3,
            Level8 = -2,
            Level9 = -1,
            Random = 0
        }
        CPULevel cpuLevel = CPULevel.Level9;
        GameOptions gameOptions;
        
        public TournamentMenu(MeleeStates states, VSMenu state) : base(states, state) { 
            
        }

        public TournamentMenu setNumberOfEntrants(Entrants entrants) {
            this.entrants = entrants;
            return this;
        }

        public TournamentMenu setStageSelection(StageSelection stageSelection) {
            this.stageSelection = stageSelection;
            return this;
        }

        public TournamentMenu setCPULevel(CPULevel cpuLevel) {
            this.cpuLevel = cpuLevel;
            return this;
        }

        public TournamentMenu setOptions(GameOptions gameOptions) {
            this.gameOptions = gameOptions;
            return this;
        }

        public TournamentPlayers confirm() {
            controller.press(DolphinButton.A).press(DolphinButton.A);
            confirmNumberOfEntrants();
            controller.press(DolphinPOVButton.RIGHT).press(DolphinButton.A);
            confirmStageSelection();
            confirmCPULevel();
            controller.press(DolphinButton.A);
            return new TournamentPlayers(states, this, entrantsEnumToNumber(entrants));
        }

        private void confirmNumberOfEntrants() {
            int currentEntrantsCursor = 0;
            if (entrants > 0) {
                while (currentEntrantsCursor < (int)entrants) {
                    controller.press(DolphinPOVButton.RIGHT);
                    currentEntrantsCursor++;
                }
            } else if (entrants < 0) {
                while (currentEntrantsCursor > (int)entrants) {
                    controller.press(DolphinPOVButton.LEFT);
                    currentEntrantsCursor--;
                }
            }
            controller.press(DolphinButton.A);
        }

        private void confirmStageSelection() {
            switch (stageSelection) {
                case StageSelection.AlwaysDifferent:
                    controller.press(DolphinPOVButton.RIGHT);
                    break;
                case StageSelection.SingleRandom:
                    break;
            }
            controller.press(DolphinButton.A);
        }

        private void confirmCPULevel() {
            int currentCPULevel = 0;
            if (cpuLevel > 0) {
                while (currentCPULevel < (int)cpuLevel) {
                    controller.press(DolphinPOVButton.RIGHT);
                    currentCPULevel++;
                }
            } else if (cpuLevel < 0) {
                while (currentCPULevel > (int)cpuLevel) {
                    controller.press(DolphinPOVButton.LEFT);
                    currentCPULevel--;
                }
            }
            controller.press(DolphinButton.A);
        }

        private int entrantsEnumToNumber(Entrants entrants) {
            switch (entrants) {
                case Entrants._02:
                    return 2;
                case Entrants._04:
                    return 4;
                case Entrants._08:
                    return 8;
                case Entrants._12:
                    return 12;
                case Entrants._16:
                    return 16;
                case Entrants._24:
                    return 24;
                case Entrants._32:
                    return 32;
                case Entrants._48:
                    return 48;
                case Entrants._64:
                    return 64;
                default:
                    return 1;
            }
        }
    }
}
