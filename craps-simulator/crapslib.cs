using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator {
    internal class crapslib {
        internal static (int die1, int die2) roll() {
            var upperBound = 6;
            var die1 = RandomNumberGenerator.GetInt32(upperBound)+1;
            var die2 = RandomNumberGenerator.GetInt32(upperBound)+1;

            return (die1, die2);
        }
    }
}
