using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Cursors {
    using DolphinControllerAutomator;
    using System.Drawing;
    using DolphinControllerAutomator.Controllers;
    using System.Threading.Tasks;
    using Stages;

    public class MeleeStageCursor : MeleeCursor {

        private Dictionary<Stage, PointF> stagesPositions = new Dictionary<Stage, PointF>() {
            { Stage.BattleField, new PointF(950, 665) },
            { Stage.FinalDestination, new PointF(1100, 665) },
            { Stage.FountainOfDreams, new PointF(1250, 205) },
            { Stage.YoshiStory, new PointF(1050, 205) },
            { Stage.DreamLand, new PointF(1250, 665) },
            { Stage.PokemonStadium, new PointF(1350, 400) }
        };
        private static readonly Rectangle BOUNDS = new Rectangle(0, 0, 1700, 900);
        private Random rand;

        public MeleeStageCursor(DolphinAsyncController controller)
            : base(controller, BOUNDS) {
            this.controller = controller;
            reset();
            rand = new Random();
        }

        public async Task selectRandom() {
            Stage randomStage = stagesPositions.ElementAt(rand.Next(0, stagesPositions.Count)).Key;
            await select(randomStage);
        }

        public async Task select(Stage stage) {
            await getTo(stagesPositions[stage]);
        }

        public void reset() {
            setPosition(925, 740);
        }
    }
}
