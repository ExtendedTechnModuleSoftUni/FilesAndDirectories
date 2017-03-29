namespace _01E.FilterExtensions
{
    using System;
    using System.Linq;
    using System.IO;

    public class FilterExtensions
    {
        public static void Main()
        {
            var neededExtensions = Console.ReadLine();
            var files = Directory.GetFiles("input");

            foreach (var file in files)
            {
                var currentFileInfo = new FileInfo(file);
                var extensions = currentFileInfo.Extension.Split('.').Where(x => x != "").ToArray();
                if (extensions[0] == neededExtensions)
                {
                    Console.WriteLine(currentFileInfo.Name); 
                }          
            }
        }
    }
}
