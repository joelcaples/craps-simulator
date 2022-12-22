using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {

    public class Field : _Bet, IBet {

        public string Name => $"Field";

        public IBetResult Result(Game game, (short die1, short die2) dice) {

            Func<Dice, bool> IsWinner = (dice) => (new List<int>() { 2, 3, 4, 9, 10, 11, 12 }).Contains(dice.Roll);

            Func<Dice, bool> IsLoser = (dice) => !IsWinner(dice);

            return base.Result(
                IsWinner(new Dice(dice)),
                IsLoser(new Dice(dice)),
                new Dice(dice).Roll == 2 || new Dice(dice).Roll == 12 ? Lookups.FieldTwoOrTwelve : Lookups.Field);

        }

        private decimal Pays(int roll) => (new List<int>() { 3, 4, 9, 10, 11 }).Contains(roll) ? base.Bet : base.Bet * 2;
    }
}
