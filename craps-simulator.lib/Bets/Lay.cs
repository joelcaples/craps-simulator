using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class Lay : _Bet, IBet {

        private readonly short _spot;

        public Lay(short spot) {
            if (!new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(spot))
                throw new InvalidDataException();
            _spot = spot;
        }

        public string Name => $"Lay {_spot}";
        public BetType Type => _spot switch { 
            4 => BetType.LayFour,
            5 => BetType.LayFive,
            6 => BetType.LaySix,
            8 => BetType.LayEight,
            9 => BetType.LayNine,
            10 => BetType.LayTen,
            _ => throw new InvalidDataException() };

        public IBetResult Result(Game game, Dice dice) {

            if (_spot == game.Point)
                return new BetResult(this.Bet) { };

            if (game.Phase == PhaseType.Off)
                return new BetResult(this.Bet) { };

            var roll = dice.Roll;

            var isWinner = dice.IsCraps;
            var isLoser = roll == _spot;
            var pays = isWinner
                    ? this.Bet * _spot switch {
                        4 or 10 => Lookups.LayFourOrTen.Pays,
                        5 or 9 => Lookups.LayFiveOrNine.Pays,
                        6 or 8 => Lookups.LaySixOrEight.Pays,
                        _ => throw new Exception("Invalid Lay Bet"),
                    }
                    : 0;

            return new BetResult(
                (int)Math.Round(pays, 0, MidpointRounding.ToZero),
                isWinner,
                isLoser);
        }
    }
}
