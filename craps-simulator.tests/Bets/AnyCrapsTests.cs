using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class AnyCrapsTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new AnyCraps().Name;
            Assert.Equal("Any Craps", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new AnyCraps().Type;
            Assert.Equal(BetType.AnyCraps, betType);
        }

        [Theory]
        [InlineData(1, 1, true, false, 35)] // 
        [InlineData(1, 2, true, false, 35)] // 
        [InlineData(2, 1, true, false, 35)] // 
        [InlineData(6, 6, true, false, 35)] // 
        [InlineData(6, 1, false, true, 0)]  // 
        [InlineData(1, 5, false, true, 0)]  // 
        [InlineData(3, 3, false, true, 0)]  // 
        public void ResultTest(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var anyCraps = new AnyCraps();
            anyCraps.PlaceBet(5);
            var dice = new Dice(die1, die2);
            var result = anyCraps.Result(new Game() {  }, dice);

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
