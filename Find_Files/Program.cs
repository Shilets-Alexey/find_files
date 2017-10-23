using System;
using Find_Files;


namespace Find_files
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Вариант c List или c IEnumerable[1/2]");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        CaseMethode(new FirstAlgorithm());
                        break;
                    case "2":
                        CaseMethode(new SecondAlgorithm());
                        break;
                    default:
                        Console.WriteLine("1 или 2");
                        break;
                }
            }
        }

        private static void CaseMethode(AbstractAlgorithm files)
        {
            Console.WriteLine($"Вы выбрали вариант {files.GetType().Name}");
            files.FindFiles();
            Console.ReadKey();
        }
    }
}

