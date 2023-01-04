using craps_simulator.Lib.Interfaces;

namespace craps_simulator.Lib.Bets
{
    public class HardEight : _Hardway, IBet {
        public string Name => "Hard Eight";
        public BetType Type => BetType.HardEight;
        public HardEight() :base(8) { }
    }
}
