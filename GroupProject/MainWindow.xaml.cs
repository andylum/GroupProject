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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NOTE: A lot of this is just demo code. Including this function.

            //Creates the basic window object
            Window gameWindow = new Window();
            gameWindow.Height = 400;
            gameWindow.Width = 800;

            //create Grid to add information onto
            Grid mainGrid = new Grid();
            mainGrid.RenderSize = new Size(gameWindow.Width, gameWindow.Height);

            //TODO: Fill gameWindow with stuff needed in the game window, as indicated by the drawing. 
            //Info Site: https://www.c-sharpcorner.com/UploadFile/mahesh/using-xaml-image-in-wpf/
            //Logo
            Image gameLogo = new Image();
            gameLogo.Width = 230;
            gameLogo.Height = 107;
            BitmapImage newBtmpImg = new BitmapImage(new Uri("https://cdn.cloudflare.steamstatic.com/steam/apps/391540/header.jpg"));
            gameLogo.Source = newBtmpImg;
            gameLogo.HorizontalAlignment = HorizontalAlignment.Left;
            gameLogo.VerticalAlignment = VerticalAlignment.Top;
            gameLogo.Margin = new Thickness(0, 0, 0, 0);

            //Game Name
            TextBlock gameName = new TextBlock();
            gameName.Text = "Name: Undertale";
            gameName.HorizontalAlignment = HorizontalAlignment.Left;
            gameName.VerticalAlignment = VerticalAlignment.Top;
            gameName.Margin = new Thickness(0, gameLogo.Height, 0, 0);
            gameName.FontSize = 16;
            gameName.FontFamily = new FontFamily("Comic Sans MS");

            //Game Descritpion
            TextBlock gameDesc = new TextBlock();
            gameDesc.Text = "This is the description for popular Independent Video Game Undertale.";
            gameDesc.HorizontalAlignment = HorizontalAlignment.Left;
            gameDesc.VerticalAlignment = VerticalAlignment.Top;
            gameDesc.Margin = new Thickness(0, gameLogo.Height + 20, 0, 0);
            gameDesc.FontSize = 16;
            gameDesc.FontFamily = new FontFamily("Comic Sans MS");

            //Add things needed in the gameWindow to the Grid
            mainGrid.Children.Add(gameLogo);
            mainGrid.Children.Add(gameName);
            mainGrid.Children.Add(gameDesc);

            gameWindow.Content = mainGrid;
            
            gameWindow.Show();
        }
    }
}
