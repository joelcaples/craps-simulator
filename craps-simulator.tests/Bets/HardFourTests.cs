using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class HardFourTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new HardFour().Name;
            Assert.Equal("Hard Four", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new HardFour().Type;
            Assert.Equal(BetType.HardFour, betType);
        }

        [Theory]
        [InlineData(2, 2, true, false, 5 * 7)] // Hard 4
        [InlineData(1, 2, false, false, 0)]  // Not 4
        [InlineData(1, 3, false, true, 0)]   // Soft 4
        [InlineData(1, 6, false, true, 0)]   // Craps 7
        public void ResultTest(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardFour = new HardFour();
            hardFour.PlaceBet(5);
            var result = hardFour.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
