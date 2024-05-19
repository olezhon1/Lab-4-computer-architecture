using System;
using System.IO;

namespace Лабораторна_робота_4_АрхКомп
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть кількість основних каталогів: ");
            int mainDirectoriesCount;
            while (!int.TryParse(Console.ReadLine(), out mainDirectoriesCount) || mainDirectoriesCount <= 0)
            {
                Console.WriteLine("Введіть коректне число більше нуля.");
            }

            for (int i = 0; i < mainDirectoriesCount; i++)
            {
                Console.WriteLine($"\nОсновний каталог {i + 1}:");
                Console.WriteLine("Введіть повний шлях до основного каталогу:");
                Console.WriteLine("Наприклад: \"C:\\Users\\Олег\\Лабораторні\\ПЗ-23-3\\Гайдай_Олег_Володимирович\"");
                string dirname = Console.ReadLine();
                dirname = dirname.Trim('"').Replace("\\", "/");

                DirectoryInfo directory = new DirectoryInfo(dirname);

                if (directory.Exists)
                {
                    while (true)
                    {
                        Console.Write("Введіть ім'я підкаталогу для пошуку (або 'вийти' для завершення): ");
                        string searchDirName = Console.ReadLine();

                        if (searchDirName.Equals("вийти", StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }

                        DirectoryInfo[] subDirectories = directory.GetDirectories();
                        bool found = false;

                        foreach (DirectoryInfo subDirectory in subDirectories)
                        {
                            if (subDirectory.Name.Equals(searchDirName, StringComparison.Ordinal))
                            {
                                Console.WriteLine($"Підкаталог знайдено: {subDirectory.FullName}");
                                Console.WriteLine($"Атрибути: {subDirectory.Attributes}");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Підкаталог не знайдено.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Основний каталог не існує.");
                }
            }
        }
    }
}


