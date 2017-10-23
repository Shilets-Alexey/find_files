using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Find_Files;


namespace Find_files
{
    class FirstAlgorithm : IFindFiles
    {
        private List<string> FilesList { get; }

        public FirstAlgorithm()
        {
            FilesList = new List<string>();
        }

        private void GetFiles(string path)
        {
            try
            {
                FilesList.AddRange(Directory.GetFiles(path).Where(f => f.EndsWith(".html")));
                foreach (string dirIndex in Directory.GetDirectories(path))
                {
                    GetFiles(dirIndex);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<string> GetFilesPaths()
        {
            GetFiles(GetPathMethods.GetPathFromConsole());
            return FilesList;
        }
    }
}

