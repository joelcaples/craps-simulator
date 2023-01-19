using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class DoNotComeTests
    {
        [Fact]
        public void GetNameTest()
        {
            var name = new DoNotCome().Name;
            Assert.Equal("Don't Come", name);
        }

        [Fact]
        public void GetTypeTest()
        {
            var betType = new DoNotCome().Type;
            Assert.Equal(BetType.DoNotCome, betType);
        }


        [Theory]
        [InlineData(PhaseType.Off, 0, 6, 1, false, true, 0)] // Craps Lose
        [InlineData(PhaseType.Off, 0, 1, 1, true, false, 5)] // Comeout win on 2
        [InlineData(PhaseType.Off, 0, 2, 1, true, false, 5)] // Comeout win on 3
        [InlineData(PhaseType.Off, 0, 6, 6, true, false, 5)] // Comeout win on 12
        [InlineData(PhaseType.On, 4, 6, 1, true, false, 5)]  // Craps Win
        [InlineData(PhaseType.On, 4, 1, 1, false, false, 0)] // Point was not hit
        [InlineData(PhaseType.On, 4, 3, 1, false, true, 0)]  // Point was hit
        public void ResultTest(PhaseType phase, short point, short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var doNotCome = new DoNotCome() { Point = point };
            doNotCome.PlaceBet(5);
            var result = doNotCome.Result(new Game() { Phase = phase }, new Dice(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Fact]
        public void GetSetPointTest() {
            var come = new Come();
            Assert.Equal(0, come.Point);
            come.Point = 0;
            Assert.Equal(0, come.Point);
            come.Point = 4;
            Assert.Equal(4, come.Point);
            come.Point = 5;
            Assert.Equal(5, come.Point);
            come.Point = 6;
            Assert.Equal(6, come.Point);
            come.Point = 8;
            Assert.Equal(8, come.Point);
            come.Point = 9;
            Assert.Equal(9, come.Point);
            come.Point = 10;
            Assert.Equal(10, come.Point);

            var e = Record.Exception(() => {
                come.Point = 99;
            });
            Assert.NotNull(e);
        }

    }
}
