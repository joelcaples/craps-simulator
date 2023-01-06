using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class TakeOddsTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new TakeOdds().Name;
            Assert.Equal("Take Odds", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new TakeOdds().Type;
            Assert.Equal(BetType.TakeOdds, betType);
        }

        [Theory]
        [InlineData(4, 2, 2, 10, true, false, 20)] // Hit 4
        [InlineData(5, 2, 3, 10, true, false, 15)] // Hit 5
        [InlineData(6, 2, 4, 10, true, false, 12)] // Hit 6 (6/5 Payout)
        [InlineData(8, 2, 6, 10, true, false, 12)] // Hit 8 (6/5 Payout)
        [InlineData(9, 3, 6, 10, true, false, 15)] // Hit 9
        [InlineData(10, 4, 6, 10, true, false, 20)] // Hit 10
        [InlineData(4, 1, 6, 10, false, true, 0)] // Craps 7
        [InlineData(4, 1, 1, 10, false, false, 0)] // Miss
        public void Take2xOddsResultTest(short point, short die1, short die2, int bet, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var place = new TakeOdds();
            place.PlaceBet(bet);
            var result = place.Result(new Game() { Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
