using System;
using System.IO;


namespace Find_files
{
    class Program
    {
        static void Main(string[] args)
        {
            bool t = true;
            while (t)
            {
                Console.WriteLine("Вариант c List или c IEnumerable[1/2]");
                var a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        Console.WriteLine("Вы выбрали вариант с List ");
                        FindFilesWithList file = new FindFilesWithList();
                        file.FindFiles();
                        Console.ReadKey();
                        t = false;
                        break;
                    case "2":
                        Console.WriteLine("Вы выбрали вариант c IEnumerable");
                        FindFilesWithIEnumerabe files = new FindFilesWithIEnumerabe();
                        files.FindFiles();
                        Console.ReadKey();
                        break;
                        t = false;
                    default:
                        Console.WriteLine("1 или 2");
                        t = true;
                        break;
                }
            }
        }
    }
}

