using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    class gameFactory
    {
        private Uri getCoverArt(string title)
        {
            //TODO: get the cover art from the internet
        }

        public game createGame(string title, string filePath, DateTime lastPlayed, double fileSize, DateTime lastUpdated)
        {
            try
            {
                return createSteamGame(title, filePath, lastPlayed, fileSize, lastUpdated, -1);
            }
            catch
            {
                return new game(title, filePath, getCoverArt(title), lastPlayed, fileSize, lastUpdated);
            }
        }

        public steamGame createSteamGame(string title, string filePath, DateTime lastPlayed, double fileSize, DateTime lastUpdated, int appID = -1)
        {
            throw new Exception("This is just for testing purposes bc I want to compile this sometime soon.");
        }

    }

    
}
