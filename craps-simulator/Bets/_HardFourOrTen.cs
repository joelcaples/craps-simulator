using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {
    internal abstract class _HardFourOrTen : _Bet {

        private readonly int _requiredDie;
        private float _sessionResult = 0;

        public _HardFourOrTen(int roll) {
            switch(roll) {
                case 4:
                    _requiredDie = 2;
                    break;
                case 10:
                    _requiredDie = 5;
                    break;
                default:
                    throw new Exception("Invalid Die");

            }
        }

        public IBetResult Result(Game game, (int die1, int die2) dice) {

            var isHard = dice.die1 == _requiredDie && dice.die2 == _requiredDie;
            var isCraps = dice.die1 + dice.die2 == 7;
            var isSoft = dice.die1 + dice.die2 == _requiredDie*2 && (dice.die1 != _requiredDie || dice.die2 != _requiredDie);

            // Winner
            if (isHard) {
                // Hard ten and hard four pay the same
                _sessionResult += base.Bet * lookups.HardTen.Pays;
                return new BetResult() { IsWinner = true, Bet = base.Bet, Pays = base.Bet * lookups.HardTen.Pays };
            }

            if (isCraps || isSoft) {
                _sessionResult -= _bet;
                _bet = 0;
                return new BetResult() { IsLoser = true, Bet = base.Bet, Pays = 0 };
            }

            return new BetResult() { Pays = 0 };
        }

        public float SessionResult {
            get {
                return _sessionResult;
            }
        }
    }
}
