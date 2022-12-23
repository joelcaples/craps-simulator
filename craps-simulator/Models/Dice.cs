using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.Models {
    public class Dice {

        private readonly short _die1;
        private readonly short _die2;

        public Dice(short die1, short die2) {
            _die1 = die1;
            _die2 = die2;
        }

        public short Die1 { 
            get {
                return _die1;
            }
        }

        public short Die2 {
            get {
                return _die2;
            }
        }

        public short Roll => (short)(Die1 + Die2);

        public bool IsCraps { get { return Die1 + Die2 == 7; } }
        public bool IsYo { get { return Die1 + Die2 == 11; } }
    }
}
