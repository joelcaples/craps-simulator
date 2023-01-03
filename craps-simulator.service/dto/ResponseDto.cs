using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.service.dto {
    public class ResponseDto {
        public Game? Game { get; set; }
        public Dice? Dice { get; set; }
        public List<IBetResult> BetResults { get; set; } = new List<IBetResult>();
    }
}
