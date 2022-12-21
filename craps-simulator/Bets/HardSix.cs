using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    internal class HardSix : _Hardway, IBet {
        public string Name {
            get {
                return "Hard Four";
            }
        }
        public HardSix() :base(4) { }
    }
}
