using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.Lib.Models {
    public class ThrowResult {

        private readonly Game _game;

        public ThrowResult(Game game) {
            _game = game;
        }

        public bool IsLoser { get; set; }
        public bool IsWinner { get; set; }
        public bool PointWasSet { get; set; }
        public string Msg { get; set; } = string.Empty;
        public Game Game => _game;
    }
}
