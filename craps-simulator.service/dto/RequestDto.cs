namespace craps_simulator.service.dto {
    public class RequestDto {
        public Game? Game { get; set; }
        public List<BetDto>? Bets { get; set; }
    }
}
