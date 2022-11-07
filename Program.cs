using System;
using System.IO;
using System.Reflection;

class Task2
{
    public static void Main()
    {
        string InputPath = Console.ReadLine();
        DirectoryInfo dirInfo = new DirectoryInfo(InputPath);

        try
        {
            if (dirInfo.Exists)
            {
                Console.WriteLine(GetDirectorySize(InputPath));
                TimeSpan span1 = TimeSpan.FromMinutes(3);

                foreach (var f in dirInfo.GetFiles())

                    if (f.LastAccessTime < DateTime.Now - span1)
                    {
                        f.Delete();
                        Console.WriteLine("Удален файл, который не использовался более 30 минут {0}", f.Name);
                    }
                Console.WriteLine("текущий размер {0}",GetDirectorySize(InputPath));
                
            }
            else
            {
                Console.WriteLine("Файл не удален");
            }



        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    public static long GetDirectorySize(string folderPath)
    {
        DirectoryInfo di = new DirectoryInfo(folderPath);
        return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
    }
}
