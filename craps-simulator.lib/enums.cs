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
        DoNotPlaceFour,
        DoNotPlaceFive,
        DoNotPlaceSix,
        DoNotPlaceEight,
        DoNotPlaceNine,
        DoNotPlaceTen,
        TakeOdds,
        LayOdds,
        BigSix,
        BigEight,
        BuyFour,
        BuyFive,
        BuySix,
        BuyEight,
        BuyNine,
        BuyTen,
        LayFour,
        LayFive,
        LaySix,
        LayEight,
        LayNine,
        LayTen,
        AnySeven,
        AnyCraps,
        OneWayHop,
        TwoWayHop,
    }

    public enum HardWayRollResult {
        Four = 4,
        Six = 6,
        Eight = 8,
        Ten = 10,
    }

    public enum RollResult {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Eleven = 11,
        Twelve = 12
    }
}
