using craps_simulator.Models;
using System.Drawing;
using System.Security.Cryptography;

namespace craps_simulator {
    public class Game {

        private short _point = 0;

        public Game() {
            _point = 0;
        }

        public PhaseType Phase {
            get {
                return (new List<short>() { 4, 5, 6, 8, 9, 10 }).Contains(_point) ? PhaseType.On : PhaseType.Off;
            }
            set {
                if (value == PhaseType.Off)
                    _point = 0;
                //else
                //    throw new InvalidOperationException();
            }
        }

        public void Off() => _point = 0;

        public short Point {
            get => _point;
            set {
                if ((new List<short>() { 0, 4, 5, 6, 8, 9, 10 }).Contains(value))
                    _point = value;
                else
                    throw new Exception("Invalid Point");
            }
        }

        public Dice Roll() {
            var upperBound = 6;
            var die1 = RandomNumberGenerator.GetInt32(upperBound) + 1;
            var die2 = RandomNumberGenerator.GetInt32(upperBound) + 1;

            return new Dice((short)die1, (short)die2);
        }
    }

}
