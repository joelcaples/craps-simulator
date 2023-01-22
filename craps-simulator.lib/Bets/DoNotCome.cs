using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {
    public class DoNotCome : _Bet, IBet {

        public string Name => "Don't Come";
        public BetType Type => BetType.DoNotCome;

        private short _point;

        public short Point {
            get { return _point; }
            set {
                if (!(new List<short>() { 0, 4, 5, 6, 8, 9, 10 }.Contains(value)))
                    throw new InvalidDataException();
                _point = value; 
            }
        }

        private PhaseType Phase {
            get {
                return new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(_point) ? PhaseType.On : PhaseType.Off;
            }
        }

        public IBetResult Result(Game game, Dice dice) {

            var isWinner =
                (this.Phase == PhaseType.Off &&
                new List<short>() { 2, 3, 12 }.Contains(dice.Roll)) ||
                (this.Phase == PhaseType.On && dice.IsCraps);

            var isLoser =
                (this.Phase == PhaseType.Off && (dice.IsCraps || dice.IsYo)) ||
                (this.Phase == PhaseType.On && dice.Roll == _point);

            if (game.Phase == PhaseType.Off && 
                new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(dice.Roll))
                _point = dice.Roll;

            return new BetResult(
                isWinner 
                    ? (int)Math.Round(this.Bet * Lookups.DoNotCome.Pays, MidpointRounding.ToZero) 
                    : 0,
                isWinner,
                isLoser,
                isWinner ? $"{Name} Winner" : isLoser ? $"{Name} Loser" : string.Empty);
        }
    }
}
