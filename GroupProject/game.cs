using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GroupProject
{
    class game
    {
        private string title;
        private string filePath;
        private Uri coverArt;
        private DateTime lastPlayed;
        private double fileSize;
        private DateTime lastUpdated;

        public game()
        {
            //TODO: The constructor
        }

        public DateTime getLastPlayed()
        {
            return lastPlayed;
        }

        public double getFileSize()
        {
            return fileSize;
        }

        public DateTime getLastUpdated()
        {
            return lastUpdated;
        }

        public string getFilePath()
        {
            return filePath;
        }

        public string getTitle()
        {
            return title;
        }
        public Uri getCoverArt()
        {
            return coverArt;
        }

        public void execute()
        {
            System.Diagnostics.Process.Start(filePath);
        }

        public void dbUpdate()
        {
            //TODO: Update the information stored according to the database
        }
    }
}
