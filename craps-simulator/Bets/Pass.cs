using craps_simulator.Interfaces;
using craps_simulator.Models;
using System.Collections;

namespace craps_simulator.Bets {
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
                result = (false, true, "Craps Loser");

            if (game.Phase == PhaseType.Off && new List<short>() { 2, 3, 12 }.Contains(dice.Roll))
                result = (false, true, "Craps Loser");

            return new BetResult() {
                IsWinner = result.IsWinner,
                IsLoser = result.IsLoser,
                Pays = Lookups.Pass.Pays
            };
        }
    }
}
