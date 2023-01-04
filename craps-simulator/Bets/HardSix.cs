﻿using craps_simulator.Interfaces;

namespace craps_simulator.Bets
{
    public class HardSix : _Hardway, IBet {
        public string Name => "Hard Six";
        public BetType Type => BetType.HardSix;
        public HardSix() :base(6) { }
    }
}
