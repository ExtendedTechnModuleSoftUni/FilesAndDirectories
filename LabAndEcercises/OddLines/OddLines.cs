namespace OddLines
{
    using System.Collections.Generic;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            var linesArray = File.ReadAllLines("input.txt");

            var oddLines = new List<string>();

            for (int i = 1; i < linesArray.Length; i+= 2)
            {
                oddLines.Add(linesArray[i]);
            }

            File.AppendAllText("output.txt", string.Join("\r\n", oddLines));
        }
    }
}
