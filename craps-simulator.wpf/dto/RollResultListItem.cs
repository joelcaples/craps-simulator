using craps_simulator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craps_simulator.wpf.dto {
    public class RollResultListItem {

        private readonly Game _game;
        private readonly Dice _dice;
        private readonly int _betTotal;
        private readonly decimal _net;

        public RollResultListItem(
            Game game,
            Dice dice, 
            string msgText,
            int betTotal,
            decimal net) {

            _game = game;
            _dice = dice;
            _betTotal = betTotal;
            _net = net;
            MsgText = msgText;
        }

        public string TimeStamp { get; } = DateTime.Now.ToString();
        public Dice Dice => _dice;
        public string DiceRoll => $"{_dice.Die1},{_dice.Die2}";
        public string MsgText { get; } = string.Empty;
        public int BetTotal => _betTotal;
        public decimal Net => _net;
        public string Die1ImageUri => _dice.Die1 switch {
            1 => "/images/dice-six-faces-one.png",
            2 => "/images/dice-six-faces-two.png",
            3 => "/images/dice-six-faces-three.png",
            4 => "/images/dice-six-faces-four.png",
            5 => "/images/dice-six-faces-five.png",
            6 => "/images/dice-six-faces-six.png",
            _ => throw new InvalidOperationException()
        };
        public string Die2ImageUri => _dice.Die2 switch {
            1 => "/images/dice-six-faces-one.png",
            2 => "/images/dice-six-faces-two.png",
            3 => "/images/dice-six-faces-three.png",
            4 => "/images/dice-six-faces-four.png",
            5 => "/images/dice-six-faces-five.png",
            6 => "/images/dice-six-faces-six.png",
            _ => throw new InvalidOperationException()
        };

        public string PuckImageUri => _game.Phase == PhaseType.On
            ? "/images/puck-on.jpeg"
            : "/images/puck-off.jpg";

    }
}
