namespace craps_simulator.Lib.Interfaces {
    public interface IBetResult {
        //int BetAmt { get; set; }
        bool IsWinner { get; }
        bool IsLoser { get; }
        decimal Pays { get; }
        string Msg { get; }
    }
}
