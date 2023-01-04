using craps_simulator.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            if (game.Phase == PhaseType.Off && dice.IsCraps)
                return new ThrowResult(new Game()) { IsWinner = true, IsLoser = false, PointWasSet = false, Msg = "Craps Winner" };

            if (game.Phase == PhaseType.Off && dice.IsYo)
                return new ThrowResult(new Game()) { IsWinner = true, IsLoser = false, PointWasSet = false, Msg = "Craps Winner" };

            if (game.Phase == PhaseType.On && dice.Roll == game.Point)
                return new ThrowResult(new Game()) { IsWinner = true, IsLoser = false, PointWasSet = false, Msg = "Point Made" };

            if (game.Phase == PhaseType.On && dice.Roll == 7)
                return new ThrowResult(new Game()) { IsWinner = false, IsLoser = true, PointWasSet = false, Msg = "Seven Out" };

            if (game.Phase == PhaseType.Off && new List<short>() { 2, 3, 12 }.Contains(dice.Roll))
                return new ThrowResult(new Game()) { IsWinner = false, IsLoser = true, PointWasSet = false, Msg = "Crap Out" };

            if (game.Phase == PhaseType.Off && new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(dice.Roll))
                return new ThrowResult(new Game() { Point=dice.Roll}) { IsWinner = false, IsLoser = false, PointWasSet = true, Msg = "Point Set" };

            return new ThrowResult(game) { IsWinner = false, IsLoser = false, PointWasSet = false, Msg = string.Empty };
        }


        public static Dice Roll() {
            var upperBound = 6;
            var die1 = RandomNumberGenerator.GetInt32(upperBound) + 1;
            var die2 = RandomNumberGenerator.GetInt32(upperBound) + 1;

            return new Dice((short)die1, (short)die2);
        }
    }
}
