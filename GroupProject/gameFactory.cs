using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    class gameFactory
    {
        private Uri getCoverArt(string title)
        {
            //TODO: remember to fix this with IGDB
            return new Uri("https://static.wikia.nocookie.net/senkizesshousymphogear/images/4/45/Symphogear_GX_Character_Song_8.png/revision/latest/scale-to-width-down/300?cb=20200728003041");
        }

        private string getTitle(string filePath)
        {
            //just gets the folder name from executable file path
            string[] splitPath = filePath.Split('\\');
            return new string(splitPath[splitPath.Length - 2]);
        }

        public game createGame(string filePath)
        {
            return new game(getTitle(filePath), filePath, getCoverArt(getTitle(filePath)), new DateTime(0), new System.IO.FileInfo(filePath).Length, System.IO.File.GetLastWriteTime(filePath));
        }

        public game loadGame(string title, string filePath, Uri coverArt, DateTime lastPlayed, double fileSize, DateTime lastUpdated)
        {
            return new game(title, filePath, coverArt, lastPlayed, fileSize, lastUpdated);
        }
    }

    
}
