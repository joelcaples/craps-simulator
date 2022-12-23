using craps_simulator.Bets;
using craps_simulator.Models;

namespace craps_simulator.tests {
    public class BetTests {

        [Theory]
        [InlineData(PhaseType.Off, 0, 6, 1, true, false, 5)] // Craps!
        [InlineData(PhaseType.Off, 0, 2, 1, false, true, 0)] // Comeout loss on 3
        [InlineData(PhaseType.Off, 0, 6, 6, false, true, 0)] // Comeout loss on 12
        [InlineData(PhaseType.On, 4, 6, 1, false, true, 0)]  // Craps 7
        [InlineData(PhaseType.On, 4, 1, 1, false, false, 0)] // Point was not hit
        [InlineData(PhaseType.On, 4, 3, 1, true, false, 5)]  // Point was hit
        public void Pass(PhaseType phase, short point, short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var passLine = new Pass();
            passLine.PlaceBet(5);
            var result = passLine.Result(new Game() { Phase=phase, Point = point }, new Dice(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Theory]
        [InlineData(PhaseType.Off, 0, 6, 1, false, true, 0)] // Craps!
        [InlineData(PhaseType.Off, 0, 2, 1, true, false, 5)] // Comeout loss on 3
        [InlineData(PhaseType.Off, 0, 6, 6, true, false, 5)] // Comeout loss on 12
        [InlineData(PhaseType.On, 4, 6, 1, true, false, 5)]  // Craps 7
        [InlineData(PhaseType.On, 4, 1, 1, false, false, 0)] // Point was not hit
        [InlineData(PhaseType.On, 4, 3, 1, false, true, 0)]  // Point was hit
        public void DoNotPass(PhaseType phase, short point, short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var doNotPass = new DoNotPass();
            doNotPass.PlaceBet(5);
            var result = doNotPass.Result(new Game() { Phase = phase, Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Theory]
        [InlineData(1, 1, 10)] // Win on 2 or 12
        [InlineData(1, 2, 5)]  // Win on other than 2 or 12
        public void FieldBetWin(short die1, short die2, decimal expectedPays) {
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
        [InlineData(2, 2, true, false, 5*7)] // Hard 4
        [InlineData(1, 2, false, false, 0)]  // Not 4
        [InlineData(1, 3, false, true, 0)]   // Soft 4
        [InlineData(1, 6, false, true, 0)]   // Craps 7
        public void HardFour(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardFour = new HardFour();
            hardFour.PlaceBet(5);
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
        public void HardSix(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardSix = new HardSix();
            hardSix.PlaceBet(5);
            var result = hardSix.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Theory]
        [InlineData(4, 4, true, false, 5 * 9 / 1)]
        [InlineData(1, 2, false, false, 0)]
        [InlineData(3, 5, false, true, 0)]
        [InlineData(1, 6, false, true, 0)]
        public void HardEight(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardEight = new HardEight();
            hardEight.PlaceBet(5);
            var result = hardEight.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Theory]
        [InlineData(5, 5, true, false, 5 * 7)]
        [InlineData(1, 2, false, false, 0)]
        [InlineData(1, 9, false, true, 0)]
        [InlineData(1, 6, false, true, 0)]
        public void HardTen(short die1, short die2, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var hardTen = new HardTen();
            hardTen.PlaceBet(5);
            var result = hardTen.Result(new Game() { }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Theory]
        [InlineData(4, 4, 2, 2, 5, true, false, 9)] // Hit 4
        [InlineData(5, 5, 2, 3, 5, true, false, 7)] // Hit 5
        [InlineData(6, 6, 2, 4, 5, true, false, 5 * (7 / 6))] // Hit 6 Incorrect Bet (5)
        [InlineData(8, 8, 2, 6, 5, true, false, 5 * (7 / 6))] // Hit 8 Incorrect Bet (5)
        [InlineData(6, 6, 2, 4, 6, true, false, 7 * (7 / 6))] // Hit 6 w/Correct bet (6)
        [InlineData(8, 8, 2, 6, 6, true, false, 7 * (7 / 6))] // Hit 8 w/Correct bet (6)
        [InlineData(9, 9, 3, 6, 5, true, false, 7)] // Hit 9
        [InlineData(10, 10, 4, 6, 5, true, false, 9)] // Hit 10
        [InlineData(4, 4, 1, 6, 5, false, true, 0)] // Craps 7
        [InlineData(4, 4, 1, 1, 5, false, false, 0)] // Miss
        public void Place(short point, short spot, short die1, short die2, int bet, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var place = new Place(spot);
            place.PlaceBet(bet);
            var result = place.Result(new Game() { Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }

        [Theory]
        [InlineData(4, 2, 2, 10, true, false, 20)] // Hit 4
        [InlineData(5, 2, 3, 10, true, false, 15)] // Hit 5
        [InlineData(6, 2, 4, 10, true, false, 12)] // Hit 6 (6/5 Payout)
        [InlineData(8, 2, 6, 10, true, false, 12)] // Hit 8 (6/5 Payout)
        [InlineData(9, 3, 6, 10, true, false, 15)] // Hit 9
        [InlineData(10, 4, 6, 10, true, false, 20)] // Hit 10
        [InlineData(4, 1, 6, 10, false, true, 0)] // Craps 7
        [InlineData(4, 1, 1, 10, false, false, 0)] // Miss
        public void Take2xOdds(short point, short die1, short die2, int bet, bool expectedIsWinner, bool expectedIsLoser, decimal expectedPays) {
            var place = new TakeOdds();
            place.PlaceBet(bet);
            var result = place.Result(new Game() { Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}