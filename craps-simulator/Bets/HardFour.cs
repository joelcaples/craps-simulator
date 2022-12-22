using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    public class HardFour : _Hardway, IBet {
        public string Name {
            get {
                return "Hard Four";
            }
        }
        public HardFour() :base(4) { }
    }
}
