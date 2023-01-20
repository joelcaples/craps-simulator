using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Lib;
using craps_simulator;
using System;
using System.Collections.Generic;
using System.IO;
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
using craps_simulator.dto;
using caps_simulator.wpf.dto;
using System.Diagnostics;
using craps_simulator.Lib.Models;

namespace caps_simulator.wpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public List<Message> Messages = new() {
            //new Message() { MsgText = "One" },
            //new Message() { MsgText = "Two" },
            //new Message() { MsgText = "Three" },
        };

        public MainWindow() {
            InitializeComponent();
            //var messages = new List<Message>() {
            //    new Message() { MsgText = "One" },
            //    new Message() { MsgText = "Two" },
            //    new Message() { MsgText = "Three" },
            //};
            MsgList.ItemsSource = Messages;
        }

        private void OnGo(object sender, RoutedEventArgs e) {
            var runner = new Runner();
            runner.MsgEvt += Runner_MsgEvt;
            runner.Go();
        }

        private void Runner_MsgEvt(object sender, RollResultEventArgs e) {
            
            Messages.Insert(0, new Message() {
                DiceRoll = $"{e.Dice.Die1},{e.Dice.Die2}",
                MsgText = $"{string.Join("; ", e.BetResults.Select(r => r.Msg))}" 
            });
            
            MsgList.Items.Refresh();
        }

        private void OnClear(object sender, RoutedEventArgs e) {
            Messages.Clear();
            MsgList.Items.Refresh();
        }

        //private void Runner_MsgEvt(object sender, MsgEventArgs e) {
        //    Messages.Add(new Message() { MsgText = e.Msg });
        //    MsgList.Items.Refresh();
        //}
    }
}
