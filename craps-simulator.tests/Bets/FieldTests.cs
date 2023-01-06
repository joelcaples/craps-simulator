using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class FieldTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new Field().Name;
            Assert.Equal("Field", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new Field().Type;
            Assert.Equal(BetType.Field, betType);
        }

        [Theory]
        [InlineData(1, 1, true, false, 10)] // Win on 2
        [InlineData(1, 2, true, false, 5)]  // Win on 3
        [InlineData(1, 3, true, false, 5)]  // Win on 4
        [InlineData(3, 6, true, false, 5)]  // Win on 9
        [InlineData(4, 6, true, false, 5)]  // Win on 10
        [InlineData(5, 6, true, false, 5)]  // Win on 11
        [InlineData(6, 6, true, false, 10)] // Win on 12
        [InlineData(1, 4, false, true, 0)] // Lose on 5
        [InlineData(1, 5, false, true, 0)] // Lose on 6
        [InlineData(2, 5, false, true, 0)] // Lose on 7
        [InlineData(4, 4, false, true, 0)] // Lose on 8
        public void ResultTest(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var field = new Field();
            field.PlaceBet(5);
            var result = field.Result(new Game() { }, new(die1, die2));
            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
