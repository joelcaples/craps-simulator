using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class BuyTests
    {
        [Fact]
        public void GetNameTest() {
            Assert.Equal("Buy 4", new Buy(4).Name);
            Assert.Equal("Buy 5", new Buy(5).Name);
            Assert.Equal("Buy 6", new Buy(6).Name);
            Assert.Equal("Buy 8", new Buy(8).Name);
            Assert.Equal("Buy 9", new Buy(9).Name);
            Assert.Equal("Buy 10", new Buy(10).Name);
        }

        [Fact]
        public void GetTypeTest() {
            Assert.Equal(BetType.BuyFour, new Buy(4).Type);
            Assert.Equal(BetType.BuyFive, new Buy(5).Type);
            Assert.Equal(BetType.BuySix, new Buy(6).Type);
            Assert.Equal(BetType.BuyEight, new Buy(8).Type);
            Assert.Equal(BetType.BuyNine, new Buy(9).Type);
            Assert.Equal(BetType.BuyTen, new Buy(10).Type);
            
            var e = Record.Exception(() => {
                var _ = new Buy(99).Type;
            });
            Assert.NotNull(e);

            var e2 = Record.Exception(() => {
                var _ = new Buy(99);
            });
            Assert.NotNull(e2);
        }

        [Theory]
        [InlineData(5, 4, 2, 2, 20, true, false, 19)]  // Buy 4 Win
        [InlineData(4, 10, 4, 6, 20, true, false, 19)] // Buy 10 Win
        [InlineData(4, 5, 2, 3, 20, true, false, 9)]  // Buy 5 Win
        [InlineData(4, 9, 3, 6, 20, true, false, 9)]  // Buy 9 Win
        [InlineData(4, 6, 2, 4, 20, true, false, 3)]  // Buy 6 Win Correct Bet (20)
        [InlineData(4, 8, 2, 6, 20, true, false, 3)]  // Buy 8 Win Correct Bet (20)
        [InlineData(5, 4, 1, 6, 20, false, true, 0)] // Craps 7
        [InlineData(5, 4, 1, 1, 20, false, false, 0)] // Miss
        public void ResultTest(short point, short spot, short die1, short die2, int bet, bool expectedIsWinner, bool expectedIsLoser, int expectedPays) {
            var buy = new Buy(spot);
            buy.PlaceBet(bet);
            var result = buy.Result(new Game() { Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
