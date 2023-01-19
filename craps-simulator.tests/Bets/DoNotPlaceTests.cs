using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class DoNotPlaceTests {
        [Fact]
        public void GetNameTest() {
            Assert.Equal("Don't Place 4", new DoNotPlace(4).Name);
            Assert.Equal("Don't Place 5", new DoNotPlace(5).Name);
            Assert.Equal("Don't Place 6", new DoNotPlace(6).Name);
            Assert.Equal("Don't Place 8", new DoNotPlace(8).Name);
            Assert.Equal("Don't Place 9", new DoNotPlace(9).Name);
            Assert.Equal("Don't Place 10", new DoNotPlace(10).Name);
        }

        [Fact]
        public void GetTypeTest() {
            Assert.Equal(BetType.DoNotPlaceFour, new DoNotPlace(4).Type);
            Assert.Equal(BetType.DoNotPlaceFive, new DoNotPlace(5).Type);
            Assert.Equal(BetType.DoNotPlaceSix, new DoNotPlace(6).Type);
            Assert.Equal(BetType.DoNotPlaceEight, new DoNotPlace(8).Type);
            Assert.Equal(BetType.DoNotPlaceNine, new DoNotPlace(9).Type);
            Assert.Equal(BetType.DoNotPlaceTen, new DoNotPlace(10).Type);
            
            var e = Record.Exception(() => {
                var _ = new DoNotPlace(99).Type;
            });
            Assert.NotNull(e);

            var e2 = Record.Exception(() => {
                var _ = new DoNotPlace(99);
            });
            Assert.NotNull(e2);
        }

        [Theory]
        [InlineData(5, 4, 2, 2, 5, false, true, 0)] // 4
        [InlineData(4, 5, 2, 3, 5, false, true, 0)] // 5
        [InlineData(4, 6, 2, 4, 5, false, true, 0)] // 6 Incorrect Bet (5)
        [InlineData(4, 8, 2, 6, 5, false, true, 0)] // 8 Incorrect Bet (5)
        [InlineData(4, 6, 2, 4, 6, false, true, 0)] // 6 w/Correct bet (6)
        [InlineData(4, 8, 2, 6, 6, false, true, 0)] // 8 w/Correct bet (6)
        [InlineData(4, 9, 3, 6, 5, false, true, 0)] // 9
        [InlineData(4, 10, 4, 6, 5, false, true, 0)] // 10
        [InlineData(5, 4, 1, 6, 5, true, false, 2)] // Craps 7
        [InlineData(5, 4, 1, 1, 5, false, false, 0)] // 
        public void ResultTest(short point, short spot, short die1, short die2, int bet, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var doNotPlace = new DoNotPlace(spot);
            doNotPlace.PlaceBet(bet);
            var result = doNotPlace.Result(new Game() { Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
