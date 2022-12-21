namespace craps_simulator.Bets {
    internal class _Bet {

        protected float _bet = 0;

        public virtual float Bet {
            get {
                return _bet;
            }
        }

        public void PlaceBet(float bet) {
            _bet += bet;
        }

    }
}
