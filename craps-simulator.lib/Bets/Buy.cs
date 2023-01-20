using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.Lib.Bets {

    public class Buy : _Bet, IBet {

        private readonly short _spot;

        public Buy(short spot) {
            if (!new List<short>() { 4, 5, 6, 8, 9, 10 }.Contains(spot))
                throw new InvalidDataException();
            _spot = spot;
        }

        public string Name => $"Buy {_spot}";
        public BetType Type => _spot switch { 
            4 => BetType.BuyFour,
            5 => BetType.BuyFive,
            6 => BetType.BuySix,
            8 => BetType.BuyEight,
            9 => BetType.BuyNine,
            10 => BetType.BuyTen,
            _ => throw new InvalidDataException() };

        public IBetResult Result(Game game, Dice dice) {

            if (game.Point == dice.Roll)
                return new BetResult(this.Bet) { };

            if (game.Phase == PhaseType.Off)
                return new BetResult(this.Bet) { };

            var isLoser = dice.IsCraps;
            var isWinner = dice.Roll == _spot;
            var pays = isWinner
                    ? this.Bet * _spot switch {
                        4 or 10 => Lookups.BuyFourOrTen.Pays - (decimal)(this.Bet * .05),
                        5 or 9 => Lookups.BuyFiveOrNine.Pays - (decimal)(this.Bet * .05),
                        6 or 8 => Lookups.BuySixOrEight.Pays - (decimal)(this.Bet * .05),
                        _ => throw new Exception("Invalid Buy Bet"),
                    }
                    : 0;

            return new BetResult(
                (int)Math.Round(pays, 0, MidpointRounding.ToZero),
                isWinner,
                isLoser);
        }
    }
}
