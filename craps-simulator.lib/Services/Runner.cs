using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Lib;
using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.lib.Services
{
    public class RollResultEventArgs {

        public RollResultEventArgs(Game game, Dice dice, IEnumerable<(IBet Bet, IBetResult Result)> betResults) {
            Game = game;
            Dice = dice;
            BetResults = betResults;
        }

        public Game Game { get; }
        public Dice Dice { get; }
        public IEnumerable<(IBet Bet, IBetResult Result)> BetResults { get; }
    }

    public class Runner
    {
        public delegate void Msg(object sender, RollResultEventArgs e);

        private class BetNetDto {
            public IBet? Bet { get; set; }
            public int SessionNet { get; set; }
            public int TotalNet { get; set; }
        }

        public class RunReturnDto {
            public int TotalRolls { get; set; } = 0;
        }

        public RunReturnDto Go(IEnumerable<IBet> bets, Msg? handler = null) {

            var winners = 0;
            var losers = 0;
            var maxIterations = 5;
            int initialBankRoll = 1000;
            int bankroll = initialBankRoll;
            int housetake = 0;

            var game = new Game();

            int iteration = 0;
            bool exitLoop = false;

            var betNets = bets.Select(b => new BetNetDto() { Bet = b, SessionNet = 0, TotalNet = 0 }).ToList();

            while (!exitLoop) {

                if (bankroll == 0) {
                    Console.WriteLine("BUSTED!");
                    break;
                }

                var dice = GameLib.Roll();

                if (betNets == null)
                    throw new InvalidDataException();

                var results = new List<(IBet Bet, IBetResult Result)>();
                for (int i = 0; i < betNets.Count; ++i) {

                    var betInfo = betNets[i];

                    if (betInfo.Bet == null)
                        throw new InvalidDataException();

                    if (betInfo.Bet.Bet == 0)
                        PlaceBet(betInfo.Bet, 5, ref bankroll);

                    var result = betInfo.Bet.Result(game, dice);

                    var netResult = 0;
                    if (result.IsWinner) {
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

                    results.Add((betInfo.Bet, result));
                }

                //RaiseMsg(dice, results);
                handler?.Invoke(this, new RollResultEventArgs(game, dice, results));
                var throwResult = GameLib.Advance(game, dice);

//                LogResult(throwResult, dice, betNets.Sum(bi => bi.SessionNet));

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

//            LogTotals(iteration, betNets, winnings);

            static void PlaceBet(IBet bet, int amt, ref int bankroll) {
                if (bankroll < amt)
                    return;

                bet.PlaceBet(amt);
                bankroll -= amt;
            }

            return new RunReturnDto() { TotalRolls = iteration };
        }
    }
}
