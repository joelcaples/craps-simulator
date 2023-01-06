using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class PassTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new Pass().Name;
            Assert.Equal("Pass Line", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new Pass().Type;
            Assert.Equal(BetType.Pass, betType);
        }

        [Theory]
        [InlineData(PhaseType.Off, 0, 6, 1, true, false, 5)] // Craps Win
        [InlineData(PhaseType.Off, 0, 1, 1, false, true, 0)] // Comeout loss on 2
        [InlineData(PhaseType.Off, 0, 2, 1, false, true, 0)] // Comeout loss on 3
        [InlineData(PhaseType.Off, 0, 6, 6, false, true, 0)] // Comeout loss on 12
        [InlineData(PhaseType.On, 4, 6, 1, false, true, 0)]  // Craps Lose
        [InlineData(PhaseType.On, 4, 1, 1, false, false, 0)] // Point was not hit
        [InlineData(PhaseType.On, 4, 3, 1, true, false, 5)]  // Point was hit
        public void ResultTest(PhaseType phase, short point, short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var passLine = new Pass();
            passLine.PlaceBet(5);
            var dice = new Dice(die1, die2);
            var result = passLine.Result(new Game() { Phase = phase, Point = point }, dice);

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);

            if (phase == PhaseType.Off && dice.Roll == 11)
                Assert.Equal("Craps Winner", result.Msg);
        }
    }
}
