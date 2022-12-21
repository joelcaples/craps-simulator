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


            var hardTen = new HardTen();
            hardTen.PlaceBet(5);
            bankroll -= 5;

            for (int i = 0; i < iterations; i++) {

                if (bankroll == 0) {
                    Console.WriteLine("BUSTED!");
                    break;
                }

                if (hardTen.Bet == 0) {
                    hardTen.PlaceBet(5);
                    bankroll -= 5;
                }

                (int die1, int die2) dice = crapslib.roll();

                var hardTenResult = hardTen.Result(dice);

                if (hardTenResult.IsWinner) {
                    bankroll += hardTenResult.Pays;
                    housetake -= hardTen.Bet * hardTenResult.Pays;
                    winners++;
                    continue;
                }

                if (hardTenResult.IsLoser) {
                    housetake += hardTen.Bet;
                    losers++;
                    continue;
                }
            }

            bankroll += hardTen.Bet;

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
