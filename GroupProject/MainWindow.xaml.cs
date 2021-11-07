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

        private void RemoveGameButton_Click(object sender, RoutedEventArgs e)
        {
            //Just exists to show that the removeButton does something. Can't actually remove games bc everything is Hard Coded
            Window removeButtonWindow = new Window();
            removeButtonWindow.Height = removeButtonWindow.Width = 200;
            Grid remGrid = new Grid();
            remGrid.RenderSize = new Size(removeButtonWindow.Width, removeButtonWindow.Height);

            TextBox tesxtBox = new TextBox();
            tesxtBox.Text = "Removing games is impossible rn. \nToo much hard coding.";


            Button okButton = new Button();
            okButton.Content = "OK";
            okButton.Height = 20;
            okButton.Width = 60;
            okButton.VerticalAlignment = VerticalAlignment.Bottom;
            //StackOverflow god teaching me about anonymous functions: https://stackoverflow.com/questions/13793490/close-dynamically-created-form-with-dynamic-button
            okButton.Click += (_, args) =>
            {
                removeButtonWindow.Close();
            };

            remGrid.Children.Add(tesxtBox);
            remGrid.Children.Add(okButton);

            removeButtonWindow.Content = remGrid;

            removeButtonWindow.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NOTE: A lot of this is just demo code that will be replaced w/ less/no hard-coding later.
            //gameWindow will become its own class, as a child of Window

            //Creates the basic window object
            Window gameWindow = new Window();
            gameWindow.Height = this.Height;
            gameWindow.Width = this.Width;

            //create Grid to add information onto
            Grid mainGrid = new Grid();
            mainGrid.RenderSize = new Size(gameWindow.Width, gameWindow.Height);

            //Taught me how to dynamically add images to a window
            //https://www.c-sharpcorner.com/UploadFile/mahesh/using-xaml-image-in-wpf/

            //Logo
            //Uses half the size of the header.jpg present on steamdb (460 x 215 by default)
            Image gameLogo = new Image();
            gameLogo.Width = 230;
            gameLogo.Height = 107;
            gameLogo.Source = new BitmapImage(new Uri("https://cdn.cloudflare.steamstatic.com/steam/apps/391540/header.jpg")); //can grab link from steamdb/igdb for this in full ver
            gameLogo.HorizontalAlignment = HorizontalAlignment.Left;
            gameLogo.VerticalAlignment = VerticalAlignment.Top;
            //marginBuffer moves the position of the objects based on the previous object's position
            Thickness marginBuffer = new Thickness(10, 10, 0, 0);
            gameLogo.Margin = marginBuffer;
            marginBuffer.Top += gameLogo.Height;

            //Game Name
            TextBlock gameName = new TextBlock();
            gameName.Text = "Name: Undertale";
            gameName.HorizontalAlignment = HorizontalAlignment.Left;
            gameName.VerticalAlignment = VerticalAlignment.Top;
            gameName.Margin = marginBuffer;
            gameName.FontSize = 16;
            gameName.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Top += 30;

            //Game Descritpion
            TextBlock gameDesc = new TextBlock();
            gameDesc.Text = "This is the description for popular Independent Video Game Undertale. Does this automatically wrap or will I need to do something to acknowledge when the line goes outside of the border and then split it, or maybe manually have a text box size and let it wrap that way? Idk, we'll see.";
            //TODO: Actually make the text wrap instead of just running off the side of the screen
            //Below text doesn't work. Just a general idea that came to mind.
            /*int stringPos = 0;
            int sinceLastNewline = 0;
            while (stringPos < gameDesc.Text.Length)
            {
                stringPos++;
                sinceLastNewline++;
                if(sinceLastNewline > 50)
                {
                    if(gameDesc.Text[stringPos] == ' ')
                    {
                        gameDesc.Text.Insert(stringPos, "\n");
                        sinceLastNewline = 0;
                    }
                }
            }
            */
            gameDesc.HorizontalAlignment = HorizontalAlignment.Left;
            gameDesc.VerticalAlignment = VerticalAlignment.Top;
            gameDesc.Margin = marginBuffer;
            gameDesc.Width = this.Width;
            gameDesc.FontSize = 16;
            gameDesc.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Top += 100;
            

            //Last Played Time
            TextBlock gameLastPlayed = new TextBlock();
            gameLastPlayed.Text = "Last Played: " + (new DateTime(2016, 12, 25)).ToShortDateString();
            gameLastPlayed.HorizontalAlignment = HorizontalAlignment.Left;
            gameLastPlayed.VerticalAlignment = VerticalAlignment.Top;
            gameLastPlayed.Margin = marginBuffer;
            gameLastPlayed.FontSize = 16;
            gameLastPlayed.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Left += 200;

            //Last Updated Time
            TextBlock gameLastUpdated = new TextBlock();
            gameLastUpdated.Text = "Last Updated: " + (new DateTime(2016, 12, 24)).ToShortDateString();
            gameLastUpdated.HorizontalAlignment = HorizontalAlignment.Left;
            gameLastUpdated.VerticalAlignment = VerticalAlignment.Top;
            gameLastUpdated.Margin = marginBuffer;
            gameLastUpdated.FontSize = 16;
            gameLastUpdated.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Left += 220;

            //Game Size
            TextBlock gameSize = new TextBlock();
            gameSize.Text = "Game Size: " + 1 + " GB";
            gameSize.HorizontalAlignment = HorizontalAlignment.Left;
            gameSize.VerticalAlignment = VerticalAlignment.Top;
            gameSize.Margin = marginBuffer;
            gameSize.FontSize = 16;
            gameSize.FontFamily = new FontFamily("Comic Sans MS");

            //Open Game Button
            Button gameButton = new Button();
            gameButton.Content = "Play Game";
            gameButton.HorizontalAlignment = HorizontalAlignment.Right;
            gameButton.VerticalAlignment = VerticalAlignment.Bottom;
            gameButton.Height = 40;
            gameButton.Width = 100;
            gameButton.Margin = new Thickness(0, 0, 30, 20);
            //Found here: https://stackoverflow.com/questions/57131019/how-to-add-a-click-handler-to-dynamic-created-button-in-c-sharp-wpf-an-object-i
            gameButton.Click += (_, args) =>
            {
                string gameLocation = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\th16tr\\th16.exe";
                try
                {
                    System.Diagnostics.Process.Start(gameLocation);
                }
                catch
                {
                    //show error somewhere
                };
            };
            marginBuffer = gameButton.Margin;

            Button removeButton = new Button();
            removeButton.Content = "Remove Game";
            removeButton.HorizontalAlignment = HorizontalAlignment.Right;
            removeButton.VerticalAlignment = VerticalAlignment.Top;
            removeButton.Height = 40;
            removeButton.Width = 100;
            removeButton.Margin = marginBuffer;
            removeButton.Click += new RoutedEventHandler(RemoveGameButton_Click);


            //Add things needed in the gameWindow to the Grid
            mainGrid.Children.Add(gameLogo);
            mainGrid.Children.Add(gameName);
            mainGrid.Children.Add(gameDesc);
            mainGrid.Children.Add(gameLastPlayed);
            mainGrid.Children.Add(gameLastUpdated);
            mainGrid.Children.Add(gameSize);
            mainGrid.Children.Add(gameButton);
            mainGrid.Children.Add(removeButton);

            gameWindow.Content = mainGrid;

            gameWindow.Show();
        }
    }
}
