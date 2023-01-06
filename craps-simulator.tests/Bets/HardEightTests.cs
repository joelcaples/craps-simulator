using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class HardEightTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new HardEight().Name;
            Assert.Equal("Hard Eight", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new HardEight().Type;
            Assert.Equal(BetType.HardEight, betType);
        }

        [Theory]
        [InlineData(4, 4, true, false, 5 * 9 / 1)]
        [InlineData(1, 2, false, false, 0)]
        [InlineData(3, 5, false, true, 0)]
        [InlineData(1, 6, false, true, 0)]
        public void ResultTest(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardEight = new HardEight();
            hardEight.PlaceBet(5);
            var result = hardEight.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
