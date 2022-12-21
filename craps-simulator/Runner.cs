using craps_simulator.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator {
    internal class Runner {
        public void Go() {

            var winners = 0;
            var losers = 0;
            var iterations = 100;
            float initialBankRoll = 1000;
            float bankroll = initialBankRoll;
            float housetake = 0;

            var bet = 5;
            bankroll -= 5;



            for (int i = 0; i < iterations; i++) {

                if (bankroll == 0) {
                    Console.WriteLine("BUSTED!");
                    break;
                }

                if (bet == 0) {
                    bet = 5;
                    bankroll -= 5;
                }

                (int die1, int die2) dice = crapslib.roll();

                var hardTenResult = new HardTen().Result(dice, bet);
                //var isHardTen = dice.die1 == 5 && dice.die2 == 5;
                //var isCraps = dice.die1 + dice.die2 == 7;
                //var isSoftTen = dice.die1 + dice.die2 == 10 && (dice.die1 != 5 || dice.die2 != 5);

                // Winner
                if (hardTenResult.IsWinner) {
                    bankroll += hardTenResult.Pays;
                    housetake -= bet * hardTenResult.Pays;
                    winners++;
                    continue;
                }

                if (hardTenResult.IsLoser) {
                    housetake += bet;
                    bet = 0;
                    losers++;
                    continue;
                }
                //if (isHardTen) {
                //    bankroll += bet * lookups.HardTen.Pays;
                //    housetake -= bet * lookups.HardTen.Pays;
                //    winners++;
                //    continue;
                //}

                //if (isCraps || isSoftTen) {
                //    housetake += bet;
                //    bet = 0;
                //    losers++;
                //    continue;
                //}
            }

            bankroll += bet;

            var winpct = Math.Round((float)winners / losers * 100, 2);
            var winnings = bankroll - initialBankRoll;

            Console.WriteLine($"Iterations:{iterations}");
            Console.WriteLine($"Winners:{winners}");
            Console.WriteLine($"Losers:{losers}");
            Console.WriteLine($"Win %:{winpct}");

            if (winnings >= 0)
                Console.WriteLine($"You Won $:{winnings:C}");

            if (winnings < 0)
                Console.WriteLine($"You Lost $:{winnings * -1:C}");
        }
    }
}
