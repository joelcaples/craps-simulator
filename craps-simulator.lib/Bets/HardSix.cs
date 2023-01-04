using craps_simulator.Lib.Interfaces;

namespace craps_simulator.Lib.Bets
{
    public class HardSix : _Hardway, IBet {
        public string Name => "Hard Six";
        public BetType Type => BetType.HardSix;
        public HardSix() :base(6) { }
    }
}
