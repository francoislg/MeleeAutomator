using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Helpers {
    using DolphinControllerAutomator;
    using System.Drawing;
    using DolphinControllerAutomator.Controllers;
    using System.Threading.Tasks;

    public class MeleeStageCursor : MeleeCursor {
        private static readonly Rectangle BOUNDS = new Rectangle(0, 0, 1700, 900);

        public MeleeStageCursor(DolphinAsyncController controller)
            : base(controller, BOUNDS) {
            this.controller = controller;
            setPosition(BOUNDS.Left, BOUNDS.Bottom);
        }
    }
}
