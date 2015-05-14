using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeleeAutomator.Helpers {
    public class MeleeCursor {
        private float CURSORSPEED = 1.0f;
        public float positionX;
        public float positionY;

        public MeleeCursor() : this(1) { }

        public MeleeCursor(int initialPlayer) {
            setPosition(0, 0);
            calibrate();
        }

        private void setPosition(float x, float y) {
            positionX = x;
            positionY = y;
        }

        public void calibrate() {
            
        }
    }
}
