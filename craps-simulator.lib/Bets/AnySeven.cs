using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class AnySeven : BetBase, IBet {

        public override string Name => $"Any Seven";
        public BetType Type => BetType.AnySeven;
        public override bool IsWinner(Dice dice) => (dice.Roll == 7);
        public override bool IsLoser(Dice dice) => !IsWinner(dice);
        public override int Pays => (int)Math.Round(this.Bet * Lookups.AnySeven.Pays, MidpointRounding.ToZero);
    }
}
