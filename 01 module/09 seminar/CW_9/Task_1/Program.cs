using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void DirInfo(string path, int level)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            Console.WriteLine(di.Name);
            Console.WriteLine(di.Attributes.ToString());
            Console.WriteLine(di.CreationTime.ToString());
            Console.WriteLine(di.LastAccessTime.ToString());
            Console.WriteLine("");
            if (level > 1)
            {
                string[] dirs = Directory.GetDirectories(path);
                for (int i = 0; i < dirs.Length; ++i)
                    DirInfo(dirs[i], level - 1);
            }
        }

        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            DirInfo(path, 3);
        }
    }
}
