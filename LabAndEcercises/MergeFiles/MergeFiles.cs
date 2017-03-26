namespace MergeFiles
{
    using System.Collections.Generic;
    using System.IO;

    public class MergeFiles
    {
        public static void Main()
        {
            var firstFile = File.ReadAllLines("FileOne.txt");
            var secondFile = File.ReadAllLines("FileTwo.txt");

            var sortedFile = new List<string>();

            sortedFile.AddRange(firstFile);
            sortedFile.AddRange(secondFile);
            sortedFile.Sort();         

            File.AppendAllLines("result.txt", sortedFile);
        }
    }
}
