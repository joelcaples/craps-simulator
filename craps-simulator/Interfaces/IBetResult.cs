namespace craps_simulator.Interfaces {
    public interface IBetResult {
        decimal Bet { get; set; }
        bool IsWinner { get; set; }
        bool IsLoser { get; set; }
        int Pays { get; set; }
    }
}
