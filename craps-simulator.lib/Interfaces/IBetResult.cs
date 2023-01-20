namespace craps_simulator.Lib.Interfaces {
    public interface IBetResult {
        //int BetAmt { get; set; }
        bool IsWinner { get; set; }
        bool IsLoser { get; set; }
        decimal Pays { get; set; }
        string Msg { get; set; }
    }
}
