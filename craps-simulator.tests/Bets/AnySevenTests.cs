using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class AnySevenTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new AnySeven().Name;
            Assert.Equal("Any Seven", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new AnySeven().Type;
            Assert.Equal(BetType.AnySeven, betType);
        }

        [Theory]
        [InlineData(1, 6, true, false, 4)] // 
        [InlineData(2, 5, true, false, 4)] // 
        [InlineData(3, 4, true, false, 4)] // 
        [InlineData(4, 3, true, false, 4)] // 
        [InlineData(1, 1, false, true, 0)]  // 
        [InlineData(1, 5, false, true, 0)]  // 
        [InlineData(3, 3, false, true, 0)]  // 
        public void ResultTest(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var anySeven = new AnySeven();
            anySeven.PlaceBet(1);
            var dice = new Dice(die1, die2);
            var result = anySeven.Result(new Game() {  }, dice);

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
