﻿using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Lib;
using craps_simulator.Lib.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;
using craps_simulator.lib.Models;

namespace craps_simulator.lib.Services
{
    public class RollResultEventArgs {

        private readonly Game _game;
        private readonly int _bankRoll;
        private readonly Dice _dice;
        private readonly IEnumerable<(IBet Bet, IBetResult Result)> _betResults;

        public RollResultEventArgs(Game game, int bankRoll, Dice dice, IEnumerable<(IBet Bet, IBetResult Result)> betResults) {
            _game = game;
            _bankRoll = bankRoll;
            _dice = dice;
            _betResults = betResults;
        }

        public Game Game => _game;
        public int BankRoll => _bankRoll;
        public Dice Dice => _dice;
        public IEnumerable<(IBet Bet, IBetResult Result)> BetResults => _betResults;
    }

    public class Runner
    {
        public delegate void Msg(object sender, RollResultEventArgs e);

        private class BetNetDto {

            private readonly IBet _bet;
            private readonly int _placedAmount;
            private int _sessionNet;
            private int _totalNet;

            public BetNetDto(IBet bet, int placedAmount, int sessionNet, int totalNet) {
                _bet = bet;
                _placedAmount = placedAmount;
                _sessionNet = sessionNet;
                _totalNet = totalNet;
            }

            public IBet Bet => _bet;
            public int PlacedAmount => _placedAmount;

            public int SessionNet {
                set {
                    _sessionNet = value;
                }
                get {
                    return _sessionNet;
                }
            }

            public int TotalNet {
                set {
                    _totalNet = value;
                }
                get {
                    return _totalNet;
                }
            }
        }

        public class RunReturnDto {
            public int TotalRolls { get; set; } = 0;
        }

        public RunReturnDto Go(Player player, IEnumerable<IBet> bets, Msg? handler = null) {

            var winners = 0;
            var losers = 0;
            var maxIterations = 5;
            int initialBankRoll = player.BankRoll;
            int bankroll = initialBankRoll;
            int housetake = 0;

            var game = new Game();

            int iteration = 0;
            bool exitLoop = false;

            var betNets = bets.Select(b => new BetNetDto(b, 0, 0, 0)).ToList();

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
                handler?.Invoke(this, new RollResultEventArgs(game, bankroll, dice, results));
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

        //private string RollNickName(Dice dice) {
        //    return dice.Roll switch {
        //        2 => "Aces",
        //        3 => "Ace-Deuce",
        //        4 => dice.Die1 == 2 ? "Hard Four" : "Soft Four",
        //        5 => string.Empty,
        //        6 => dice.Die1 == 3 ? "Hard Six" : "Soft Six",
        //        7 => "Seven Out",
        //        8 => dice.Die1 == 4 ? "Hard Eight" : "Soft Eight",
        //        9 => "Center Field Nine",
        //        10 => dice.Die1 == 5 ? "Hard Ten" : "Soft Ten",
        //        11 => "Yo ‘leven",
        //        12 => "Boxcars",
        //        _ => string.Empty
        //    };

        //    /*
        //    Two: Two craps, aces, snake eyes, two bad boys from Illinois.
        //    Three: Three craps, ace-deuce, ace caught a deuce, the indicator(precursor to the eleven rolling), the Yo down under.
        //    Four: Little Joe, Little Joe from Kokomo, the ballerina hit us in the tutu, ace-trey the country way.
        //    Five: No - field five, thirty - two juice(after O.J.’s jersey number), Little Phoebe, fire, fever.
        //    Six: Corner red, the national average, Sixie from Dixie.
        //    Seven: Big Red, seven out, line away, front line winner, back line skinner, the Devil, Benny Blue, you’re all through.
        //    Eight: The Eighter from Decatur, Ozzie and Harriet, the square pair, a couple of windows.
        //    Nine: Center field nine, the center of the garden, Nine Nina from Pasadena, they shot Jesse James with a forty-five.
        //    Ten: Big dick, the big one on the end, puppy paws, a pair of sunflowers.
        //    Eleven: Yo ‘leven, yo lev, yo Levine the dancing queen, six-five, no jive.
        //    Twelve: Twelve craps, boxcars, midnight, all the spots we got, outstanding in your field.        
        //    */
        //}

    }
}
