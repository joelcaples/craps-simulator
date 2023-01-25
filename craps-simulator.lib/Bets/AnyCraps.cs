using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class AnyCraps : BetBase, IBet {

        public override string Name => $"Any Craps";
        public BetType Type => BetType.AnyCraps;
        public override bool IsWinner(Dice dice) => new List<short>() { 2, 3, 12 }.Contains(dice.Roll);
        public override bool IsLoser(Dice dice) => !IsWinner(dice);
        public override int Pays => (int)Math.Round(this.Bet * Lookups.AnyCraps.Pays, MidpointRounding.ToZero);
    }
}
