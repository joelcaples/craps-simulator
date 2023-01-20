using craps_simulator.Lib.Interfaces;

namespace craps_simulator.Lib.Bets
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

        public HardTen() :base(HardWayRollResult.Ten) { }
    }
}
