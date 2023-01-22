using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.lib.Models {
    public class Player {

        private int _bankroll;

        public Player(int initialBankroll) {
            _bankroll = initialBankroll;
        }

        public int BankRoll {
            get {
                return _bankroll;
            }
            set {
                _bankroll = value;
            }
        }
    }
}
