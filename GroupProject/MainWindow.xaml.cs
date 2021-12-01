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
        int buttHeight = 88;
        int buttWidth = 88;

        public MainWindow()
        {
            gList = new gameList(loadFile);

            loadButtons();

            InitializeComponent();
        }

        public void RandomGame(object sender, RoutedEventArgs e) //Call this on recommended button click
        {
            if(gList.getList().Count <= 0 || gList.getList() == null)
            {
                Window errorWin = new Window();
                TextBox error = new TextBox();
                errorWin.Height = 200;
                errorWin.Width = 200;
                error.Text = "No games are loaded in!";
                errorWin.Content = error;
                errorWin.Show();
                return;
            }
            Random recommender = new Random();
            new gameWindow(gList.getList().ElementAt(recommender.Next(gList.getList().Count)));
        }

        public void loadButtons()
        {
            Thickness beginButtons = new Thickness(56, 61, 0, 0);
            int buttHorizontal = buttWidth + 20;
            int buttVertical = buttHeight + 20;
            const int horizSlot = 5; //max number of slots to for buttons to sit horizontally
            int vertPos = 0;
            int horizPos = 0;
            foreach (game videogame in gList.getList())
            {
                //create a button
                Button gameButton = new Button();
                BitmapImage gameImage = new BitmapImage(videogame.getCoverArt());
                gameButton.Content = gameImage;
                gameButton.Click += (_, args) =>
                {
                    new gameWindow(videogame);
                };

                //place the button in this place on the grid
                gameButton.Margin = beginButtons;
                browseGameWin.Children.Add(gameButton);

                //set the next place for a button to go
                horizPos++;
                if(horizPos % horizSlot == 0)
                {
                    horizPos = 0;
                    vertPos++;
                }

                beginButtons = new Thickness(56 + (buttHorizontal * horizPos), 61 + (buttVertical * vertPos), 0, 0);
            }

        }

        public void update()
        {
            gList.loadList(loadFile);
        }

        private void removeGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
