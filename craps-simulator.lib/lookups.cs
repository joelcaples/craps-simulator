using System.Linq.Expressions;

namespace craps_simulator {

    public class ExpectedEdge {

        public ExpectedEdge(
            decimal? trueOdds, 
            decimal pays, 
            double? houseEdge = null, 
            string slangTerm = "") { 
            
            //TrueOdds = trueOdds;
            Pays = pays;
            //HouseEdge = houseEdge;
            SlangTerm = slangTerm;
        }

        //public float TrueOdds { get; set; }
        public decimal Pays { get; set; }
        //public double HouseEdge { get; set; }
        public string SlangTerm { get; set;}
    }

    public class Lookups {
        public const decimal I = (decimal)1.0;
        public const decimal II = (decimal)2.0;
        public const decimal III = (decimal)3.0;
        public const decimal IV = (decimal)4.0;
        public const decimal V = (decimal)5.0;
        public const decimal VI = (decimal)6.0;
        public const decimal VII = (decimal)7.0;
        public const decimal VIII = (decimal)8.0;
        public const decimal IX = (decimal)9.0;
        public const decimal X = (decimal)10.0;
        public const decimal XI = (decimal)11.0;
        public const decimal XV = (decimal)15.0;
        public const decimal XVII = (decimal)17.0;
        public const decimal XIX = (decimal)19.0;
        public const decimal XX = (decimal)20.0;
        public const decimal XXI = (decimal)(21.0);
        public const decimal XXIII = (decimal)(23.0);
        public const decimal XXV = (decimal)(25.0);
        public const decimal XXIX = (decimal)(29.0);
        public const decimal XXX = (decimal)30.0;
        public const decimal XXXI = (decimal)(31.0);
        public const decimal XXXIV = (decimal)(34.0);
        public const decimal XXXV = (decimal)(35.0);
        public const decimal XXXIX = (decimal)(39.0);
        public const decimal XXXXI = (decimal)(41.0);

        public static ExpectedEdge Pass => new(null, I);
        public static ExpectedEdge DoNotPass => new(null,I);
        public static ExpectedEdge Come => new(null, I);
        public static ExpectedEdge DoNotCome => new(null, I);
        public static ExpectedEdge TakeOddsSixAndEight => new(null, VI/V);
        public static ExpectedEdge TakeOddsFiveAndNine => new(null, III/II);
        public static ExpectedEdge TakeOddsFourAndTen => new(null, II/I);
        public static ExpectedEdge LayOddsSixAndEight => new(null, V / VI);
        public static ExpectedEdge LayOddsFiveAndNine => new(null, II / III);
        public static ExpectedEdge LayOddsFourAndTen => new(null, I / II);
        //public static ExpectedEdge DoNotPlaceSixAndEight => new(null, IV/V);
        //public static ExpectedEdge DoNotPlace5And9 => new(null, V/VIII);
        //public static ExpectedEdge DoNotPlaceFourAndTen => new(null, V/XI);
        //public static ExpectedEdge BuySixAndEight => new(null, XXIII/ XXI); //Commission always paid
        //public static ExpectedEdge BuyFiveAndNine => new(null, XXIX/ XXI); //Commission always paid
        //public static ExpectedEdge BuyFourAndTen => new(null, XXXIX/ XXI); //Commission always paid
        //public static ExpectedEdge BuySixAndEight => new(null, 23/20); //Commission on Win Only
        //public static ExpectedEdge BuyFiveAndNine => new(null, 29/20); //Commission on Win Only
        //public static ExpectedEdge BuyFourAndTen => new(null, 39/20); //Commission on Win Only
        //public static ExpectedEdge LaySixAndEight => new(null, XIX/XXV); //Commission always paid
        //public static ExpectedEdge LayFiveAndNine => new(null, XIX / XXXI); //Commission always paid
        //public static ExpectedEdge LayFourAndTen => new(null, XIX / XXXXI); //Commission always paid
        //public static ExpectedEdge LaySixAndEight => new(null, 19/24); //Commission on Win Only
        //public static ExpectedEdge LayFiveAndNine => new(null, 19/30); //Commission on Win Only
        //public static ExpectedEdge LayFourAndTen => new(null, 19/40); //Commission on Win Only
        //public static ExpectedEdge HardSixAndEightAU => new(null, 19/2);
        //public static ExpectedEdge HardFourAndTenAU => new(null, 15/2);

        //public static ExpectedEdge AnySeven => new(V/I, IV/I, 16.7, "big red");
        //public static ExpectedEdge Two => new(XXXV/I, XXX/I, 13.9, "snake eyes");
        //public static ExpectedEdge Twelve => new(XXXV/I, XXX/I, 13.9, "boxcars");
        //public static ExpectedEdge OneWayHop => new(XXXV/I, XXX/I, 13.9, "1 way");
        //public static ExpectedEdge Whirl => new(X/V, VIII/V, 13.3, "");
        //public static ExpectedEdge Horn => new(XX/IV, XVII/IV, 12.5, "");
        //public static ExpectedEdge TwoWayHop => new(XVII/I, XV/I, 11.1, "2 ways");
        //public static ExpectedEdge Three => new(XVII / I, XV/I, 11.1, "ace-deuce");
        //public static ExpectedEdge Eleven => new(XVII / I, XV/I, 11.1, "yo-leven");
        //public static ExpectedEdge AnyCraps => new(VIII/I, VII/I, 11.1, "2, 3, or 12");
        public static ExpectedEdge HardFourOrTen => new(VIII/I, VII/I, 11.1, "");
        public static ExpectedEdge HardSixOrEight => new(X/I, IX/I, 9.1, "");
        //public static ExpectedEdge BigSixBigEight => new(VI/V, I/I, 9.1, "");
        public static ExpectedEdge PlaceFourOrTen => new(II/I, IX / V, 6.7, "");
        public static ExpectedEdge PlaceFiveOrNine => new(III/II, VII/V, 4, "");
        public static ExpectedEdge PlaceSixOrEight => new(VI/V, VII/VI, 1.52, "");

        public static ExpectedEdge Field => new (null, I/I);
        public static ExpectedEdge FieldTwoOrTwelve => new (null, II/I);
    }
}
