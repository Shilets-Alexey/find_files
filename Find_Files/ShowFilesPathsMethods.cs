using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Files
{
    static class ShowFilesPathsMethods
    {
        public static void PushToConsole(this IEnumerable<string> filelist)
        {
            if (filelist.Count() != 0)
            {
                foreach (string file in filelist)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("No files");
            }
        }
    }
}
