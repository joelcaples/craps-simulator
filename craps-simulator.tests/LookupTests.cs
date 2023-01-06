using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests {
    public class LookupTests {

        [Fact]
        public void LookupsTest() {
            var One = Lookups.I;
            Assert.Equal(1, One);
            var Two = Lookups.II;
            Assert.Equal(2, Two);
            var Three = Lookups.III;
            Assert.Equal(3, Three);
            var Four = Lookups.IV;
            Assert.Equal(4, Four);
            var Five = Lookups.V;
            Assert.Equal(5, Five);
            var Six = Lookups.VI;
            Assert.Equal(6, Six);
            var Seven = Lookups.VII;
            Assert.Equal(7, Seven);
            var Eight = Lookups.VIII;
            Assert.Equal(8, Eight);
            var Nine = Lookups.IX;
            Assert.Equal(9, Nine);
            var Ten = Lookups.X;
            Assert.Equal(10, Ten);
            var Eleven = Lookups.XI;
            Assert.Equal(11, Eleven);
            var Fifteen = Lookups.XV;
            Assert.Equal(15, Fifteen);
            var Seventeen = Lookups.XVII;
            Assert.Equal(17, Seventeen);
            var Nineteen = Lookups.XIX;
            Assert.Equal(19, Nineteen);
            var Twenty = Lookups.XX;
            Assert.Equal(20, Twenty);
            var TwentyOne = Lookups.XXI;
            Assert.Equal(21, TwentyOne);
            var TwentyThree = Lookups.XXIII;
            Assert.Equal(23, TwentyThree);
            var TwentyFive = Lookups.XXV;
            Assert.Equal(25, TwentyFive);
            var TwentyNine = Lookups.XXIX;
            Assert.Equal(29, TwentyNine);
            var Thirty = Lookups.XXX;
            Assert.Equal(30, Thirty);
            var ThirtyOne = Lookups.XXXI;
            Assert.Equal(31, ThirtyOne);
            var ThirtyFour = Lookups.XXXIV;
            Assert.Equal(34, ThirtyFour);
            var ThirtyFive = Lookups.XXXV;
            Assert.Equal(35, ThirtyFive);
            var ThirtyNine= Lookups.XXXIX;
            Assert.Equal(39, ThirtyNine);
            var FourtyOne = Lookups.XXXXI;
            Assert.Equal(41, FourtyOne);
        }

        [Fact]
        public void ExpectedEdgeSlangTest() {
            Assert.Empty(Lookups.Pass.SlangTerm);
        }
    }
}
