using System;
using System.IO;


namespace Find_files
{
    class Program
    {
        static void Main(string[] args)
        {
        Get_path:
            Console.WriteLine("Вариант[1/2]");
            var a = Console.ReadLine();
            switch (a)
            {
                case "1":
                    Console.WriteLine("Вы выбрали вариант1");
                    break;
                case "2":
                    Console.WriteLine("Вы выбрали вариант2");
                    break;
                default:
                    Console.WriteLine("1 или 2");
                    goto Get_path;
            }
            if (a == "1")
            {
                FindFilesWithList file = new FindFilesWithList();
                try
                {
                    file.FindFiles();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto Get_path;
                }
                Console.ReadKey();
            }
            else
            {
                FindFilesWithIEnumerabe file = new FindFilesWithIEnumerabe();
                try
                {
                    file.FindFiles();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto Get_path;
                }
                Console.ReadKey();
            }
        }
    }
}

