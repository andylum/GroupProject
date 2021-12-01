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

        private void fillGrid()
        {
            //TODO: Restructure for IGDB cover art.

            //Logo
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
            //TODO: maybe get rid of this idk
            TextBlock gameDesc = new TextBlock();
            string dbData = "";
            {
                //TODO: get data from igdb
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
            //StackOverflow god teaching me about anonymous functions: https://stackoverflow.com/questions/13793490/close-dynamically-created-form-with-dynamic-button
            gameButton.Click += (_, args) =>
            {

                try
                {
                    loadedGame.execute();
                }
                catch
                {
                    Window errorWin = new Window();
                    TextBox error = new TextBox();
                    error.Text = "Failed to Start Game";
                    errorWin.Content = error;
                };
            };

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
