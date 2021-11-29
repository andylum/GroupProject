using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    class steamGame : game
    {
        private UInt32 appID;

        public steamGame(string title, string filePath, Uri coverArt, DateTime lastPlayed, double fileSize, DateTime lastUpdated) : base(title, filePath, coverArt, lastPlayed, fileSize, lastUpdated)
        {
            //TODO: The constructor
        }

        public UInt32 getappID()
        {
            return appID;
        }
    }
}
