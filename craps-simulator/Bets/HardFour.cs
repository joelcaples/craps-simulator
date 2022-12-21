using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    internal class HardFour : _HardFourOrTen, IBet {
        public HardFour() :base(10) { }
    }
}
