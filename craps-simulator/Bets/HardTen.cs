using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    internal class HardTen : _Hardway, IBet {

        public string Name {
            get {
                return "Hard Ten";
            }
        }

        public override float Bet {
            get {
                return base.Bet;
            }
        }

        public HardTen() :base(10) { }
    }
}
