using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace GroupProject
{
    class gameWindow : Window
    {
        Grid mainGrid;
        game loadedGame;
        public gameWindow(game loadGame)
        {
            this.Height = 400;
            this.Width = 800;
            loadedGame = loadGame;

            mainGrid = new Grid();
            mainGrid.RenderSize = new Size(this.Height, this.Width);

            fillGrid();

            this.Content = mainGrid;
            this.Show();
        }

        public virtual void On_LostFocus()
        {
            this.Close();
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

        private void fillGrid()
        {
            //Logo
            //Uses half the size of the header.jpg present on steamdb
            //TODO: Make this change based on the DB site used.
            Image gameLogo = new Image();
            gameLogo.Width = 230;
            gameLogo.Height = 107;
            gameLogo.Source = new BitmapImage(loadedGame.getCoverArt());
            gameLogo.HorizontalAlignment = HorizontalAlignment.Left;
            gameLogo.VerticalAlignment = VerticalAlignment.Top;
            //marginBuffer moves the position of the objects based on the previous object's position
            Thickness marginBuffer = new Thickness(10, 10, 0, 0);
            gameLogo.Margin = marginBuffer;
            marginBuffer.Top += gameLogo.Height;

            //Game Name
            TextBlock gameName = new TextBlock();
            gameName.Text = String.Format("Name: {0}", loadedGame.getTitle());
            gameName.HorizontalAlignment = HorizontalAlignment.Left;
            gameName.VerticalAlignment = VerticalAlignment.Top;
            gameName.Margin = marginBuffer;
            gameName.FontSize = 16;
            gameName.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Top += 30;

            //Game Descritpion
            TextBlock gameDesc = new TextBlock();
            string dbData = "";
            if (loadedGame.GetType().GetMethod("getappID") != null)
            {
                //get data from steamdb
            }
            else
            {
                //get data from igdb
            }
            gameDesc.Text = dbData;
            gameDesc.HorizontalAlignment = HorizontalAlignment.Left;
            gameDesc.VerticalAlignment = VerticalAlignment.Top;
            gameDesc.Margin = marginBuffer;
            gameDesc.Width = this.Width;
            gameDesc.TextWrapping = TextWrapping.Wrap;
            gameDesc.FontSize = 16;
            gameDesc.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Top += 100;


            //Last Played Time
            TextBlock gameLastPlayed = new TextBlock();
            gameLastPlayed.Text = "Last Played: " + loadedGame.getLastPlayed();
            gameLastPlayed.HorizontalAlignment = HorizontalAlignment.Left;
            gameLastPlayed.VerticalAlignment = VerticalAlignment.Top;
            gameLastPlayed.Margin = marginBuffer;
            gameLastPlayed.FontSize = 16;
            gameLastPlayed.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Left += 200;

            //Last Updated Time
            TextBlock gameLastUpdated = new TextBlock();
            gameLastUpdated.Text = "Last Updated: " + loadedGame.getLastUpdated();
            gameLastUpdated.HorizontalAlignment = HorizontalAlignment.Left;
            gameLastUpdated.VerticalAlignment = VerticalAlignment.Top;
            gameLastUpdated.Margin = marginBuffer;
            gameLastUpdated.FontSize = 16;
            gameLastUpdated.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Left += 220;

            //Game Size
            TextBlock gameSize = new TextBlock();
            gameSize.Text = "Game Size: " + loadedGame.getFileSize();
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

                try
                {
                    System.Diagnostics.Process.Start(loadedGame.getFilePath());
                }
                catch
                {
                    Window errorWin = new Window();
                    TextBox error = new TextBox();
                    error.Text = "Failed to Start Game";
                    errorWin.Content = error;
                    
                };
            };

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
        }
    }
}
