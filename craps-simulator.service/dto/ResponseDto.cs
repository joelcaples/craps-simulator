using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Models;

namespace craps_simulator.service.dto {
    public class ResponseDto {
        public Game? Game { get; set; }
        public Dice? Dice { get; set; }
        public List<IBetResult> BetResults { get; set; } = new List<IBetResult>();
    }
}
