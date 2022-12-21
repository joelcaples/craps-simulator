using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets
{
    internal class HardFour : _HardFourOrTen, IBet {
        public HardFour() :base(10) { }
    }
}
