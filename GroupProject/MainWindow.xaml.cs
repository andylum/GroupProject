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
        Grid browseGamesWin;
        Grid extrasPanel;
        public MainWindow()
        {
            Grid winContent = new Grid();
            browseGamesWin = new Grid();
            extrasPanel = new Grid();

            extrasPanel.Height = this.Height;
            extrasPanel.Width = 100;
            browseGamesWin.Height = this.Height;
            browseGamesWin.Width = this.Width - extrasPanel.Width;

            browseGamesWin.HorizontalAlignment = HorizontalAlignment.Left;
            browseGamesWin.VerticalAlignment = VerticalAlignment.Top;

            extrasPanel.HorizontalAlignment = HorizontalAlignment.Right;
            extrasPanel.VerticalAlignment = VerticalAlignment.Top;

            winContent.Children.Add(extrasPanel);
            winContent.Children.Add(browseGamesWin);

            this.Content = winContent;

            InitializeComponent();
        }



    }
}
