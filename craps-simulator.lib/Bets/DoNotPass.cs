using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {
    public class DoNotPass : _Bet, IBet {

        public string Name => "Don't Pass";
        public BetType Type => BetType.DoNotPass;

        public IBetResult Result(Game game, Dice dice) {

            var isLoser =
                (game.Phase == PhaseType.Off && (dice.IsCraps || dice.IsYo)) ||
                (game.Phase == PhaseType.On && dice.Roll == game.Point);

            var isWinner =
                (game.Phase == PhaseType.Off && (
                dice.Roll == 2 ||
                dice.Roll == 3 ||
                dice.Roll == 12)) ||
                (game.Phase == PhaseType.On && dice.Roll == 7);

            return new BetResult(
                isWinner
                    ? (int)Math.Round(this.Bet * Lookups.DoNotPass.Pays, MidpointRounding.ToZero)
                    : 0,
                isWinner, 
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);
        }
    }
}
