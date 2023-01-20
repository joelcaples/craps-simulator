namespace craps_simulator.Lib.Bets {
    public class _Bet {

        protected int _bet = 0;

        public virtual int Bet {
            get {
                return _bet;
            }
        }

        public void PlaceBet(int bet) {
            _bet = bet;
        }

    }
}
