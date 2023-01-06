using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class PlaceTests
    {
        [Fact]
        public void GetNameTest() {
            Assert.Equal("Place 4", new Place(4).Name);
            Assert.Equal("Place 5", new Place(5).Name);
            Assert.Equal("Place 6", new Place(6).Name);
            Assert.Equal("Place 8", new Place(8).Name);
            Assert.Equal("Place 9", new Place(9).Name);
            Assert.Equal("Place 10", new Place(10).Name);
        }

        [Fact]
        public void GetTypeTest() {
            Assert.Equal(BetType.PlaceFour, new Place(4).Type);
            Assert.Equal(BetType.PlaceFive, new Place(5).Type);
            Assert.Equal(BetType.PlaceSix, new Place(6).Type);
            Assert.Equal(BetType.PlaceEight, new Place(8).Type);
            Assert.Equal(BetType.PlaceNine, new Place(9).Type);
            Assert.Equal(BetType.PlaceTen, new Place(10).Type);
            
            var e = Record.Exception(() => {
                var _ = new Place(99).Type;
            });
            Assert.NotNull(e);

            var e2 = Record.Exception(() => {
                var _ = new Place(99);
            });
            Assert.NotNull(e2);
        }

        [Theory]
        [InlineData(5, 4, 2, 2, 5, true, false, 9)] // Hit 4
        [InlineData(4, 5, 2, 3, 5, true, false, 7)] // Hit 5
        [InlineData(4, 6, 2, 4, 5, true, false, 5 * (7 / 6))] // Hit 6 Incorrect Bet (5)
        [InlineData(4, 8, 2, 6, 5, true, false, 5 * (7 / 6))] // Hit 8 Incorrect Bet (5)
        [InlineData(4, 6, 2, 4, 6, true, false, 7 * (7 / 6))] // Hit 6 w/Correct bet (6)
        [InlineData(4, 8, 2, 6, 6, true, false, 7 * (7 / 6))] // Hit 8 w/Correct bet (6)
        [InlineData(4, 9, 3, 6, 5, true, false, 7)] // Hit 9
        [InlineData(4, 10, 4, 6, 5, true, false, 9)] // Hit 10
        [InlineData(5, 4, 1, 6, 5, false, true, 0)] // Craps 7
        [InlineData(5, 4, 1, 1, 5, false, false, 0)] // Miss
        public void ResultTest(short point, short spot, short die1, short die2, int bet, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var place = new Place(spot);
            place.PlaceBet(bet);
            var result = place.Result(new Game() { Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
