﻿using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {
    internal abstract class _HardFourOrTen : IBet {

        private readonly int _requiredDie;

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

        public BetResult Result((int die1, int die2) dice, float bet) {
            var isHardTen = dice.die1 == _requiredDie && dice.die2 == _requiredDie;
            var isCraps = dice.die1 + dice.die2 == 7;
            var isSoft = dice.die1 + dice.die2 == _requiredDie*2 && (dice.die1 != _requiredDie || dice.die2 != _requiredDie);

            // Winner
            if (isHardTen)
                // Hard ten and hard four pay the same
                return new BetResult() { IsWinner = true, Pays = bet * lookups.HardTen.Pays };

            if (isCraps || isSoft)
                return new BetResult() { IsLoser = true, Pays = 0 };

            return new BetResult() { Pays = 0 };
        }
    }
}
