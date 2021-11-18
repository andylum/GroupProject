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

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string loadFile = "./list.txt";
        gameList gList;
        Grid browseGamesWin;
        Grid extrasPanel;
        public MainWindow()
        {
            extrasPanel.Height = this.Height;
            extrasPanel.Width = 100;
            browseGamesWin.Height = this.Height;
            browseGamesWin.Width = this.Width - extrasPanel.Width;

            gList = new gameList(loadFile);

            InitializeComponent();
        }

        public void RecommendedGame()
        {
            Random recommender = new Random();
            //grab a random game from the loaded library
        }

    }
}
