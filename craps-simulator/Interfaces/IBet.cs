using craps_simulator.Models;

namespace craps_simulator.Interfaces
{
    internal interface IBet {

        public string Name { get; }
        public int Bet { get; }
        void PlaceBet(int bet);
        public IBetResult Result(Game game, Dice dice);
        public decimal SessionResult { get; }
    }
}
