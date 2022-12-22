using craps_simulator.Bets;
using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator {

    internal class Runner {

        public void Go() {
            Go(new List<IBet>() { 
                new Pass(),
                new HardTen(),
                new HardFour(),
                new HardEight(),
                new Place(4),
                new Place(6),
                new Place(9)
            });
        }

        public void Go(IEnumerable<IBet> bets) {

            var winners = 0;
            var losers = 0;
            var iterations = 100;
            int initialBankRoll = 1000;
            int bankroll = initialBankRoll;
            int housetake = 0;

            foreach(IBet bet in bets)
                PlaceBet(bet, bet.Bet, ref bankroll);

            var game = new Game();

            for (int i = 0; i < iterations; i++) {

                if (bankroll == 0) {
                    Console.WriteLine("BUSTED!");
                    break;
                }

                (short die1, short die2) dice = crapslib.roll();
                Console.Write((dice.die1 + dice.die2).ToString().PadLeft(3));

                foreach (IBet bet in bets) {
                    if (bet.Bet == 0)
                        PlaceBet(bet, 5, ref bankroll);

                    var result = bet.Result(game, dice);
                    ProcessResult(bet.Bet, result, ref bankroll, ref housetake, ref winners, ref losers);
                }

                if (game.Phase == PhaseType.On && dice.die1 + dice.die2 == 7) {
                    Console.Write("  $ "+bets.Sum(b => b.SessionResult).ToString());
                    Console.WriteLine("");
                    Console.Write("New Roller:");
                    game = new Game();
                }

                if (game.Phase == PhaseType.Off &&
                    (dice.die1 + dice.die2 == 4 ||
                    dice.die1 + dice.die2 == 5 ||
                    dice.die1 + dice.die2 == 6 ||
                    dice.die1 + dice.die2 == 8 ||
                    dice.die1 + dice.die2 == 9 ||
                    dice.die1 + dice.die2 == 10)) {

                    game.Off();
                    game.Point = (short)(dice.die1 + dice.die2);
                    Console.Write("P");
                }
            }

            foreach (IBet bet in bets)
                bankroll += bet.Bet;

            var winpct = Math.Round((float)winners / losers * 100, 2);
            var winnings = bankroll - initialBankRoll;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"# of Rolls:{iterations}");
            //Console.WriteLine($"Winners:{winners}");
            //Console.WriteLine($"Losers:{losers}");
            //Console.WriteLine($"Win %:{winpct}");

            foreach (IBet bet in bets) {
                Console.WriteLine($"{ bet.Name} Winnings: ${bet.SessionResult}");
            }


            if (winnings >= 0)
                Console.WriteLine($"You Won $:{winnings:C}");

            if (winnings < 0)
                Console.WriteLine($"You Lost $:{winnings * -1:C}");
        }

        private void PlaceBet(IBet bet, int amt, ref int bankroll) {
            if (bankroll < amt)
                return;

            bet.PlaceBet(amt);
            bankroll -= amt;
        }

        private void ProcessResult(int bet, IBetResult betResult, ref int bankroll, ref int housetake, ref int winners, ref int losers) {
            if (betResult.IsWinner) {
                bankroll += betResult.Pays;
                housetake -= bet * betResult.Pays;
                winners++;
            }

            if (betResult.IsLoser) {
                housetake += bet;
                losers++;
            }
        }
    }
}
