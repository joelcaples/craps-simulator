using craps_simulator.Bets;
using craps_simulator.Interfaces;

namespace craps_simulator.tests {
    public class Bets {

        [Theory]
        [InlineData(1, 1, 10)]
        [InlineData(1, 2, 5)]
        public void FieldBetWin(short die1, short die2, float expectedPays) {
            var field = new Field();
            field.PlaceBet(5);
            var result = field.Result(new Game() { }, new(die1, die2));
            Assert.True(result.IsWinner);
            Assert.False(result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Fact]
        public void FieldBetLose() {
            var field = new Field();
            field.PlaceBet(5);
            var result = field.Result(new Game() { }, new(1, 4));
            Assert.False(result.IsWinner);
            Assert.True(result.IsLoser);
            Assert.Equal(0, result.Pays);
        }

        [Theory]
        [InlineData(2, 2, true, false, 5*7)]
        [InlineData(1, 2, false, false, 0)]
        [InlineData(1, 3, false, true, 0)]
        [InlineData(1, 6, false, true, 0)]
        public void HardFour(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, float expectedPays) {
            var hardFour = new HardFour();
            hardFour.PlaceBet(5);
            //Func<float, IBetResult> GetResult = (bet) => hardFour.Result(new Game() { }, new(die1, die2));
            //var result = GetResult(5);
            var result = hardFour.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Theory]
        [InlineData(3, 3, true, false, 5 * 9/1)]
        [InlineData(1, 2, false, false, 0)]
        [InlineData(1, 5, false, true, 0)]
        [InlineData(1, 6, false, true, 0)]
        public void HardSix(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, float expectedPays) {
            var hardSix = new HardSix();
            hardSix.PlaceBet(5);
            //Func<float, IBetResult> GetResult = (bet) => hardFour.Result(new Game() { }, new(die1, die2));
            //var result = GetResult(5);
            var result = hardSix.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}