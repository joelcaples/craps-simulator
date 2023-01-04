using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {
    public class _Bet {

        protected int _bet = 0;

        public virtual int Bet {
            get {
                return _bet;
            }
        }

        public void PlaceBet(int bet) {
            _bet = bet;
        }

    }
}
