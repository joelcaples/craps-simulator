using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class HopTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new Hop(1, 1).Name;
            Assert.Equal("Hop", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new Hop(1, 1).Type;
            Assert.Equal(BetType.OneWayHop, betType);
            betType = new Hop(1, 3).Type;
            Assert.Equal(BetType.TwoWayHop, betType);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, true, false, 30)] // 
        [InlineData(1, 3, 3, 1, true, false, 15)] // 
        [InlineData(1, 3, 3, 2, false, true, 0)] // 
        public void ResultTest(short hopDie1, short hopeDie2, short rollDie1, short rollDie2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var anyCraps = new Hop(hopDie1, hopeDie2);
            anyCraps.PlaceBet(1);
            var dice = new Dice(rollDie1, rollDie2);
            var result = anyCraps.Result(new Game() {  }, dice);

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
