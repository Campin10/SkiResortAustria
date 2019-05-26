using System.Collections.Generic;

namespace SkiResort
{
    public class ProcessSky : Searches
    {
        public int[] CoordinateValueXY = new int[2];
        public int valueLengthPath = -1;
        public int valueDrop = -1;
        public string routesSky = "";
        public ProcessSky(string route)
        {
            ReadFile(route);
            GetMaxPathandmaxDrop();
            GetSkiingDownProcess();
        }

        private void GetMaxPathandmaxDrop()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int[] temp = GetLengthPathAndDrop(i, j);
                    Path[i, j] = temp[0];
                    Drop[i, j] = Map[i, j] - Map[temp[1], temp[2]];
                    if (Path[i, j] > valueLengthPath)
                    {
                        valueDrop = Drop[i, j];
                        valueLengthPath = Path[i, j];
                        CoordinateValueXY[0] = i;
                        CoordinateValueXY[1] = j;
                    }
                    if (Path[i, j] == valueLengthPath)
                    { 
                        if (Drop[i, j] > valueDrop)
                        { 
                            valueDrop = Drop[i, j];
                            CoordinateValueXY[0] = i;
                            CoordinateValueXY[1] = j;
                        }
                    }
                }
            }
        }

        private void GetSkiingDownProcess()
        {
            int m = 0;
            List<int> list = GetPath(CoordinateValueXY[0], CoordinateValueXY[1]); // store x, y values in a list
            list.Reverse();
            do {
                routesSky = routesSky + "-"+ Map[list[m], list[m+1]];
                m +=2;
            } while (m < list.Count);
        }
    }
}
