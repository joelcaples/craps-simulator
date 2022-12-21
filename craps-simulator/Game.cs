namespace craps_simulator {
    internal class Game {

        private PhaseType _phase = PhaseType.Off;

        public PhaseType Phase {
            get {
                return _phase;
            }
            set {
                _phase = value;
            }
        }

        public int Point { get; set; }
    }

    public enum PhaseType {
        On,
        Off
    }
}
