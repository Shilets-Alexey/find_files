using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Find_files
{
    public class FindFilesWithList
    {
        private List<string> RoundDirectory(string path)
        {
            List<string> files = new List<string>();
            return GetFiles(files, path);
        }

        private List<string> GetFiles(List<string> files, string path)
        {
            files.AddRange(Directory.GetFiles(path).Where(f => f.EndsWith(".html")));
            string[] directoris = Directory.GetDirectories(path);
            foreach (string dir_index in directoris)
            {
                GetFiles(files, dir_index);
            }
            return files;
        }

        public void FindFiles()
        {
        Get_Path:
            Console.WriteLine("Введите путь каталога");
            string path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                RoundDirectory(path);
                Console.WriteLine("Файлы с разрешением .html:");
                foreach (string file in RoundDirectory(path))
                {
                    Console.WriteLine(file);
                }
                if (RoundDirectory(path).Count == 0)
                {
                    Console.WriteLine("Нет файлов");
                }
            }
            else
            {
                Console.WriteLine("Ошибочка");
                goto Get_Path;
            }
        }

    }
}

