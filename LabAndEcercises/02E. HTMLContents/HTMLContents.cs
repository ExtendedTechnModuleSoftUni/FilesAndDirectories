namespace _02E.HTMLContents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;

    public class HTMLContents
    {
        public static void Main()
        {
            var commands = File.ReadAllLines("../../input.txt");
            var bodyLines = new List<string>();
            var title = string.Empty;

            foreach (var command in commands)
            {
                if (command != "exit")
                {
                    var currentCommand = command.Split(' ').ToArray();
                    var tag = currentCommand[0];
                    var tagContent = currentCommand[1];

                    if (tag == "title")
                    {
                        title = tagContent;
                    }
                    else
                    {
                        bodyLines.Add($"\t<{tag}>{tagContent}<{tag}>");
                    }
                }             
            }

            var result = new StringBuilder();
            
            result.AppendLine("<!DOCTYPE html>");
            result.AppendLine("<html>");
            result.AppendLine("<head>");
            if (title != string.Empty)
            {
                result.AppendLine($"\t<title>{title}</title");
            }

            result.AppendLine("</head>");
            result.AppendLine("<body>");
            if (bodyLines.Any())
            {
                result.AppendLine(string.Join("\r\n", bodyLines));
            }
            result.AppendLine("</body>");
            result.Append("</html>");
     
            File.WriteAllText("index.html", result.ToString().Trim());
        }
    }
}
