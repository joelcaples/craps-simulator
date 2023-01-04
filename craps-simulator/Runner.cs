using craps_simulator.Bets;
using craps_simulator.dto;
using craps_simulator.Interfaces;
using craps_simulator.Lib;
using craps_simulator.Models;
using Microsoft.VisualBasic;

namespace craps_simulator {

    internal class Runner {

        public static void Go() {
            Go(new List<IBet>() {
                new Pass(),// { Bet=5},
                //new HardTen(),
                //new HardFour(),
                //new HardEight(),
                //new Place(4),
                //new Place(6),
                //new Place(9)
            });
        }

        public static void Go(IEnumerable<IBet> bets) {

            var winners = 0;
            var losers = 0;
            var maxIterations = 100;
            int initialBankRoll = 1000;
            int bankroll = initialBankRoll;
            int housetake = 0;

            var game = new Game();

            //int winloss = 0;
            int iteration = 0;
            bool exitLoop = false;

            var betNets = bets.Select(b => new BetNetDto() { Bet = b, SessionNet = 0, TotalNet = 0}).ToList();

            while (!exitLoop) {
                
                ++iteration;

                if (bankroll == 0) {
                    Console.WriteLine("BUSTED!");
                    break;
                }

                var dice = GameLib.Roll();

                if (betNets == null)
                    throw new InvalidDataException();

                for(int i=0;i< betNets.Count;++i) {

                    var betInfo = betNets[i];

                    if(betInfo.Bet == null)
                        throw new InvalidDataException();

                    if (betInfo.Bet.Bet == 0)
                        PlaceBet(betInfo.Bet, 5, ref bankroll);

                    var result = betInfo.Bet.Result(game, dice);
                    //ProcessOverall(bet.Bet, result, ref bankroll, ref housetake, ref winners, ref losers);

                    var netResult = 0;
                    if(result.IsWinner) {
                        netResult = (int)Math.Round(betInfo.Bet.Bet * result.Pays, 0, MidpointRounding.ToZero);
                        winners++;
                    }

                    if (result.IsLoser) {
                        netResult = betInfo.Bet.Bet * -1;
                        losers++;
                    }

                    bankroll += netResult;
                    housetake -= netResult;
                    betInfo.SessionNet += netResult;
                    betInfo.TotalNet += netResult;
                    //sessionTotal. += netResult;
                    //totalTotal += netResult;

                    //if (result.IsWinner) {
                    //    bankroll += (int)Math.Round(bet.Bet * result.Pays, 0, MidpointRounding.ToZero);
                    //    housetake -= (int)Math.Round(bet.Bet * result.Pays, 0, MidpointRounding.ToZero);
                    //    winners++;
                    //}

                    //if (result.IsLoser) {
                    //    bankroll -= bet.Bet;
                    //    housetake += bet.Bet;
                    //    losers++;
                    //}

                    //if (result.IsWinner)
                    //    winloss += (int)Math.Round(bet.Bet * result.Pays, 0, MidpointRounding.ToZero);

                    //if (result.IsLoser)
                    //    winloss -= 5;
                }

                var throwResult = GameLib.Advance(game, dice);

                LogResult(throwResult, dice, betNets.Sum(bi => bi.SessionNet));

                if (throwResult.IsLoser) {
                    //winloss = 0;
                    exitLoop = iteration >= maxIterations;
                    for (int i = 0; i < betNets.Count; ++i) {
                        betNets[i].SessionNet = 0;
                    }
                }

                game = throwResult.Game;
            }

            foreach (IBet bet in bets)
                bankroll += bet.Bet;

            //var winpct = Math.Round((float)winners / losers * iteration, 2);
            var winnings = bankroll - initialBankRoll;

            LogTotals(iteration, betNets, winnings);
        }

        private static void PlaceBet(IBet bet, int amt, ref int bankroll) {
            if (bankroll < amt)
                return;

            bet.PlaceBet(amt);
            bankroll -= amt;
        }

        //private static void ProcessOverall(int bet, IBetResult betResult, ref int bankroll, ref int housetake, ref int winners, ref int losers) {
        //    if (betResult.IsWinner) {
        //        bankroll += (int)Math.Round(bet * betResult.Pays, 0, MidpointRounding.ToZero);
        //        housetake -= (int)Math.Round(bet * betResult.Pays, 0, MidpointRounding.ToZero);
        //        winners++;
        //    }

        //    if (betResult.IsLoser) {
        //        bankroll -= bet;
        //        housetake += bet;
        //        losers++;
        //    }
        //}

        private static void LogResult(ThrowResult throwResult, Dice dice, int winLoss) {

            if (throwResult.IsLoser) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(dice.Roll.ToString().PadRight(3));
                Console.ForegroundColor = winLoss > 0 ? ConsoleColor.Green : winLoss < 0 ? ConsoleColor.Red : ConsoleColor.DarkGray;
                Console.Write($"{winLoss:C}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

            if (throwResult.IsWinner) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(dice.Roll.ToString().PadRight(3));
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (throwResult.PointWasSet) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dice.Roll.ToString().PadRight(3));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void LogTotals(int totalIterations, IEnumerable<BetNetDto> betNets, int winnings) {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"# of Rolls:{totalIterations}");
            //Console.WriteLine($"Winners:{winners}");
            //Console.WriteLine($"Losers:{losers}");
            //Console.WriteLine($"Win %:{winpct}");

            foreach (var betNet in betNets)
                Console.WriteLine($"{betNet.Bet?.Name} Winnings: {betNet.TotalNet:C}");

            if (winnings >= 0)
                Console.WriteLine($"You Won: {winnings:C}");

            if (winnings < 0)
                Console.WriteLine($"You Lost: {winnings * -1:C}");
        }
    }
}
