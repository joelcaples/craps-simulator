using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class DoNotPassTests
    {
        [Fact]
        public void GetNameTest() {
            var name = new DoNotPass().Name;
            Assert.Equal("Don't Pass", name);
        }

        [Fact]
        public void GetTypeTest() {
            var betType = new DoNotPass().Type;
            Assert.Equal(BetType.DoNotPass, betType);
        }

        [Theory]
        [InlineData(PhaseType.Off, 0, 6, 1, false, true, 0)] // Craps!
        [InlineData(PhaseType.Off, 0, 2, 1, true, false, 5)] // Comeout loss on 3
        [InlineData(PhaseType.Off, 0, 6, 6, true, false, 5)] // Comeout loss on 12
        [InlineData(PhaseType.On, 4, 6, 1, true, false, 5)]  // Craps 7
        [InlineData(PhaseType.On, 4, 1, 1, false, false, 0)] // Point was not hit
        [InlineData(PhaseType.On, 4, 3, 1, false, true, 0)]  // Point was hit
        public void ResultTest(PhaseType phase, short point, short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var doNotPass = new DoNotPass();
            doNotPass.PlaceBet(5);
            var result = doNotPass.Result(new Game() { Phase = phase, Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
