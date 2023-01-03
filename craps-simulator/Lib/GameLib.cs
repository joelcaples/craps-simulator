using craps_simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.Lib {
    public class GameLib {

        public static Game Advance(Game game, Dice dice) {

            if (game.Phase == PhaseType.On && dice.Die1 + dice.Die2 == 7) {
                //Console.Write("  $ " + bets.Sum(b => b.SessionResult).ToString());
                //Console.WriteLine("");
                //Console.Write("New Roller:");
                game = new Game();
            }

            if (game.Phase == PhaseType.Off &&
                (dice.Die1 + dice.Die2 == 4 ||
                dice.Die1 + dice.Die2 == 5 ||
                dice.Die1 + dice.Die2 == 6 ||
                dice.Die1 + dice.Die2 == 8 ||
                dice.Die1 + dice.Die2 == 9 ||
                dice.Die1 + dice.Die2 == 10)) {

                game = new Game();
                //game.Off();
                game.Point = (short)(dice.Die1 + dice.Die2);
                //Console.Write("P");
            }

            return game;
        }
    }
}
