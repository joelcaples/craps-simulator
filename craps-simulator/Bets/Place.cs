using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {

    public class Place : _Bet, IBet {

        private readonly short _spot;

        public Place(short spot) {
            _spot = spot;
        }

        public string Name => $"Place {_spot}";

        public IBetResult Result(Game game, (short die1, short die2) dice) {
            if (game.Phase == PhaseType.Off)
                return new BetResult() { };

            var roll = dice.die1 + dice.die2;
            var isCraps = roll == 7;

            var isLoser = isCraps;
            var isWinner = roll == _spot;

            return base.Result(isWinner, isLoser, game.Point switch {
                4 or 10 => Lookups.PlaceFourOrTen,
                5 or 9 => Lookups.PlaceFiveOrNine,
                6 or 8 => Lookups.PlaceSixOrEight,
                _ => throw new Exception("Invalid Place Bet"),
            });
        }
    }
}
