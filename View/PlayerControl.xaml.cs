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

namespace LCRGame.View
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static readonly DependencyProperty PlayersProperty = DependencyProperty.Register("NumberOfPlayers", typeof(string), typeof(PlayerControl));
        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register("FillColor", typeof(bool), typeof(PlayerControl));

        public string NumberOfPlayers
        {
            get { return (string)GetValue(PlayersProperty); }
            set { SetValue(PlayersProperty, value); }
        }

        public bool FillColor
        {
            get { return (bool)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }
    }
}
