﻿using craps_simulator.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.dto {
    public class BetNetDto {
        public IBet? Bet { get; set; }
        public int SessionNet { get; set;}
        public int TotalNet { get; set;}
    }
}