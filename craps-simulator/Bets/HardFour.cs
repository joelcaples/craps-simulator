using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    public class HardFour : _Hardway, IBet {
        public string Name => "Hard Four";
        public BetType Type => BetType.HardFour;
        public HardFour() :base(4) { }
    }
}
