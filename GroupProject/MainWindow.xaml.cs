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
        string loadFile = "./list.txt"; //this is just hard coded but might actually work
        gameList gList;
        Grid browseGamesWin;
        Grid extrasPanel;
        int buttHeight = 88;
        int buttWidth = 88;

        public MainWindow()
        {
            Grid winContent = new Grid();
            browseGamesWin = new Grid();

            browseGamesWin.Height = this.Height;
            browseGamesWin.Width = this.Width - 100;

            browseGamesWin.HorizontalAlignment = HorizontalAlignment.Left;
            browseGamesWin.VerticalAlignment = VerticalAlignment.Top;

            gList = new gameList(loadFile);

            loadButtons();

            winContent.Children.Add(browseGamesWin);

            this.Content = winContent;


            InitializeComponent();
        }


        public void RecommendedGame() //Call this on recommended button click
        {
            Random recommender = new Random();
            new gameWindow(gList.getList().ElementAt(recommender.Next(gList.getList().Count)));
        }

        public void loadButtons()
        {
            Thickness beginButtons = new Thickness(56, 61, 0, 0);
            int buttHorizontal = buttWidth + 20;
            int buttVertical = buttHeight + 20;
            const int horizSlot = 5;
            int vertPos = 0;
            int horizPos = 0;
            foreach (game videogame in gList.getList())
            {
                
                Button gameButton = new Button();
                BitmapImage gameImage = new BitmapImage(videogame.getCoverArt());
                gameButton.Content = gameImage;
                gameButton.Click += (_, args) =>
                {
                    new gameWindow(videogame);
                };

                gameButton.Margin = beginButtons;

                horizPos++;
                if(horizPos % horizSlot == 0)
                {
                    horizPos = 0;
                    vertPos++;
                }

                beginButtons = new Thickness(56 + (buttHorizontal * horizPos), 61 + (buttVertical * vertPos), 0, 0);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
