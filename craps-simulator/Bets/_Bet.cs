﻿using craps_simulator.Interfaces;
using craps_simulator.Models;

namespace craps_simulator.Bets {
    public class _Bet {

        protected float _bet = 0;
        protected float _sessionResult = 0;

        public virtual float Bet {
            get {
                return _bet;
            }
        }

        public void PlaceBet(float bet) {
            _bet += bet;
        }

        public float SessionResult {
            get {
                return _sessionResult;
            }
        }

        protected IBetResult Result(bool isWinner, bool isLoser, ExpectedEdge edge) {
            if (isWinner) {
                _sessionResult += _bet;
                return new BetResult() { IsWinner = true, Bet = _bet, Pays = _bet * edge.Pays };
            }

            if (isLoser) {
                _sessionResult -= _bet;
                _bet = 0;
                return new BetResult() { IsLoser = true, Bet = _bet, Pays = 0 };
            }

            return new BetResult() { Pays = 0 };
        }
    }
}
