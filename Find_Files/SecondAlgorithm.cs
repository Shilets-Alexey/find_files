using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Find_Files;


namespace Find_files
{
    class SecondAlgorithm : AbstractAlgorithm
    {
        public List<string> FileList { get; set; } = new List<string>();

        private IEnumerable<string> FindVoid(string rootDirectory)
        {
            var content = Directory.EnumerateFileSystemEntries(rootDirectory).ToList();
            foreach (var folderItem in content)
            {
                FileAttributes attr = File.GetAttributes(folderItem);
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory) continue;
                var htmlFiles = Directory.GetFiles(folderItem, "*.html");
                foreach (var htmlItem in htmlFiles)
                    yield return htmlItem;
                foreach (var subFolderItem in FindVoid(folderItem))
                    yield return subFolderItem;
            }
        }

        public override void FindFiles()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите путь каталога:");
                    string path = Console.ReadLine();
                    if (Directory.Exists(path))
                    {
                        
                        FileList.AddRange(Directory.GetFiles(path).Where(f => f.EndsWith(".html")));
                        FileList.AddRange(FindVoid(path));
                        if (FileList.Count == 0)
                            Console.WriteLine("Нет файлов");
                        else
                        {
                            Console.WriteLine($"Файлы с расширением .html:  {FileList.Count} штук");
                            foreach (var item in FileList)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибочка");
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
