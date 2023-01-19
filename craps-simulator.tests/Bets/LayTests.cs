using craps_simulator.Lib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests.Bets
{
    public class LayTests {
        [Fact]
        public void GetNameTest() {
            Assert.Equal("Lay 4", new Lay(4).Name);
            Assert.Equal("Lay 5", new Lay(5).Name);
            Assert.Equal("Lay 6", new Lay(6).Name);
            Assert.Equal("Lay 8", new Lay(8).Name);
            Assert.Equal("Lay 9", new Lay(9).Name);
            Assert.Equal("Lay 10", new Lay(10).Name);
        }

        [Fact]
        public void GetTypeTest() {
            Assert.Equal(BetType.LayFour, new Lay(4).Type);
            Assert.Equal(BetType.LayFive, new Lay(5).Type);
            Assert.Equal(BetType.LaySix, new Lay(6).Type);
            Assert.Equal(BetType.LayEight, new Lay(8).Type);
            Assert.Equal(BetType.LayNine, new Lay(9).Type);
            Assert.Equal(BetType.LayTen, new Lay(10).Type);
            
            var e = Record.Exception(() => {
                var _ = new Lay(99).Type;
            });
            Assert.NotNull(e);

            var e2 = Record.Exception(() => {
                var _ = new Lay(99);
            });
            Assert.NotNull(e2);
        }

        [Theory]
        [InlineData(5, 4, 2, 2, 20, false, true, 0)]   // 4
        [InlineData(4, 10, 4, 6, 20, false, true, 0)]  // 10
        [InlineData(4, 5, 2, 3, 20, false, true, 0)]   // 5
        [InlineData(4, 9, 3, 6, 20, false, true, 0)]   // 9
        [InlineData(4, 6, 2, 4, 20, false, true, 0)]   // 6
        [InlineData(4, 8, 2, 6, 20, false, true, 0)]   // 8
        [InlineData(5, 4, 1, 6, 20, true, false, 9)]   //
        [InlineData(5, 4, 1, 1, 20, false, false, 0)]  //
        public void ResultTest(short point, short spot, short die1, short die2, int bet, bool expectedIsWinner, bool expectedIsLoser, int expectedPays) {
            var lay = new Lay(spot);
            lay.PlaceBet(bet);
            var result = lay.Result(new Game() { Point = point }, new(die1, die2));

            Assert.Equal(expectedIsWinner, result.IsWinner);
            Assert.Equal(expectedIsLoser, result.IsLoser);
            Assert.Equal(expectedPays, result.Pays);
        }
    }
}
