using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    public class HardTen : _Hardway, IBet {

        public string Name {
            get {
                return "Hard Ten";
            }
        }
        public BetType Type => BetType.HardTen;

        public override int Bet {
            get {
                return base.Bet;
            }
        }

        public HardTen() :base(10) { }
    }
}
