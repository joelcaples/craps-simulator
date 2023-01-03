using craps_simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.Lib {
    public class GameLib {

        public static Game Advance(Game game, Dice dice) {

            if (game.Phase == PhaseType.On && dice.Roll == 7) {
                //Console.Write("  $ " + bets.Sum(b => b.SessionResult).ToString());
                //Console.WriteLine("");
                //Console.Write("New Roller:");
                game = new Game();
            }

            if (game.Phase == PhaseType.On && dice.Roll == game.Point) {
                //Console.Write("  $ " + bets.Sum(b => b.SessionResult).ToString());
                //Console.WriteLine("");
                //Console.Write("New Roller:");
                game = new Game();
            }

            if (game.Phase == PhaseType.Off &&
                new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(dice.Roll)) {
                game = new Game {
                    Point = (short)(dice.Die1 + dice.Die2)
                };
                //Console.Write("P");
            }

            return game;
        }
    }
}
