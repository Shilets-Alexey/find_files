using System;
using System.IO;

namespace Find_Files
{
    static class GetPathMethods
    {
        public static string GetPathFromConsole()
        {
            while (true)
            {
                Console.WriteLine("Enter the path");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    return path;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}
