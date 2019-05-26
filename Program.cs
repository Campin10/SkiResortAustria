using System;

namespace SkiResort
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessSky process = new ProcessSky("map.txt");
            Console.WriteLine("Length of calculated path: " + process.valueLengthPath + "\nDrop of calculated path: " + process.valueDrop);
            Console.WriteLine("Calculated path:" +  process.routesSky);
        }
    }
}






