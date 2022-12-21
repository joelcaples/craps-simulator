using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    internal class HardTen : _HardFourOrTen, IBet {

        public override float Bet {
            get {
                return base.Bet;
            }
        }

        public HardTen() :base(10) { }
    }
}
