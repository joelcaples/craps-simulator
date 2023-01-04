﻿using craps_simulator.Lib.Interfaces;

namespace craps_simulator.Lib.Models {
    internal class BetResult : IBetResult {

        public bool IsWinner { get; set; } = false;
        public bool IsLoser { get; set; } = false;
        public decimal Pays { get; set; } = 0;
        public string Msg { get; set; } = string.Empty;
    }
}