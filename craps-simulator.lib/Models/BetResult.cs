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
        public bool IsWinner { get; set; } = false;
        public bool IsLoser { get; set; } = false;
        public decimal Pays { get; set; } = 0;
        public string Msg { get; set; } = string.Empty;
    }
}
