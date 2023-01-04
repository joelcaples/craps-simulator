namespace craps_simulator.Interfaces {
    public interface IBetResult {
        bool IsWinner { get; set; }
        bool IsLoser { get; set; }
        decimal Pays { get; set; }
        string Msg { get; set; }
    }
}
