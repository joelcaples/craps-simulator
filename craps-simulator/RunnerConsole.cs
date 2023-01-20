using craps_simulator.Lib.Bets;
//using craps_simulator.dto;
using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;
using craps_simulator.Lib.Lib;
using craps_simulator.lib.Services;

namespace craps_simulator {


    public class RunnerConsole {


        //public event Msg? MsgEvt;

        public void Go() {
            //var winners = 0;
            //var losers = 0;
            //var maxIterations = 5;
            int initialBankRoll = 1000;
            int bankroll = initialBankRoll;
            //int housetake = 0;

            var runner = new Runner();
            var bets = new List<IBet>() {
                new Pass(),// { Bet=5},
                new HardTen(),
                //new HardFour(),
                //new HardEight(),
                //new Place(4),
                //new Place(6),
                //new Place(9)
            };
            var result = runner.Go(bets, Runner_MsgEvt);

            //foreach (IBet bet in bets)
            //    bankroll += bet.Bet;

            //var winpct = Math.Round((float)winners / losers * iteration, 2);
            var winnings = bankroll - initialBankRoll;

            LogTotals(result.TotalRolls, betNets, totalNet);

        }

        private int sessionNet = 0;
        private int totalNet = 0;
        private readonly Dictionary<string, int> betNets = new();

        private void Runner_MsgEvt(object sender, RollResultEventArgs e) {

            var netResult = 0;
            foreach (var (Bet, Result) in e.BetResults) {
                var betResult = 0;
                if (Result.IsWinner) {
                    betResult = (int)Math.Round(Result.Pays, 0, MidpointRounding.ToZero);
                    ////Console.Write("W  ");
                    //winners++;
                }

                if (Result.IsLoser) {
                    betResult = Bet.Bet * -1;
                    ////Console.Write("L  ");
                    //losers++;
                }

                if (betNets.ContainsKey(Bet.Name))
                    betNets[Bet.Name] += betResult;
                else
                    betNets[Bet.Name] = betResult;

                netResult += betResult;
            }

            sessionNet += netResult;
            totalNet += netResult;

            var throwResult = GameLib.Advance(e.Game, e.Dice);
            LogResult(throwResult, e.Dice, sessionNet);
            if (throwResult.IsLoser) {
                sessionNet = 0;
            }
        }


        private static void LogResult(ThrowResult throwResult, Dice dice, int winLoss) {

            if (throwResult.IsLoser) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                LogRoll(dice);
                Console.ForegroundColor = winLoss > 0 ? ConsoleColor.Green : winLoss < 0 ? ConsoleColor.Red : ConsoleColor.DarkGray;
                Console.Write($"{winLoss:C}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                return;
            }

            if (throwResult.IsWinner) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                LogRoll(dice);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (throwResult.PointWasSet) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                LogRoll(dice);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            LogRoll(dice);
        }

        private static void LogRoll(Dice dice) {
            Console.Write($"{dice.Die1},{dice.Die2}".PadRight(5));
        }

        private static void LogTotals(int totalIterations, Dictionary<string, int> betNets, int winnings) {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"# of Rolls:{totalIterations}");
            //Console.WriteLine($"Winners:{winners}");
            //Console.WriteLine($"Losers:{losers}");
            //Console.WriteLine($"Win %:{winpct}");

            foreach (var betNet in betNets)
                Console.WriteLine($"{betNet.Key} Winnings: {betNet.Value:C}");

            if (winnings >= 0)
                Console.WriteLine($"You Won: {winnings:C}");

            if (winnings < 0)
                Console.WriteLine($"You Lost: {winnings * -1:C}");
        }
    }
}
