using craps_simulator.Lib.Interfaces;

namespace craps_simulator.Lib.Bets
{
    public class HardFour : _Hardway, IBet {
        public string Name => "Hard Four";
        public BetType Type => BetType.HardFour;
        public HardFour() :base(4) { }
    }
}
