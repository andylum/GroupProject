using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    class gameList
    {
        //TODO: Also do this class as well
        private List<game> gList;
        public gameList(string loadFile)
        {
            gList = new List<game>();
            loadList();
        }

        public List<game> getList()
        {
            List<game> readonlyList = gList;
            return readonlyList;
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
