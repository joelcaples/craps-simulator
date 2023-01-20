using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class Field : _Bet, IBet {

        public string Name => $"Field";
        public BetType Type => BetType.Field;

        public IBetResult Result(Game game, Dice dice) {

            Func<Dice, bool> IsWinner = (dice) => (new List<int>() { 2, 3, 4, 9, 10, 11, 12 }).Contains(dice.Roll);

            Func<Dice, bool> IsLoser = (dice) => !IsWinner(dice);

            var isWinner = IsWinner(dice);
            var isLoser = IsLoser(dice);

            return new BetResult(
                //this.Bet, 
                isWinner ? this.Bet * (dice.Roll == 2 || dice.Roll == 12 ? Lookups.FieldTwoOrTwelve.Pays : Lookups.Field.Pays) : 0, isWinner, isLoser);
        }
    }
}
