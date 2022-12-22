﻿using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {

    public class Field : _Bet, IBet {

        public string Name => $"Field";

        public IBetResult Result(Game game, (int die1, int die2) dice) {
            //if (game.Phase == PhaseType.Off)
            //    return new BetResult() { };

            var roll = dice.die1 + dice.die2;
            var isWinner = (new List<int>() { 3, 4, 9, 10, 11 }).Contains(roll);
            var isLoser = !isWinner;

            if (isWinner) {
                _sessionResult += Pays(roll);
                _bet = 0;
                return new BetResult() { IsWinner = true, Bet=base.Bet, 
                    Pays= Pays(roll)
                };
            }

            if (isLoser) {
                _sessionResult -= Pays(roll);
                _bet = 0;
                return new BetResult() { IsLoser = true };
            }

            return new BetResult() { };
        }

        private float Pays(int roll) => (new List<int>() { 3, 4, 9, 10, 11 }).Contains(roll) ? base.Bet : base.Bet * 2;
    }
}
