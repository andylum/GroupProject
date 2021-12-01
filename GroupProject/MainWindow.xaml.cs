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
using Microsoft.Win32;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string loadFile = "./list.txt"; //this is just hard coded but might actually work
        gameList gList;

        public MainWindow()
        {
            gList = new gameList(loadFile);

           

            InitializeComponent();

            loadButtons();
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

        public void RecentlyPlayedGame(object sender, RoutedEventArgs e)
        {
            if (gList.getList().Count <= 0 || gList.getList() == null)
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
            game recePlayedGame = gList.getList()[0];
            foreach(game videogame in gList.getList())
            {
                if(recePlayedGame.getLastPlayed() < videogame.getLastPlayed())
                {
                    recePlayedGame = videogame;
                }
                new gameWindow(recePlayedGame);
            }
        }
        public void UnplayedGame(object sender, RoutedEventArgs e)
        {
            List<game> unplayedGames = new List<game>();
            foreach(game videogame in gList.getList())
            {
                if(videogame.getLastPlayed() == new DateTime(0))
                {
                    unplayedGames.Add(videogame);
                }
            }

            if (unplayedGames.Count <= 0 || unplayedGames == null)
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
            new gameWindow(unplayedGames.ElementAt(recommender.Next(unplayedGames.Count)));
        }

        public void loadButtons()
        {
            Thickness beginButtons = new Thickness(0, 0, 0, 0);
            int buttHeight = 80;
            int buttWidth = 80;
            int buttHorizontal = buttWidth + 20;
            int buttVertical = buttHeight + 20;
            const int horizSlot = 5; //max number of slots to for buttons to sit horizontally
            int vertPos = 0;
            int horizPos = 0;
            foreach (game videogame in gList.getList())
            {
                //create a button
                Button gameButton = new Button();
                gameButton.Content = videogame.getTitle();
                gameButton.Height = buttHeight;
                gameButton.Width = buttWidth;
                gameButton.HorizontalAlignment = HorizontalAlignment.Left;
                gameButton.VerticalAlignment = VerticalAlignment.Top;
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

                beginButtons = new Thickness((buttHorizontal * horizPos), (buttVertical * vertPos), 0, 0);
            }

        }


        public void update()
        {
            gList.loadList(loadFile);
            browseGameWin.Children.Clear(); //clears all the buttons on screen before readding them
            loadButtons();
        }

        private void removeGame_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            //open a window with a drop down box containing all games
            //user clicks the box and says ok to remove the game
            //the game is removed from library by overwriting the database and updating the main window
        }

        private void addGame_Click(object sender, RoutedEventArgs e)
        {
            //grab file from folder
            game videogame;
            gameFactory fact = new gameFactory();
            OpenFileDialog selectGame = new OpenFileDialog();
            selectGame.InitialDirectory = "c:\\";
            selectGame.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
            selectGame.FilterIndex = 0;
            selectGame.RestoreDirectory = true;

            if ((bool)selectGame.ShowDialog())
            {
                videogame = fact.createGame(selectGame.FileName);
            }
            else
            {
                return;
            }
            

            //append to file
            System.IO.StreamWriter file = new System.IO.StreamWriter(loadFile, append: true);
            file.WriteLine(videogame.getTitle());
            file.WriteLine(videogame.getFilePath());
            file.WriteLine(videogame.getCoverArt().OriginalString);
            file.WriteLine(videogame.getLastPlayed().Ticks.ToString());
            file.WriteLine(videogame.getFileSize().ToString());
            file.Close();

            //reload games
            update();
        }
    }
}
