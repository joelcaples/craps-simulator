using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {
    public class Pass : _Bet, IBet {

        public string Name => "Pass Line";
        public BetType Type => BetType.Pass;

        public IBetResult Result(Game game, Dice dice) {

            var result = (IsWinner: false, IsLoser: false, Msg: string.Empty);

            if(game.Phase == PhaseType.Off && dice.IsCraps)
                result = (true, false, "Craps Winner");

            if (game.Phase == PhaseType.Off && dice.IsYo)
                result = (true, false, "Craps Winner");

            if (game.Phase == PhaseType.On && dice.Roll == game.Point)
                result = (true, false, "Pass-Line Winner");

            if (game.Phase == PhaseType.On && dice.Roll == 7)
                result = (false, true, "Pass-Line Loser");

            if (game.Phase == PhaseType.Off && new List<short>() { 2, 3, 12 }.Contains(dice.Roll))
                result = (false, true, "Crap Out");

            if (game.Phase == PhaseType.Off && new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(dice.Roll))
                result = (false, true, $"Point Set: {dice.Roll}");

            return new BetResult(
                result.IsWinner
                    ? this.Bet * Lookups.Pass.Pays
                    : 0, result.IsWinner, 
                result.IsLoser, 
                result.Msg);
        }
    }
}
