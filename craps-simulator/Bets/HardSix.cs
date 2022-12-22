using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    public class HardSix : _Hardway, IBet {
        public string Name {
            get {
                return "Hard Six";
            }
        }
        public HardSix() :base(6) { }
    }
}
