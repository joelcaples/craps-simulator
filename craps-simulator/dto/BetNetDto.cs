using craps_simulator.Lib.Interfaces;

namespace craps_simulator.dto {
    public class BetNetDto {
        public IBet? Bet { get; set; }
        public int SessionNet { get; set;}
        public int TotalNet { get; set;}
    }
}
