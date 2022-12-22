using System.Drawing;

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
            }
        }

        public void Off() {
            _point = 0;
        }

        public short Point {
            get => _point;
            set {
                if ((new List<short>() { 0, 4, 5, 6, 8, 9, 10 }).Contains(value)) {
                    _point = value;
                    return;
                }
                throw new Exception("Invalid Point");
            }
        }
    }

}
