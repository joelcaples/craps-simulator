using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.lib.Bets {
    internal class BigSix : _Bet, IBet {

        public string Name => $"Big Six";
        public BetType Type => BetType.BigSix;

        public IBetResult Result(Game game, Dice dice) {

            Func<Dice, bool> IsWinner = (dice) => dice.Roll == 6;
            Func<Dice, bool> IsLoser = (dice) => dice.Roll == 7;

            var isWinner = IsWinner(dice);
            var isLoser = IsLoser(dice);

            return new BetResult(
                //this.Bet, 
                isWinner
                    ? this.Bet * Lookups.BigSixBigEight.Pays
                    : 0, isWinner, isLoser);

        }
    }
}