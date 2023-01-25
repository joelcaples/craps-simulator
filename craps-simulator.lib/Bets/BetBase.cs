using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace craps_simulator.Lib.Bets {
    public abstract class BetBase {

        protected int _bet = 0;

        public virtual int Bet {
            get {
                return _bet;
            }
        }

        public void PlaceBet(int bet) {
            _bet = bet;
        }

        public abstract string Name { get; }
        public abstract bool IsWinner(Dice dice);
        public abstract bool IsLoser(Dice dice);
        public abstract int Pays { get; }

        public IBetResult Result(Game game, Dice dice) {

            var isWinner = IsWinner(dice);
            var isLoser = IsLoser(dice);

            return new BetResult(IsWinner(dice) ? Pays : 0,
            isWinner,
            isLoser,
            isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);
        }

    }
}
