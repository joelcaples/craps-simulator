using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class Place : _Bet, IBet {

        private readonly short _spot;

        public Place(short spot) {
            if (!new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(spot))
                throw new InvalidDataException();
            _spot = spot;
        }

        public string Name => $"Place {_spot}";
        public BetType Type => _spot switch { 
            4 => BetType.PlaceFour,
            5 => BetType.PlaceFive,
            6 => BetType.PlaceSix,
            8 => BetType.PlaceEight,
            9 => BetType.PlaceNine,
            10 => BetType.PlaceTen,
            _ => throw new InvalidDataException() };

        public IBetResult Result(Game game, Dice dice) {

            if (_spot == game.Point)
                return new BetResult(this.Bet) { };

            if (game.Phase == PhaseType.Off)
                return new BetResult(this.Bet) { };

            var roll = dice.Roll;

            var isLoser = dice.IsCraps;
            var isWinner = roll == _spot;
            var pays = isWinner
                    ? this.Bet * _spot switch {
                        4 or 10 => Lookups.PlaceFourOrTen.Pays,
                        5 or 9 => Lookups.PlaceFiveOrNine.Pays,
                        6 or 8 => Lookups.PlaceSixOrEight.Pays,
                        _ => throw new Exception("Invalid Place Bet"),
                    }
                    : 0;

            return new BetResult(
                //this.Bet, 
                (int)Math.Round(pays, 0, MidpointRounding.ToZero), 
                isWinner, 
                isLoser);
        }
    }
}
