using craps_simulator.Interfaces;
using craps_simulator.Models;
using System.Collections;

namespace craps_simulator.Bets {

    /// <summary>
    /// It is called Taking the Odds if you bet on a point after a Pass bet. 
    /// It is called Laying Odds if you bet against a point after a Don't Pass bet. 
    /// In both cases the odds are statistically fair, with no house edge.
    /// </summary>

    public class TakeOdds : _Bet, IBet {

        public string Name {
            get {
                return "Odds";
            }
        }

        public IBetResult Result(Game game, (short die1, short die2) dice) {

            Func<Game, Dice, bool> IsWinner = (game, dice) => {
                var isWinner =
                    (game.Phase == PhaseType.On && dice.Die1 + dice.Die2 == game.Point);
                return isWinner;
            };

            Func<Game, Dice, bool> IsLoser = (game, dice) => {
                var isLoser =
                    game.Phase == PhaseType.On && dice.Die1 + dice.Die2 == 7;
                return isLoser;
            };

            return base.Result(
                IsWinner(game, new Dice(dice)),
                IsLoser(game, new Dice(dice)),
                game.Point switch {
                    4 or 10 => Lookups.TakeOddsFourAndTen,
                    5 or 9 => Lookups.TakeOddsFiveAndNine,
                    6 or 8 => Lookups.TakeOddsSixAndEight,
                    _ => throw new Exception("Invalid Place Bet"),
                });
        }
    }
}
