namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class WordCount
    {
        public static void Main()
        {
            var listOfWords = File.ReadAllText("words.txt")
                .ToLower()
                .Split(' ');

            var text = File.ReadAllText("text.txt")
                .ToLower()
                .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

            var wordCount = new Dictionary<string, int>();

            foreach (var word in text)
            {
                if (listOfWords.Contains(word))
                {
                    if (!wordCount.ContainsKey(word))
                    {
                        wordCount[word] = 0;
                    }

                    wordCount[word]++;
                }          
            }

            var result = wordCount.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in result)
            {
                File.AppendAllText("result.txt", $"{kvp.Key} - {kvp.Value}{Environment.NewLine}");
            }
            //var result = new List<string>();

            //foreach (var item in wordCount.OrderByDescending(v => v.Value))
            //{
            //    result.Add(item.Key + " - " + item.Value);
            //}

            //File.WriteAllLines("result.txt", result);
        }
    }
}
