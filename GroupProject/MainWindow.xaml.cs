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
            //This pops up a window.
            Window gameWindow = new Window();
            gameWindow.Height = 400;
            gameWindow.Width = 800;

            //create Grid to place stuff on
            Grid mainGrid = new Grid();

            //TODO: Fill gameWindow with stuff needed in the game window, as indicated by the drawing. 
            //Info Site: https://www.c-sharpcorner.com/UploadFile/mahesh/using-xaml-image-in-wpf/
            Image dynamicImage = new Image();
            dynamicImage.Width = 100;
            dynamicImage.Height = 100;
            BitmapImage newBtmpImg = new BitmapImage(new Uri("https://fontmeme.com/images/undertale-font.jpg"));
            dynamicImage.Source = newBtmpImg;

            mainGrid.Children.Add(dynamicImage);
            gameWindow.Content = mainGrid;
            
            gameWindow.Show();
        }
    }
}
