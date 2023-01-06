using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator {
    public enum PhaseType {
        On,
        Off
    }

    public enum BetType {
        HardFour,
        HardSix,
        HardEight,
        HardTen,
        Come,
        DoNotCome,
        DoNotPass,
        Field,
        Pass,
        PlaceFour,
        PlaceFive,
        PlaceSix,
        PlaceEight,
        PlaceNine,
        PlaceTen,
        TakeOdds,
        LayOdds
    }
}
