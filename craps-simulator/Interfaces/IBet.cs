namespace craps_simulator.Interfaces
{
    internal interface IBet {

        public string Name { get; }
        public float Bet { get; }
        void PlaceBet(float bet);
        public IBetResult Result(Game game, (int die1, int die2) dice);
        public float SessionResult { get; }
    }
}
