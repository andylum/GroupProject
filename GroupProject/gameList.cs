using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    class gameList
    {
        //TODO: Also do this class as well
        List<game> gList;
        public gameList()
        {
            gList = new List<game>;
        }

        private void loadList()
        {
            gameFactory fact = new gameFactory();
            //read data for a game into memory
            //call fact to create game in list
            //loop until file empty, fill list with gamse
        }
    }
}
