using craps_simulator.Lib.Interfaces;

namespace craps_simulator.Lib.Models {
    internal class BetResult : IBetResult {

        public BetResult(
            //int betAmt, 
            decimal pays = 0, 
            bool isWinner = false, 
            bool isLoser = false, 
            string msg = "") {
            
            //BetAmt = betAmt;
            IsWinner = isWinner;
            IsLoser = isLoser;
            Pays = pays;
            Msg = msg;
        }

        //public int BetAmt { get; set; } = 0;
        public bool IsWinner { get; } = false;
        public bool IsLoser { get; } = false;
        public decimal Pays { get; } = 0;
        public string Msg { get; } = string.Empty;
    }
}
