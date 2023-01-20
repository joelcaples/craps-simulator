using craps_simulator.Lib.Bets;
using craps_simulator.dto;
using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;
using craps_simulator.Lib.Lib;
using System.Collections.Generic;

namespace craps_simulator {

    public class RollResultEventArgs {
        
        public RollResultEventArgs(Dice dice, IEnumerable<IBetResult> betResults) { 
            Dice = dice; 
            BetResults = betResults; 
        }
        
        public Dice Dice { get; }
        public IEnumerable<IBetResult> BetResults { get; }
    }

    public class Runner {

        public delegate void Msg(object sender, RollResultEventArgs e);

        public event Msg MsgEvt;

        private void RaiseMsg(Dice dice, IEnumerable<IBetResult> betResults) {
            if (MsgEvt != null)
                MsgEvt.Invoke(this, new RollResultEventArgs(dice, betResults));
        }

        public void Go() {
            Go(new List<IBet>() {
                new Pass(),// { Bet=5},
                new HardTen(),
                //new HardFour(),
                //new HardEight(),
                //new Place(4),
                //new Place(6),
                //new Place(9)
            });
        }

        public void Go(IEnumerable<IBet> bets) {

            var winners = 0;
            var losers = 0;
            var maxIterations = 5;
            int initialBankRoll = 1000;
            int bankroll = initialBankRoll;
            int housetake = 0;

            var game = new Game();

            int iteration = 0;
            bool exitLoop = false;

            var betNets = bets.Select(b => new BetNetDto() { Bet = b, SessionNet = 0, TotalNet = 0}).ToList();

            while (!exitLoop) {

                if (bankroll == 0) {
                    Console.WriteLine("BUSTED!");
                    break;
                }

                var dice = GameLib.Roll();

                if (betNets == null)
                    throw new InvalidDataException();

                var results = new List<IBetResult>();
                for(int i=0;i< betNets.Count;++i) {

                    var betInfo = betNets[i];

                    if(betInfo.Bet == null)
                        throw new InvalidDataException();

                    if (betInfo.Bet.Bet == 0)
                        PlaceBet(betInfo.Bet, 5, ref bankroll);

                    var result = betInfo.Bet.Result(game, dice);

                    var netResult = 0;
                    if(result.IsWinner) {
                        netResult = (int)Math.Round(result.Pays, 0, MidpointRounding.ToZero);
                        //Console.Write("W  ");
                        winners++;
                    }

                    if (result.IsLoser) {
                        netResult = betInfo.Bet.Bet * -1;
                        //Console.Write("L  ");
                        losers++;
                    }

                    bankroll += netResult;
                    housetake -= netResult;
                    betInfo.SessionNet += netResult;
                    betInfo.TotalNet += netResult;

                    results.Add(result);
                }

                RaiseMsg(dice, results);
                var throwResult = GameLib.Advance(game, dice);

                LogResult(throwResult, dice, betNets.Sum(bi => bi.SessionNet));

                if (throwResult.IsLoser) {
                    ++iteration;
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

        private void LogResult(ThrowResult throwResult, Dice dice, int winLoss) {

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

        private void LogRoll(Dice dice) {
            Console.Write($"{dice.Die1},{dice.Die2}".PadRight(5));
            //RaiseMsg($"{dice.Die1},{dice.Die2}");
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
