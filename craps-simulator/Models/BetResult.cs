using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.Models {
    internal class BetResult {
        public bool IsWinner { get; set; } = false;
        public bool IsLoser { get; set; } = false;
        public float Pays = 0;
    }
}
