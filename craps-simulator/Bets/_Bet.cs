using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.Bets {
    internal class _Bet {

        protected float _bet = 0;

        public float Bet {
            get {
                return _bet;
            }
        }

        public void PlaceBet(float bet) {
            _bet += bet;
        }

    }
}
