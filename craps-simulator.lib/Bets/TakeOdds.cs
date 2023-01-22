using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    /// <summary>
    /// It is called Taking the Odds if you bet on a point after a Pass bet. 
    /// It is called Laying Odds if you bet against a point after a Don't Pass bet. 
    /// In both cases the odds are statistically fair, with no house edge.
    /// </summary>

    public class TakeOdds : _Bet, IBet {

        public string Name => $"Take Odds";

        public BetType Type => BetType.TakeOdds;

        public IBetResult Result(Game game, Dice dice) {

            var isWinner = game.Phase == PhaseType.On && dice.Roll == game.Point;
            var isLoser = game.Phase == PhaseType.On && dice.Roll == 7;

            return new BetResult(
                isWinner
                    ? (int)Math.Round(this.Bet * game.Point switch {
                        4 or 10 => Lookups.TakeOddsFourOrTen.Pays,
                        5 or 9 => Lookups.TakeOddsFiveOrNine.Pays,
                        6 or 8 => Lookups.TakeOddsSixOrEight.Pays,
                        _ => throw new Exception("Invalid Take Odds Bet")
                    }, MidpointRounding.ToZero) : 0, 
                isWinner, 
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);
        }
    }
}
