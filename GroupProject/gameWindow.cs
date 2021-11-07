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
        public gameWindow()
        {
            this.Height = 400;
            this.Width = 800;

            mainGrid = new Grid();
            mainGrid.RenderSize = new Size(this.Height, this.Width);

            loadImage();
            //TODO: Complete stuff here
        }

        private void loadImage()
        {

        }
    }
}
