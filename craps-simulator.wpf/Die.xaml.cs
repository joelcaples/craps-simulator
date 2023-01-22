using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace craps_simulator.wpf {
    /// <summary>
    /// Interaction logic for Die.xaml
    /// </summary>
    public partial class Die : UserControl {
        public Die() {
            InitializeComponent();
            this.DataContext = this;
        }

        public short Value { get; set; }
        public string ForeColor { get; set; } = "green";
        public string BgColor { get; set; } = "yellow";

        public bool IsOne => Value == 1;
        public bool IsTwo => Value == 2;
        public bool IsThree => Value == 3;
        public bool IsFour => Value == 4;
        public bool IsFive => Value == 5;
        public bool IsSix => Value == 6;
    }
}
