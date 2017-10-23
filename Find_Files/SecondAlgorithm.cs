using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Find_Files;


namespace Find_files
{
    class SecondAlgorithm : IFindFiles
    {
        public List<string> FileList { get; set; } = new List<string>();

        private IEnumerable<string> FindVoid(string rootDirectory)
        {
            var content = Directory.EnumerateFileSystemEntries(rootDirectory).ToList();
            foreach (var folderItem in content)
            {
                FileAttributes attr = File.GetAttributes(folderItem);
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory) continue;
                string[] htmlFiles = Directory.GetFiles(folderItem, "*.html");
                foreach (var htmlItem in htmlFiles)
                    yield return htmlItem;
                foreach (var subFolderItem in FindVoid(folderItem))
                    yield return subFolderItem;
            }
        }


        public IEnumerable<string> GetFilesPaths()
        {
            string path = GetPathMethods.GetPathFromConsole();
            if (Directory.Exists(path))
            {
                FileList.AddRange(Directory.GetFiles(path).Where(f => f.EndsWith(".html")));
                try
                {
                    FileList.AddRange(FindVoid(path));

                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return FileList;
        }
    }
}
