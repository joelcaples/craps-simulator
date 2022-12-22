﻿using craps_simulator.Interfaces;
using craps_simulator.Models;
using System.Collections;

namespace craps_simulator.Bets {
    public class PassLine : _Bet, IBet {

        public string Name {
            get {
                return "Pass Line";
            }
        }

        public IBetResult Result(Game game, (short die1, short die2) dice) {

            Func<Game, Dice, bool> IsWinner = (game, dice) => {
                var isWinner =
                    (game.Phase == PhaseType.Off && (dice.IsCraps || dice.IsYo)) ||
                    (game.Phase == PhaseType.On && dice.Die1 + dice.Die2 == game.Point);
                return isWinner;
            };

            Func<Game, Dice, bool> IsLoser = (game, dice) => {
                var isLoser =
                    (game.Phase == PhaseType.Off && (
                    dice.Die1 + dice.Die2 == 2 ||
                    dice.Die1 + dice.Die2 == 3 ||
                    dice.Die1 + dice.Die2 == 12)) ||
                    (game.Phase == PhaseType.On && dice.Die1 + dice.Die2 == 7);
                return isLoser;
            };

            return base.Result(
                IsWinner(game, new Dice(dice)), 
                IsLoser(game, new Dice(dice)),
                Lookups.Pass);
        }
    }
}
