using craps_simulator.Models;

namespace craps_simulator.Interfaces
{
    internal interface IBet {
        public BetResult Result((int die1, int die2) dice, float bet);
    }
}
