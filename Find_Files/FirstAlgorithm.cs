using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Find_Files;


namespace Find_files
{
    class FirstAlgorithm : AbstractAlgorithm
    {
        private List<string> FilesList { get; }

        public FirstAlgorithm()
        {
            FilesList = new List<string>();
        }

        private void GetFiles(string path)
        {
            FilesList.AddRange(Directory.GetFiles(path).Where(f => f.EndsWith(".html")));
            foreach (string dirIndex in Directory.GetDirectories(path))
            {
                GetFiles(dirIndex);
            }
        }

        public override void FindFiles()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите путь каталога");
                    string path = Console.ReadLine();
                    if (Directory.Exists(path))
                    {
                        GetFiles(path);
                        if (FilesList.Count != 0)
                        {
                            Console.WriteLine($"Файлы с расширением .html:  {FilesList.Count} штук");
                            foreach (string file in FilesList)
                            {
                                Console.WriteLine(file);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нет файлов");
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
                    break;
                }
            }
        }
    }
}

