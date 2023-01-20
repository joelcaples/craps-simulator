using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caps_simulator.wpf.dto {
    public class Message {
        public string TimeStamp { get; set; } = DateTime.Now.ToString();
        public string DiceRoll { get; set; } = string.Empty;
        public string MsgText { get; set; } = string.Empty;
    }
}
