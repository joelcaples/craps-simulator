using craps_simulator.Bets;

namespace craps_simulator.tests {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            var field = new Field();
            field.PlaceBet(5);
            var result = field.Result(new Game() { }, new(1, 2));
            Assert.True(result.IsWinner);
        }
    }
}