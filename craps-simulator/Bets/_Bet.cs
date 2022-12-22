namespace craps_simulator.Bets {
    public class _Bet {

        protected float _bet = 0;
        protected float _sessionResult = 0;

        public virtual float Bet {
            get {
                return _bet;
            }
        }

        public void PlaceBet(float bet) {
            _bet += bet;
        }

        public float SessionResult {
            get {
                return _sessionResult;
            }
        }
    }
}
