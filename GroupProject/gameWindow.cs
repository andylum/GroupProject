using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.ComponentModel;

namespace GroupProject
{
    class gameWindow : Window
    {
        private Grid mainGrid;
        private game loadedGame;
        private bool isClosing = false;
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

        protected override void OnClosing(CancelEventArgs e)
        {
            isClosing = true;
            base.OnClosing(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            if (!isClosing)
            {
                this.Close();
            }
            base.OnDeactivated(e);
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
            //TODO: maybe get rid of this idk. If they own the game already do they need a description of it?
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
            if (loadedGame.getLastPlayed() == new DateTime(0))
            {
                gameLastPlayed.Text = "Unplayed.";
            }
            else
            {
                gameLastPlayed.Text = "Last Played: " + loadedGame.getLastPlayed().ToShortDateString();
            }
            gameLastPlayed.HorizontalAlignment = HorizontalAlignment.Left;
            gameLastPlayed.VerticalAlignment = VerticalAlignment.Top;
            gameLastPlayed.Margin = marginBuffer;
            gameLastPlayed.FontSize = 16;
            gameLastPlayed.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Left += 200;

            //Last Updated Time
            TextBlock gameLastUpdated = new TextBlock();
            gameLastUpdated.Text = "Last Updated: " + loadedGame.getLastUpdated().ToShortDateString();
            gameLastUpdated.HorizontalAlignment = HorizontalAlignment.Left;
            gameLastUpdated.VerticalAlignment = VerticalAlignment.Top;
            gameLastUpdated.Margin = marginBuffer;
            gameLastUpdated.FontSize = 16;
            gameLastUpdated.FontFamily = new FontFamily("Comic Sans MS");
            marginBuffer.Left += 220;

            //Game Size
            double fileSize = loadedGame.getFileSize();
            int TeraGigaMegaKiloByte = 0;
            string prefix = "";
            while(fileSize >= 1000)
            {
                TeraGigaMegaKiloByte++;
                fileSize /= 1000;
            }
            switch (TeraGigaMegaKiloByte)
            {
                case 1:
                    prefix = "K";
                    break;
                case 2:
                    prefix = "M";
                    break;
                case 3:
                    prefix = "G";
                    break;
                case 4:
                    prefix = "T";
                    break;
                default:
                    break;
            }
            TextBlock gameSize = new TextBlock();
            gameSize.Text = "Game Size: " + (int)fileSize + " " + prefix + "B";
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
