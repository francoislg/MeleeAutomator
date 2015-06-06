﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    using System.Drawing;
    using DolphinControllerAutomator.Controllers;
    using System.Threading.Tasks;

    public class MeleeStageCursor : MeleeCursor {
        public enum Stage {
            BattleField, FinalDestination, FountainOfDreams, YoshiStory, DreamLand, PokemonStadium
        };
        private Dictionary<Stage, PointF> stagesPositions = new Dictionary<Stage, PointF>() {
            { Stage.BattleField, new PointF(950, 665) },
            { Stage.FinalDestination, new PointF(1100, 665) },
            { Stage.FountainOfDreams, new PointF(1250, 205) },
            { Stage.YoshiStory, new PointF(1050, 205) },
            { Stage.DreamLand, new PointF(1250, 665) },
            { Stage.PokemonStadium, new PointF(1350, 400) }
        };
        private static readonly Rectangle BOUNDS = new Rectangle(0, 0, 1700, 900);

        public MeleeStageCursor(DolphinAsyncController controller)
            : base(controller, BOUNDS) {
            this.controller = controller;
            setPosition(925, 740);
        }

        public async Task select(Stage stage) {
            await getTo(stagesPositions[stage]);
        }
    }
}
