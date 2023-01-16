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
}
