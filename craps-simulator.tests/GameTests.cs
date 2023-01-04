using craps_simulator.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests {

    public class GameTests {

        [Theory]
        [InlineData(0, 3, 2, PhaseType.On)] // Point was set
        [InlineData(5, 3, 2, PhaseType.Off)] // Point was hit
        [InlineData(5, 1, 1, PhaseType.On)] // Point was not hit (2)
        [InlineData(5, 1, 2, PhaseType.On)] // Point was not hit (3)
        [InlineData(5, 1, 3, PhaseType.On)] // Point was not hit (4)
        [InlineData(5, 1, 5, PhaseType.On)] // Point was not hit (6)
        [InlineData(5, 2, 6, PhaseType.On)] // Point was not hit (8)
        [InlineData(5, 3, 6, PhaseType.On)] // Point was not hit (9)
        [InlineData(5, 4, 6, PhaseType.On)] // Point was not hit (10)
        [InlineData(5, 5, 6, PhaseType.On)] // Point was not hit (11)
        [InlineData(5, 6, 6, PhaseType.On)] // Point was not hit (12)
        [InlineData(5, 3, 4, PhaseType.Off)] // Craps 7
        public void AdvanceTest(short point, short die1, short die2, PhaseType expectedPhase) {
            var throwResult = GameLib.Advance(new Game() { Point = point }, new Models.Dice(die1, die2));
            Assert.Equal(expectedPhase, throwResult.Game.Phase);
        }
    }
}
