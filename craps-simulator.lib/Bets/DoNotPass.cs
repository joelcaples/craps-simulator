﻿using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {
    public class DoNotPass : _Bet, IBet {

        public string Name => "Don't Pass";
        public BetType Type => BetType.DoNotPass;

        public IBetResult Result(Game game, Dice dice) {

            Func<Game, Dice, bool> IsLoser = (game, dice) => {
                var isLoser =
                    (game.Phase == PhaseType.Off && (dice.IsCraps || dice.IsYo)) ||
                    (game.Phase == PhaseType.On && dice.Die1 + dice.Die2 == game.Point);
                return isLoser;
            };

            Func<Game, Dice, bool> IsWinner = (game, dice) => {
                var isWinner =
                    (game.Phase == PhaseType.Off && (
                    dice.Die1 + dice.Die2 == 2 ||
                    dice.Die1 + dice.Die2 == 3 ||
                    dice.Die1 + dice.Die2 == 12)) ||
                    (game.Phase == PhaseType.On && dice.Die1 + dice.Die2 == 7);
                return isWinner;
            };

            var isWinner = IsWinner(game, dice);
            var isLoser = IsLoser(game, dice);

            return new BetResult() {
                IsWinner = isWinner,
                IsLoser = isLoser,
                Pays = isWinner 
                    ? this.Bet * Lookups.Pass.Pays
                    : 0
            };
        }
    }
}