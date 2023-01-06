using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class HardTenTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new HardTen().Name;
            Assert.Equal("Hard Ten", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new HardTen().Type;
            Assert.Equal(BetType.HardTen, betType);
        }

        [Theory]
        [InlineData(5, 5, true, false, 5 * 7)]
        [InlineData(1, 2, false, false, 0)]
        [InlineData(1, 9, false, true, 0)]
        [InlineData(1, 6, false, true, 0)]
        public void ResultTest(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardTen = new HardTen();
            hardTen.PlaceBet(5);
            var result = hardTen.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
