﻿using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class AnyCraps : _Bet, IBet {

        public string Name => $"Any Craps";
        public BetType Type => BetType.AnyCraps;

        public IBetResult Result(Game game, Dice dice) {

            static bool IsWinner(Dice dice) => new List<short>() { 2, 3, 12 }.Contains(dice.Roll);
            static bool IsLoser(Dice dice) => !IsWinner(dice);

            var isWinner = IsWinner(dice);
            var isLoser = IsLoser(dice);

            return new BetResult(
                isWinner 
                    ? (int)Math.Round(this.Bet * Lookups.AnyCraps.Pays, MidpointRounding.ToZero)
                    : 0, 
                isWinner, 
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);
        }
    }
}
