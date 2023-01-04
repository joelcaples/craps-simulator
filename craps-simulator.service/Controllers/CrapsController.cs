using craps_simulator.Bets;
using craps_simulator.Interfaces;
using craps_simulator.Lib;
using craps_simulator.service.dto;
using Microsoft.AspNetCore.Mvc;

namespace craps_simulator.service.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CrapsController : ControllerBase {

        private readonly ILogger<CrapsController> _logger;

        public CrapsController(ILogger<CrapsController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public ResponseDto Throw([FromBody] RequestDto request) {

            if (request.Game == null)
                throw new InvalidDataException();

            var response = new ResponseDto {
                Dice = GameLib.Roll()
            };

            if (request.Bets != null)
                foreach (BetDto bet in request.Bets) {
                    IBet actualBet = bet.Type switch {
                        BetType.Come => new Come(),
                        BetType.DoNotPass => new DoNotPass(),
                        BetType.Field => new Field(),
                        BetType.HardEight => new HardEight(),
                        BetType.HardFour => new HardFour(),
                        BetType.HardSix => new HardSix(),
                        BetType.HardTen => new HardTen(),
                        BetType.Pass => new Pass(),
                        BetType.PlaceFour => new Place(4),
                        BetType.PlaceFive => new Place(5),
                        BetType.PlaceSix => new Place(6),
                        BetType.PlaceEight => new Place(8),
                        BetType.PlaceNine => new Place(9),
                        BetType.PlaceTen => new Place(10),
                        BetType.TakeOdds => new TakeOdds(),
                        _ => throw new InvalidDataException()
                    };
                    actualBet.PlaceBet(bet.Amount);
                    response.BetResults.Add(actualBet.Result(request.Game, response.Dice));
                }

            response.Game = GameLib.Advance(request.Game, response.Dice).Game;

            return response;
        }
    }
}