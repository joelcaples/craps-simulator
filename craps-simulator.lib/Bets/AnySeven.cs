using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class AnySeven : _Bet, IBet {

        public string Name => $"Any Seven";
        public BetType Type => BetType.AnySeven;

        public IBetResult Result(Game game, Dice dice) {

            static bool IsWinner(Dice dice) => (dice.Roll == 7);
            static bool IsLoser(Dice dice) => !IsWinner(dice);

            var isWinner = IsWinner(dice);
            var isLoser = IsLoser(dice);

            return new BetResult(
                isWinner 
                    ? this.Bet * Lookups.AnySeven.Pays 
                    : 0, 
                isWinner, 
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);
        }
    }
}
