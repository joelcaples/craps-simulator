using craps_simulator.Models;

namespace craps_simulator.Interfaces
{
    internal interface IBet {

        void PlaceBet(float bet);
        public BetResult Result((int die1, int die2) dice);
    }
}
