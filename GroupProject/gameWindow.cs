using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GroupProject
{
    class gameWindow : Window
    {
        Grid mainGrid;
        public gameWindow(game loadGame)
        {
            this.Height = 400;
            this.Width = 800;

            mainGrid = new Grid();
            mainGrid.RenderSize = new Size(this.Height, this.Width);

            fillGrid();

            this.Content = mainGrid;
            //TODO: Complete stuff here
        }

        private void fillGrid()
        {
            //TODO: This stuff here
        }
    }
}
