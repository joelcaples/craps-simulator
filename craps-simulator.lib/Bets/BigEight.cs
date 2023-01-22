using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.lib.Bets {
    internal class BigEight : _Bet, IBet {

        public string Name => $"Big Eight";
        public BetType Type => BetType.BigEight;

        public IBetResult Result(Game game, Dice dice) {

            Func<Dice, bool> IsWinner = (dice) => dice.Roll == 6;
            Func<Dice, bool> IsLoser = (dice) => dice.Roll == 7;

            var isWinner = IsWinner(dice);
            var isLoser = IsLoser(dice);

            return new BetResult(
                isWinner
                    ? (int)Math.Round(this.Bet * Lookups.BigSixBigEight.Pays, MidpointRounding.ToZero)
                    : 0,
                isWinner, 
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);

        }
    }
}