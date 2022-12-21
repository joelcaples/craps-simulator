using craps_simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static craps_simulator.Bets.HardTen;

namespace craps_simulator.Interfaces
{
    internal interface IBet {
        public BetResult Result((int die1, int die2) dice, float bet);
    }
}
