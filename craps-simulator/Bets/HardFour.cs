using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    internal class HardFour : _HardFourOrTen, IBet {
        public string Name {
            get {
                return "Hard Four";
            }
        }
        public HardFour() :base(4) { }
    }
}
