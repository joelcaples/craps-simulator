using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    internal class HardEight : _Hardway, IBet {
        public string Name {
            get {
                return "Hard Four";
            }
        }
        public HardEight() :base(8) { }
    }
}
