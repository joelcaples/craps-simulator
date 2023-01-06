using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class HardSixTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new HardSix().Name;
            Assert.Equal("Hard Six", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new HardSix().Type;
            Assert.Equal(BetType.HardSix, betType);
        }

        [Theory]
        [InlineData(3, 3, true, false, 5 * 9 / 1)]
        [InlineData(1, 2, false, false, 0)]
        [InlineData(1, 5, false, true, 0)]
        [InlineData(1, 6, false, true, 0)]
        public void ResultTest(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardSix = new HardSix();
            hardSix.PlaceBet(5);
            var result = hardSix.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
