namespace craps_simulator.Interfaces {
    public interface IBetResult {
        float Bet { get; set; }
        bool IsWinner { get; set; }
        bool IsLoser { get; set; }
        float Pays { get; set; }
    }
}
