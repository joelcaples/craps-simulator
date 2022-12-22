namespace craps_simulator.Interfaces
{
    internal interface IBet {

        public string Name { get; }
        public int Bet { get; }
        void PlaceBet(int bet);
        public IBetResult Result(Game game, (short die1, short die2) dice);
        public decimal SessionResult { get; }
    }
}
