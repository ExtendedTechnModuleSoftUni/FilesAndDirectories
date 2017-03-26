namespace FolderSize
{
    using System.IO;

    public class FolderSize
    {
        public static void Main()
        {
            var getFiles = Directory.GetFiles("TestFolder");

            double sum = 0;

            foreach (var file in getFiles)
            {
                FileInfo fileInfo = new FileInfo(file);

                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("output.txt", sum.ToString());
        }
    }
}
