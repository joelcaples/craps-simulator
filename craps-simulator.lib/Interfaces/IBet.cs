using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Interfaces
{
    public interface IBet {

        public string Name { get; }
        public BetType Type { get; }
        public int Bet { get; }
        void PlaceBet(int bet);
        public IBetResult Result(Game game, Dice dice);
    }
}
