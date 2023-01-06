﻿using craps_simulator.dto;
using craps_simulator.Lib.Bets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.tests {
    public class RunnerTests {
        [Fact]
        public void BetNetTest() {
            
            var bn = new BetNetDto() {
                Bet = new Pass() { },
                SessionNet = 6,
                TotalNet = 7
            };

            Assert.NotNull(bn.Bet);
            Assert.Equal(6, bn.SessionNet);
            Assert.Equal(7, bn.TotalNet);
        }
    }
}
