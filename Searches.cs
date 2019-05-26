using System;
using System.Collections.Generic;

namespace SkiResort
{
    public class Searches : GetMapFile
    {
        //Caluculate path length and Drop
        public int[] GetLengthPathAndDrop(int i, int j)
        {
            int[] newPathAndDrop = { 0, i, j }; 
            int[] curPathAndDrop = new int[2];
            //up direction
            if (j > 0 && Map[i,j] > Map[i,j - 1])
            {
                curPathAndDrop = GetLengthPathAndDrop(i, j - 1);
                if (curPathAndDrop[0] > newPathAndDrop[0])
                    Array.Copy(curPathAndDrop, newPathAndDrop, curPathAndDrop.Length);
            }
            //down direction
            if (j < (Columns - 1) && Map[i,j] > Map[i,j + 1])
            {
                curPathAndDrop = GetLengthPathAndDrop(i, j + 1);
                if (curPathAndDrop[0] > newPathAndDrop[0])
                    Array.Copy(curPathAndDrop, newPathAndDrop, curPathAndDrop.Length);
            }
            //left direction
            if (i > 0 && Map[i,j] > Map[i - 1,j])
            {
                curPathAndDrop = GetLengthPathAndDrop(i - 1, j);
                if (curPathAndDrop[0] > newPathAndDrop[0])
                    Array.Copy(curPathAndDrop, newPathAndDrop, curPathAndDrop.Length);
            }
            //right direction
            if (i < (Rows - 1) && Map[i,j] > Map[i + 1,j])
            {
                curPathAndDrop = GetLengthPathAndDrop(i + 1, j);
                if (curPathAndDrop[0] > newPathAndDrop[0])
                    Array.Copy(curPathAndDrop, newPathAndDrop, curPathAndDrop.Length);
            }
            newPathAndDrop[0]++;
            return newPathAndDrop;
        }

        // get Long path map
        public List<int> GetPath(int x, int y)
        {
            List<int> newList = new List<int>();
            List<int> actPathList = new List<int>();
            // up direction
            if (y > 0 && Map[x,y] > Map[x,y - 1])
            {
                actPathList = GetPath(x, y - 1);
                if (actPathList.Count > newList.Count)
                    newList = actPathList;
            }
            //down direction
            if (y < (Columns - 1) && Map[x,y] > Map[x,y + 1])
            {
                actPathList = GetPath(x, y + 1);
                if (actPathList.Count > newList.Count)
                    newList = actPathList;
            }
            //left direction
            if (x > 0 && Map[x,y] > Map[x - 1,y])
            {
                actPathList = GetPath(x - 1, y);
                if (actPathList.Count > newList.Count)
                    newList = actPathList;
            }
            //right direction
            if (x < (Rows - 1) && Map[x,y] > Map[x + 1,y])
            {
                actPathList = GetPath(x + 1, y);
                if (actPathList.Count > newList.Count)
                    newList = actPathList;
            }
            newList.Add(y);
            newList.Add(x);
            return newList;
        }
    }
}
