using craps_simulator.Lib.Bets;
using craps_simulator.Lib.Interfaces;
using craps_simulator.Lib.Lib;
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
using craps_simulator.wpf.dto;
using System.Diagnostics;
using craps_simulator.Lib.Models;
using craps_simulator.lib.Services;
using craps_simulator.lib.Models;
using craps_simulator.wpf;

namespace craps_simulator.wpf {

    public class StrategyUiElement {
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set;}
    }

    //public class MainWindowViewModel {
    //    public MainWindowViewModel(Player activePlayer) {
    //        ActivePlayer = activePlayer;
    //    }
    //    public Player ActivePlayer { get; set; }
    //}

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly List<RollResultListItem> _rollResultListItems = new() { };
        private readonly List<StrategyUiElement> _strategies = new() { };
        private Player _player = new(5000);

        public MainWindow() {
            InitializeComponent();

            //DataContext = new MainWindowViewModel(_player);

            MsgList.ItemsSource = _rollResultListItems;

            _strategies = new List<StrategyUiElement>() {
                new StrategyUiElement() { Name = "Iron Cross", IsSelected=true },
                new StrategyUiElement() { Name = "Pass-Line With Odds" },
                new StrategyUiElement() { Name = "Hardways" },
            };
            cboStrategy.ItemsSource = _strategies;
            cboStrategy.Items.Refresh();
        }

        private void OnGo(object sender, RoutedEventArgs e) {
            var runner = new Runner();

            var list = new List<IBet>();
            foreach (var s in _strategies.Where(s => s.IsSelected)) {
                switch(s.Name) {
                    case "Iron Cross":
                        if(!list.Any(l => l.Type == BetType.Pass)) list.Add(new Pass());
                        if (!list.Any(l => l.Type == BetType.TakeOdds)) list.Add(new TakeOdds());
                        if (!list.Any(l => l.Type == BetType.PlaceFive)) list.Add(new Place(5));
                        if (!list.Any(l => l.Type == BetType.PlaceSix)) list.Add(new Place(6));
                        if (!list.Any(l => l.Type == BetType.PlaceEight)) list.Add(new Place(8));
                        if (!list.Any(l => l.Type == BetType.Field)) list.Add(new Field());
                        break;
                    case "Pass-Line With Odds":
                        if (!list.Any(l => l.Type == BetType.Pass)) list.Add(new Pass());
                        if (!list.Any(l => l.Type == BetType.TakeOdds)) list.Add(new TakeOdds());
                        break;
                    case "Hardways":
                        if (!list.Any(l => l.Type == BetType.HardFour)) list.Add(new HardFour());
                        if (!list.Any(l => l.Type == BetType.HardSix)) list.Add(new HardSix());
                        if (!list.Any(l => l.Type == BetType.HardEight)) list.Add(new HardEight());
                        if (!list.Any(l => l.Type == BetType.HardTen)) list.Add(new HardTen());
                        break;
                }
            }

            if ((btnHardFour.IsChecked ?? false)  && (!list.Any(l => l.Type == BetType.HardFour))) list.Add(new HardFour());
            if ((btnHardSix.IsChecked ?? false)   && (!list.Any(l => l.Type == BetType.HardSix))) list.Add(new HardSix());
            if ((btnHardEight.IsChecked ?? false) && (!list.Any(l => l.Type == BetType.HardEight))) list.Add(new HardEight());
            if ((btnHardTen.IsChecked ?? false)   && (!list.Any(l => l.Type == BetType.HardTen))) list.Add(new HardTen());

            runner.Go(_player, list, Runner_MsgEvt);
        }

        private void Runner_MsgEvt(object sender, RollResultEventArgs e) {

            var net = e.BetResults.Sum(r => r.Result.IsWinner ? r.Result.Pays : r.Result.IsLoser ? r.Bet.Bet * -1 : 0);

            _rollResultListItems.Insert(0, new RollResultListItem(
                e.Game,
                e.Dice,
                $"{string.Join("; ", e.BetResults.Where(r => !string.IsNullOrEmpty(r.Result.Msg)).Select(r => r.Result.Msg))}",
                e.BetResults.Sum(r => r.Bet.Bet),
                net
            ));
            MsgList.Items.Refresh();

            _player.BankRoll += (int)Math.Round(net, 0, MidpointRounding.ToZero);
            txtBankroll.Text = _player.BankRoll.ToString("C0");
        }

        private void OnClear(object sender, RoutedEventArgs e) {
            _rollResultListItems.Clear();
            MsgList.Items.Refresh();
        }
    }
}
