using craps_simulator.Bets;

namespace craps_simulator.tests {
    public class UnitTest1 {
        [Theory]
        [InlineData(1, 1, 10)]
        [InlineData(1, 2, 5)]
        public void FieldBetWin(int die1, int die2, float expectedPays) {
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
    }
}