using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace craps_simulator {

    public class ExpectedEdge {

        public ExpectedEdge(float trueOdds, float pays, double houseEdge, string slangTerm = "") { 
            TrueOdds = trueOdds;
            Pays = pays;
            //PaysTo = paysTo;
            HouseEdge = houseEdge;
            SlangTerm = slangTerm;
        }

        public float TrueOdds { get; set; }
        public float Pays { get; set; }
        //public int PaysTo { get; set; }
        public double HouseEdge { get; set; }
        public string SlangTerm { get; set;}
    }

    internal class lookups {
        public static ExpectedEdge AnySeven = new(5 / 1, 4 / 1, 16.7, "big red");
        public static ExpectedEdge Two = new(35 / 1, 30 / 1, 13.9, "snake eyes");
        public static ExpectedEdge Twelve = new(35 / 1, 30 / 1, 13.9, "boxcars");
        public static ExpectedEdge OneWayHop = new(35 / 1, 30 / 1, 13.9, "1 way");
        public static ExpectedEdge Whirl = new(10 / 5, 8 / 5, 13.3, "");
        public static ExpectedEdge Horn = new(20 / 4, 17 / 4, 12.5, "");
        public static ExpectedEdge TwoWayHop = new(17 / 1, 15 / 1, 11.1, "2 ways");
        public static ExpectedEdge Three = new(17 / 1, 15 / 1, 11.1, "ace-deuce");
        public static ExpectedEdge Eleven = new(17 / 1, 15 / 1, 11.1, "yo-leven");
        public static ExpectedEdge AnyCraps = new(8 / 1, 7 / 1, 11.1, "2, 3, or 12");
        public static ExpectedEdge HardFour = new(8 / 1, 7 / 1, 11.1, "");
        public static ExpectedEdge HardTen = new(8 / 1, 7 / 1, 11.1, "");
        public static ExpectedEdge HardSix = new(10 / 1, 9 / 1, 9.1, "");
        public static ExpectedEdge HardEight = new(10 / 1, 9 / 1, 9.1, "");
        public static ExpectedEdge BigSixBigEight = new(6 / 5, 1 / 1, 9.1, "");
    }
}
