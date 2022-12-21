namespace craps_simulator.Models {
    internal class BetResult {

        public float Bet { get; set; } = 0;
        public bool IsWinner { get; set; } = false;
        public bool IsLoser { get; set; } = false;
        public float Pays = 0;
    }
}
