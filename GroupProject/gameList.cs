using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    class gameList
    {
        private List<game> gList;
        string dbFile;
        public gameList(string loadFile)
        {
            gList = new List<game>();
            loadList(loadFile);
            dbFile = loadFile;
        }

        public List<game> getList()
        {
            List<game> readonlyList = gList;
            return readonlyList;
        }
        public void loadList(string loadFile)
        {
            if (!System.IO.File.Exists(loadFile))
            {
                System.IO.File.Create(loadFile);
                return;
            }

            gameFactory fact = new gameFactory();

            string[] gameArr = new string[6];

            string[] text = System.IO.File.ReadAllLines(loadFile);
            for(int i = 0; i < text.Length; i++)
            {
                if(i % 5 == 0 && i != 0)
                {
                    //title, filepath, cover art, last played (in ticks), filesize, last updated
                    gList.Add(fact.loadGame(gameArr[1], gameArr[2], new Uri(gameArr[3]), new DateTime(long.Parse(gameArr[4])), double.Parse(gameArr[5]), System.IO.File.GetLastWriteTime(gameArr[2])));
                }
                gameArr[i % 6] = text[i];
            }

        }

        public void saveList()
        {
            List<string> data = new List<string>();
            foreach(game videogame in gList)
            {
                data.Add(videogame.getTitle());
                data.Add(videogame.getFilePath());
                data.Add(videogame.getCoverArt().OriginalString);
                data.Add(videogame.getLastPlayed().Ticks.ToString());
                data.Add(videogame.getFileSize().ToString());
            }

            System.IO.File.WriteAllLines(dbFile, data);
        }
    }
}
