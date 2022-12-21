using craps_simulator.Models;

namespace craps_simulator.Interfaces
{
    internal interface IBet {

        public float Bet { get; }
        void PlaceBet(float bet);
        public BetResult Result((int die1, int die2) dice);
    }
}
