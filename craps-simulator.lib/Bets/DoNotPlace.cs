using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class DoNotPlace : _Bet, IBet {

        private readonly short _spot;

        public DoNotPlace(short spot) {
            if (!new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(spot))
                throw new InvalidDataException();
            _spot = spot;
        }

        public string Name => $"Don't Place {_spot}";
        public BetType Type => _spot switch { 
            4 => BetType.DoNotPlaceFour,
            5 => BetType.DoNotPlaceFive,
            6 => BetType.DoNotPlaceSix,
            8 => BetType.DoNotPlaceEight,
            9 => BetType.DoNotPlaceNine,
            10 => BetType.DoNotPlaceTen,
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
                        4 or 10 => Lookups.DoNotPlaceFourOrTen.Pays,
                        5 or 9 => Lookups.DoNotPlaceFiveOrNine.Pays,
                        6 or 8 => Lookups.DoNotPlaceSixOrEight.Pays,
                        _ => throw new Exception("Invalid Don't Place Bet"),
                    }
                    : 0;

            return new BetResult(
                (int)Math.Round(pays, 0, MidpointRounding.ToZero), isWinner, isLoser);
        }
    }
}
