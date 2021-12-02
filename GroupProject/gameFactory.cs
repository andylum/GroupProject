using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    class gameFactory
    {
        private Uri getCoverArt(string title)
        {
            //I'm too dumb to make a twitch app so this is gonna be a smiley face.
            return new Uri("https://pbs.twimg.com/media/FFlBHyBXMAMczvx?format=png&name=small");
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
