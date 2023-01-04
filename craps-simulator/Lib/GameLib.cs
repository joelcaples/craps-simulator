using craps_simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.Lib {
    public class GameLib {

        /*        
        public static Game Advance(Game game, Dice dice) {

            if (game.Phase == PhaseType.On && dice.Roll == 7) {
                //Console.Write("  $ " + bets.Sum(b => b.SessionResult).ToString());
                //Console.WriteLine("");
                //Console.Write("Craps Out -- New Roller:");
                return new Game();
            }

            if (game.Phase == PhaseType.On && dice.Roll == game.Point) {
                //Console.Write("  $ " + bets.Sum(b => b.SessionResult).ToString());
                //Console.WriteLine("");
                //Console.Write("Winner!");
                return new Game();
            }

            if (game.Phase == PhaseType.Off &&
                new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(dice.Roll)) {
                return new Game {
                    Point = (short)(dice.Roll)
                };
                //Console.Write("P");
            }

            return game;
        }
        */

        public static ThrowResult Advance(Game game, Dice dice) {

            if (game.Phase == PhaseType.Off && dice.Roll == 7) {
                return new ThrowResult(new Game()) {
                    IsWinner = true,
                    Msg = "Craps Winner!"
                };
            }

            if (game.Phase == PhaseType.On && dice.Roll == 7) {
                //Console.Write("  $ " + bets.Sum(b => b.SessionResult).ToString());
                //Console.WriteLine("");
                //Console.Write("Craps Out -- New Roller:");
                //return new Game();
                return new ThrowResult(new Game()) {
                    IsLoser = true,
                    Msg = "Craps Out"
                };
            }

            if (game.Phase == PhaseType.On && dice.Roll == game.Point) {
                //Console.Write("  $ " + bets.Sum(b => b.SessionResult).ToString());
                //Console.WriteLine("");
                //Console.Write("Winner!");
                return new ThrowResult(new Game()) {
                    IsWinner = true,
                    //Msg = "Pass-Line Winner!"
                };
            }

            if (game.Phase == PhaseType.Off &&
                new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(dice.Roll)) {
                return new ThrowResult(new Game {
                    Point = dice.Roll
                }) {
                    PointWasSet = true,
                    Msg = "Point Set"
                };
                //Console.Write("P");
            }

            return new ThrowResult(game) { };
        }


        public static Dice Roll() {
            var upperBound = 6;
            var die1 = RandomNumberGenerator.GetInt32(upperBound) + 1;
            var die2 = RandomNumberGenerator.GetInt32(upperBound) + 1;

            return new Dice((short)die1, (short)die2);
        }
    }
}
