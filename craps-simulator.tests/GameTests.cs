using craps_simulator.Lib.Lib;
using craps_simulator.Lib.Models;
using System;

namespace craps_simulator.tests {

    public class GameTests {

        [Theory]
        [InlineData(0, 3, 2, 5, PhaseType.On, false, false, true)] // Point was set
        [InlineData(5, 3, 2, 0, PhaseType.Off, true, false, false)] // Point was hit
        [InlineData(5, 1, 1, 5, PhaseType.On, false, false, false)] // Point was not hit (2)
        [InlineData(5, 1, 2, 5, PhaseType.On, false, false, false)] // Point was not hit (3)
        [InlineData(5, 1, 3, 5, PhaseType.On, false, false, false)] // Point was not hit (4)
        [InlineData(5, 1, 5, 5, PhaseType.On, false, false, false)] // Point was not hit (6)
        [InlineData(5, 2, 6, 5, PhaseType.On, false, false, false)] // Point was not hit (8)
        [InlineData(5, 3, 6, 5, PhaseType.On, false, false, false)] // Point was not hit (9)
        [InlineData(5, 4, 6, 5, PhaseType.On, false, false, false)] // Point was not hit (10)
        [InlineData(5, 5, 6, 5, PhaseType.On, false, false, false)] // Point was not hit (11)
        [InlineData(5, 6, 6, 5, PhaseType.On, false, false, false)] // Point was not hit (12)
        [InlineData(5, 3, 4, 0, PhaseType.Off, false, true, false)] // Craps 7
        public void AdvanceTest(
            short point, 
            short die1, 
            short die2, 
            short expectedPoint, 
            PhaseType expectedPhase, 
            bool expectedIsWinner, 
            bool expectedIsLoser, 
            bool expectedPointWasSet) {
            
            var throwResult = GameLib.Advance(new Game() { Point = point }, new Dice(die1, die2));
            Assert.Equal(expectedPhase, throwResult.Game.Phase);
            Assert.Equal(expectedPoint, throwResult.Game.Point);
            Assert.Equal(expectedIsWinner, throwResult.IsWinner);
            Assert.Equal(expectedIsLoser, throwResult.IsLoser);
            Assert.Equal(expectedPointWasSet, throwResult.PointWasSet);
        }

        [Fact]
        public void OffTest() {
            var game = new Game() { Point = 5 };
            Assert.Equal(5, game.Point);
            game.Off();
            Assert.Equal(0, game.Point);
        }

        [Fact]
        public void SetPointTest() {
            var game = new Game() { Point = 5 };
            Assert.Equal(5, game.Point);
            game.Point = 6;
            Assert.Equal(6, game.Point);
        }

        [Fact]
        public void SetPointExceptionTest() {
            var game = new Game() { Point = 5 };
            Assert.Equal(5, game.Point);

            var e = Record.Exception(() => {
                game.Point = 2;
            });
            Assert.NotNull(e);
        }
    }
}
