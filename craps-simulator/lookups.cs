namespace craps_simulator {

    public class ExpectedEdge {

        public ExpectedEdge(
            float? trueOdds, 
            float pays, 
            double? houseEdge = null, 
            string slangTerm = "") { 
            
            //TrueOdds = trueOdds;
            Pays = pays;
            //HouseEdge = houseEdge;
            SlangTerm = slangTerm;
        }

        //public float TrueOdds { get; set; }
        public float Pays { get; set; }
        //public double HouseEdge { get; set; }
        public string SlangTerm { get; set;}
    }

    internal class lookups {

        public static ExpectedEdge Pass = new(null, 1 /1);
        public static ExpectedEdge DoNotPass = new(null,1/1);
        public static ExpectedEdge TakeOddsSixAndEight = new(null, 6/5);
        public static ExpectedEdge TakeOddsFiveAndNine = new(null, 3/2);
        public static ExpectedEdge TakeOddsFourAndTen = new(null, 2/1);
        public static ExpectedEdge LayOddsSixAndEight = new(null, 5/6);
        public static ExpectedEdge LayOddsFiveAndNine = new(null, 2/3);
        public static ExpectedEdge LayOddsFourAndTen = new(null, 1/2);
        public static ExpectedEdge DoNotPlaceSixAndEight = new(null, 4/5);
        public static ExpectedEdge DoNotPlace5And9 = new(null, 5/8);
        public static ExpectedEdge DoNotPlaceFourAndTen = new(null, 5/11);
        public static ExpectedEdge BuySixAndEight = new(null, 23/21); //Commission always paid
        public static ExpectedEdge BuyFiveAndNine = new(null, 29/21); //Commission always paid
        public static ExpectedEdge BuyFourAndTen = new(null, 39/21); //Commission always paid
        //public static ExpectedEdge BuySixAndEight = new(null, 23/20); //Commission on Win Only
        //public static ExpectedEdge BuyFiveAndNine = new(null, 29/20); //Commission on Win Only
        //public static ExpectedEdge BuyFourAndTen = new(null, 39/20); //Commission on Win Only
        public static ExpectedEdge LaySixAndEight = new(null, 19/25); //Commission always paid
        public static ExpectedEdge LayFiveAndNine = new(null, 19/31); //Commission always paid
        public static ExpectedEdge LayFourAndTen = new(null, 19/41); //Commission always paid
        //public static ExpectedEdge LaySixAndEight = new(null, 19/24); //Commission on Win Only
        //public static ExpectedEdge LayFiveAndNine = new(null, 19/30); //Commission on Win Only
        //public static ExpectedEdge LayFourAndTen = new(null, 19/40); //Commission on Win Only
        //public static ExpectedEdge HardSixAndEightAU = new(null, 19/2);
        //public static ExpectedEdge HardFourAndTenAU = new(null, 15/2);



        public static ExpectedEdge AnySeven = new(5/1, 4/1, 16.7, "big red");
        public static ExpectedEdge Two = new(35/1, 30/1, 13.9, "snake eyes");
        public static ExpectedEdge Twelve = new(35/1, 30/1, 13.9, "boxcars");
        public static ExpectedEdge OneWayHop = new(35/1, 30/1, 13.9, "1 way");
        public static ExpectedEdge Whirl = new(10/5, 8/5, 13.3, "");
        public static ExpectedEdge Horn = new(20/4, 17/4, 12.5, "");
        public static ExpectedEdge TwoWayHop = new(17/1, 15/1, 11.1, "2 ways");
        public static ExpectedEdge Three = new(17/1, 15/1, 11.1, "ace-deuce");
        public static ExpectedEdge Eleven = new(17/1, 15/1, 11.1, "yo-leven");
        public static ExpectedEdge AnyCraps = new(8/1, 7/1, 11.1, "2, 3, or 12");
        public static ExpectedEdge HardFourOrTen = new(8/1, 7/1, 11.1, "");
        public static ExpectedEdge HardSixOrEight = new(10/1, 9/1, 9.1, "");
        public static ExpectedEdge BigSixBigEight = new(6/5, 1/1, 9.1, "");
        public static ExpectedEdge PlaceFourOrTen = new(2/1, 9/5, 6.7, "");
        public static ExpectedEdge PlaceFiveOrNine = new(3/2, 7/5, 4, "");
        public static ExpectedEdge PlaceSixOrEight = new(6/5, 7/6, 1.52, "");
    }
}
