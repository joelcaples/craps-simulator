using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {
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

        public IBetResult Result(Game game, Dice dice) {

            var isHard = dice.Die1 == _requiredDie && dice.Die2 == _requiredDie;
            var isCraps = dice.Roll == 7;
            var isSoft = dice.Roll == _requiredDie*2 && (dice.Die1 != _requiredDie || dice.Die2 != _requiredDie);

            // Winner
            if (isHard) {
                // Hard ten and hard four pay the same
                return new BetResult() { 
                    IsWinner = true, 
                    Pays = this.Bet * _pays
                };
            }

            if (isCraps || isSoft) {
                return new BetResult() { 
                    IsLoser = true, 
                    Pays = 0 
                };
            }

            return new BetResult() { IsWinner = false, IsLoser = false, Pays = 0 };
        }
    }
}
