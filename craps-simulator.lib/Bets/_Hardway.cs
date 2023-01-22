using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;
using static craps_simulator.lib.Services.Runner;

namespace craps_simulator.Lib.Bets {
    public abstract class _Hardway : _Bet {

        private readonly int _requiredDie;
        private readonly decimal _pays;

        public _Hardway(HardWayRollResult roll) {

            switch(roll) {
                case HardWayRollResult.Four:
                    _requiredDie = 2;
                    _pays = Lookups.HardFourOrTen.Pays;
                    break;
                case HardWayRollResult.Six:
                    _requiredDie = 3;
                    _pays = Lookups.HardSixOrEight.Pays;
                    break;
                case HardWayRollResult.Eight:
                    _requiredDie = 4;
                    _pays = Lookups.HardSixOrEight.Pays;
                    break;
                case HardWayRollResult.Ten:
                    _requiredDie = 5;
                    _pays = Lookups.HardFourOrTen.Pays;
                    break;

            }
        }

        public IBetResult Result(Game game, Dice dice) {

            var isHard = dice.Die1 == _requiredDie && dice.Die2 == _requiredDie;
            var isCraps = dice.Roll == 7;
            var isSoft = dice.Roll == _requiredDie*2 && (dice.Die1 != _requiredDie || dice.Die2 != _requiredDie);

            // Winner
            if (isHard) {
                // Hard ten and hard four pay the same
                return new BetResult(
                    (int)Math.Round(this.Bet * _pays, MidpointRounding.ToZero), 
                    true,
                    false,
                    $"Hard {_requiredDie * 2} Winner");
            }

            if (isCraps || isSoft) {
                return new BetResult(
                    0,
                    false,
                    true,
                    $"Hard {_requiredDie * 2} Loser");
            }

            return new BetResult(
                0, false, false);
        }
    }
}
