using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    public class HardEight : _Hardway, IBet {
        public string Name {
            get {
                return "Hard Eight";
            }
        }
        public HardEight() :base(8) { }
    }
}
