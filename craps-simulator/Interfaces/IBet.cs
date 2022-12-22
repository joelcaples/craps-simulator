namespace craps_simulator.Interfaces
{
    internal interface IBet {

        public string Name { get; }
        public decimal Bet { get; }
        void PlaceBet(decimal bet);
        public IBetResult Result(Game game, (short die1, short die2) dice);
        public decimal SessionResult { get; }
    }
}
