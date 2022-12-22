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

            if (isWinner) {
                _sessionResult += base.Bet;
                return new BetResult() { IsWinner = true, Bet=base.Bet, Pays=PlacePayout()};
            }

            if (isLoser) {
                _sessionResult -= base.Bet;
                _bet = 0;
                return new BetResult() { IsLoser = true };
            }

            return new BetResult() { };
        }

        private int PlacePayout() {
            return _spot switch {
                4 or 10 => (int)Math.Round(Lookups.PlaceFourOrTen.Pays * _bet, 0, MidpointRounding.ToZero),
                5 or 9 => (int)Math.Round(Lookups.PlaceFiveOrNine.Pays * _bet, 0, MidpointRounding.ToZero),
                6 or 8 => (int)Math.Round(Lookups.PlaceSixOrEight.Pays * _bet, 0, MidpointRounding.ToZero),
                _ => throw new Exception("Invalid Place Bet"),
            };
        }
    }
}
