using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task1
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки");
            string path = Console.ReadLine();
            var time = DateTime.Now;
            var di = new DirectoryInfo(path);
            if (di.Exists)
            {
                try
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (time - file.LastAccessTime > TimeSpan.FromMinutes(30))
                        {
                            file.Delete();
                        }
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        if (time - dir.LastAccessTime > TimeSpan.FromMinutes(30))
                        {
                            dir.Delete(true);
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            }
            else { Console.WriteLine("Такой папки нет"); }
        }
    }
}
