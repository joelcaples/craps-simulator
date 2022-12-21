using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    internal class HardTen : _HardFourOrTen, IBet {
        public HardTen() :base(10) { }
    }
}
