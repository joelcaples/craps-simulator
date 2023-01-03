using craps_simulator.Bets;
using craps_simulator.Interfaces;

namespace craps_simulator.service.dto {
    public class RequestDto {
        public Game? Game { get; set; }
        public List<BetDto>? Bets { get; set; }
    }
}
