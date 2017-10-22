
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Find_files
{
    class FindFilesWithIEnumerabe
    {
        public List<string> fileList = new List<string>();
        private IEnumerable<string> FindVoid(string rootDirectory)
        {
            var content = Directory.EnumerateFileSystemEntries(rootDirectory).ToList();
            foreach (var folderItem in content)
            {
                FileAttributes attr = File.GetAttributes(folderItem);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    var htmlFiles = Directory.GetFiles(folderItem, "*.html");
                    foreach (var htmlItem in htmlFiles)
                        yield return htmlItem;
                    foreach (var subFolderItem in FindVoid(folderItem))
                        yield return subFolderItem;
                }
            }
        }
        public void FindFiles()
        {
            bool t = true;
            while (t)
            {
                try
                {
                    Console.WriteLine("Введите путь каталога:");
                    string path = Console.ReadLine();
                    if (Directory.Exists(path))
                    {
                        fileList.AddRange(Directory.GetFiles(path).Where(f => f.EndsWith(".html")));
                        fileList.AddRange(FindVoid(path));
                        foreach (var item in fileList)
                        {
                            Console.WriteLine(item);

                        }
                        if (fileList.Count == 0)
                        {
                            Console.WriteLine("Нет файлов");

                        }
                        t = false;
                    }
                    else
                    {
                        Console.WriteLine("Ошибочка");
                        t = true;
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    t = true;
                }
            }
        }
    }

}
