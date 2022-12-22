using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {
    public abstract class _Hardway : _Bet {

        private readonly int _requiredDie;
        private readonly decimal _pays;

        public _Hardway(short roll) {

            switch(roll) {
                case 4:
                    _requiredDie = 2;
                    _pays = Lookups.HardFourOrTen.Pays;
                    break;
                case 6:
                    _requiredDie = 3;
                    _pays = Lookups.HardSixOrEight.Pays;
                    break;
                case 8:
                    _requiredDie = 4;
                    _pays = Lookups.HardSixOrEight.Pays;
                    break;
                case 10:
                    _requiredDie = 5;
                    _pays = Lookups.HardFourOrTen.Pays;
                    break;
                default:
                    throw new Exception("Invalid Die");

            }
        }

        public IBetResult Result(Game game, (short die1, short die2) dice) {

            var isHard = dice.die1 == _requiredDie && dice.die2 == _requiredDie;
            var isCraps = dice.die1 + dice.die2 == 7;
            var isSoft = dice.die1 + dice.die2 == _requiredDie*2 && (dice.die1 != _requiredDie || dice.die2 != _requiredDie);

            // Winner
            if (isHard) {
                // Hard ten and hard four pay the same
                _sessionResult += base.Bet * _pays;
                return new BetResult() { IsWinner = true, Bet = base.Bet, Pays = (int)Math.Round(base.Bet * _pays, 0, MidpointRounding.ToZero) };
            }
            
            if (isCraps || isSoft) {
                _sessionResult -= _bet;
                _bet = 0;
                return new BetResult() { IsLoser = true, Bet = base.Bet, Pays = 0 };
            }

            return new BetResult() { IsWinner = false, IsLoser = false, Pays = 0 };
        }
    }
}
