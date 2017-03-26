namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");

            for (int i = 0; i < inputLines.Length; i++)
            {
                File.AppendAllText("output.txt", $"{i + 1}. {inputLines[i]}{Environment.NewLine}");
            }
        }
    }
}
