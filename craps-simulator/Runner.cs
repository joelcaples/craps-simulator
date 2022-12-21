using craps_simulator.Bets;

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
