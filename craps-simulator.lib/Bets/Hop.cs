﻿using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class Hop : _Bet, IBet {

        private readonly short _die1;
        private readonly short _die2;

        public Hop(short die1, short die2) {
            _die1= die1;
            _die2= die2;
        }

        public string Name => $"Hop";
        public BetType Type => (_die1 == _die2 ? BetType.OneWayHop : BetType.TwoWayHop);

        public IBetResult Result(Game game, Dice dice) {

            var hopDice = new List<short>() { _die1, _die2 };
            hopDice.Sort();
            var rolledDice = new List<short>() { dice.Die1, dice.Die2 };
            rolledDice.Sort();

            var isWinner = Enumerable.SequenceEqual(hopDice, rolledDice);
            var isLoser = !isWinner;

            return new BetResult(
                isWinner 
                    ? (int)Math.Round(this.Bet * (_die1 == _die2 ? Lookups.OneWayHop.Pays : Lookups.TwoWayHop.Pays), MidpointRounding.ToZero) 
                    : 0, 
                isWinner, 
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);
        }
    }
}
