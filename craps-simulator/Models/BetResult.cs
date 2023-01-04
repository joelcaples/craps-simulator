using craps_simulator.Interfaces;

namespace craps_simulator.Models {
    internal class BetResult : IBetResult {

        public decimal Bet { get; set; } = 0;
        public bool IsWinner { get; set; } = false;
        public bool IsLoser { get; set; } = false;
        public decimal Pays { get; set; } = 0;
        public string Msg { get; set; } = string.Empty;
    }
}
