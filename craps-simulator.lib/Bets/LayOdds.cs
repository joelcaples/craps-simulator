using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    /// <summary>
    /// It is called Taking the Odds if you bet on a point after a Pass bet. 
    /// It is called Laying Odds if you bet against a point after a Don't Pass bet. 
    /// In both cases the odds are statistically fair, with no house edge.
    /// </summary>

    public class LayOdds : _Bet, IBet {

        public string Name => $"Lay Odds";

        public BetType Type => BetType.LayOdds;

        public IBetResult Result(Game game, Dice dice) {

            var isWinner = game.Phase == PhaseType.On && dice.Roll == 7;
            var isLoser = game.Phase == PhaseType.On && dice.Roll == game.Point;

            return new BetResult(
                isWinner
                    ? this.Bet * game.Point switch {
                        4 or 10 => Lookups.LayOddsFourOrTen.Pays,
                        5 or 9 => Lookups.LayOddsFiveOrNine.Pays,
                        6 or 8 => Lookups.LayOddsSixOrEight.Pays,
                        _ => throw new Exception("Invalid Lay Odds Bet")
                    } : 0,
                isWinner,
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);


        }
    }
}
