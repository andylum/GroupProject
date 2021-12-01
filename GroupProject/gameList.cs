using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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

            string[] text;

            try
            {
                text = System.IO.File.ReadAllLines(loadFile);
            }catch (Exception e){
                Window errorWin = new Window();
                TextBox error = new TextBox();
                errorWin.Height = 200;
                errorWin.Width = 200;
                error.Text = e.Message;
                error.TextWrapping = TextWrapping.Wrap;
                errorWin.Content = error;
                errorWin.Show();
                return;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if(i % 5 == 0 && i != 0)
                {
                    //title, filepath, cover art, last played (in ticks), filesize, last updated
                    gList.Add(fact.loadGame(gameArr[0], gameArr[1], new Uri(gameArr[2]), new DateTime(long.Parse(gameArr[3])), double.Parse(gameArr[4]), System.IO.File.GetLastWriteTime(gameArr[1])));
                }
                gameArr[i % 5] = text[i];
            }

            gList.Add(fact.loadGame(gameArr[0], gameArr[1], new Uri(gameArr[2]), new DateTime(long.Parse(gameArr[3])), double.Parse(gameArr[4]), System.IO.File.GetLastWriteTime(gameArr[1])));
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

        public void clearList()
        {
            gList.Clear();
        }

        public void removeGame(game removeGame)
        {
            for(int i = 0; i < gList.Count; i++)
            {
                if(gList[i].getFilePath() == removeGame.getFilePath())
                {
                    gList.RemoveAt(i);
                    break;
                }
            }
            saveList();
        }
    }
}
