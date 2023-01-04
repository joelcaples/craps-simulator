using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {
    public class _Bet {

        protected int _bet = 0;
        protected decimal _sessionResult = 0;

        public virtual int Bet {
            get {
                return _bet;
            }
            //set { 
            //    _bet = value;
            //}
        }

        public void PlaceBet(int bet) {
            _bet += bet;
        }

        public decimal SessionResult {
            get {
                return _sessionResult;
            }
        }

        protected IBetResult Result(bool isWinner, bool isLoser, ExpectedEdge edge, string msg = "") {
            if (isWinner) {
                _sessionResult += _bet;
                return new BetResult() { IsWinner = true, Bet = _bet, Pays = (int)Math.Round(_bet * edge.Pays, 0, MidpointRounding.ToZero) };
            }
            
            if (isLoser) {
                _sessionResult -= _bet;
                //_bet = 0;
                return new BetResult() { IsLoser = true, Bet = _bet, Pays = 0 };
            }

            return new BetResult() { Pays = 0, Msg = msg};
        }

    }
}
