using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {
    internal class PassLine : _Bet, IBet {

        public string Name {
            get {
                return "Pass Line";
            }
        }

        public IBetResult Result(Game game, (int die1, int die2) dice) {

            var isCraps = dice.die1 + dice.die2 == 7;
            var isYo = dice.die1 + dice.die2 == 11;

            var isLoser =
                (game.Phase == PhaseType.Off && (
                dice.die1 + dice.die2 == 2 ||
                dice.die1 + dice.die2 == 3 ||
                dice.die1 + dice.die2 == 12)) ||
                (game.Phase == PhaseType.On && dice.die1 + dice.die2 == 7);

            var isWinner = 
                (game.Phase == PhaseType.Off && (isCraps || isYo)) || 
                (game.Phase == PhaseType.On && dice.die1 + dice.die2 == game.Point);

            if(isWinner) {
                _sessionResult += base.Bet;
                return new BetResult() { IsWinner = true, Bet = base.Bet, Pays = base.Bet };
            }

            if (isLoser) {
                _sessionResult -= base.Bet;
                _bet = 0;
                return new BetResult() { IsLoser = true, Bet = base.Bet, Pays = 0 };
            }

            return new BetResult() { Pays = 0 };
        }
    }
}
