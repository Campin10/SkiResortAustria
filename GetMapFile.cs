using System;
using System.IO;

namespace SkiResort
{
    public class GetMapFile
    {
        public int[,] Map; 
        public int[,] Path;
        public int[,] Drop;
        public int Rows;
        public int Columns;
  
      public void ReadFile(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                int counter = 0;
                string ln;
                ln = file.ReadLine();
                SetRowandColumns(ln);
                while ((ln = file.ReadLine()) != null)
                {
                    int j = 0;
                    string[] str = ln.Split(" ");
                    foreach (string s in str)
                    {
                        Map[counter, j++] = Convert.ToInt32(s);
                    }
                    counter++;
                }
                file.Close();
            }
        }

        private void SetRowandColumns(string ln)
        {
            if (ln != null)
            {
                string[] RowsColumns = ln.Split(" ");
                Columns = Convert.ToInt32(RowsColumns[1]);
                Rows = Convert.ToInt32(RowsColumns[0]);
                Map = new int[Rows, Columns];
                Path = new int[Rows, Columns];
                Drop = new int[Rows, Columns];
            }
        }
    }
}

