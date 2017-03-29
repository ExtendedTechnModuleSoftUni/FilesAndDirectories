namespace _03E.UserDatabase
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class UserDatabase
    {
        private static string path = "users.txt";
        private static Dictionary<string, string> avilableUsers = new Dictionary<string, string>();
        private static string loggedInUser = null;

        public static void Main()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var currentLine = line.Split(' ');
                var userName = currentLine[0];
                var password = currentLine[1];

                avilableUsers[userName] = password;
            }

            var commands = File.ReadAllLines("input.txt");

            foreach (var command in commands)
            {
                var commandParts = command.Split(' ');

                switch (commandParts[0])
                {
                    case "register":
                        var userName = commandParts[1];
                        var password = commandParts[2];
                        var confirmPassword = commandParts[3];

                        RegisterUser(userName, password, confirmPassword);
                        break;
                    case "login":
                        userName = commandParts[1];
                        password = commandParts[2];

                        LoginUser(userName, password);
                        break;
                    case "logout":
                        Logout();
                        break;
                }
            }
        }

        private static void Logout()
        {
            if (loggedInUser == null)
            {
                Console.WriteLine("There is no currently logged in user.");
                return;
            }

            loggedInUser = null;
        }

        private static void LoginUser(string userName, string password)
        {
            if (loggedInUser != null)
            {
                Console.WriteLine("There is already a logged in user.");
                return;
            }

            if (!avilableUsers.ContainsKey(userName))
            {
                Console.WriteLine("There is no user with the given username.");
                return;
            }

            if (avilableUsers[userName] != password)
            {
                Console.WriteLine("The password you entered is incorrect.");
                return;
            }

            loggedInUser = userName;
        }

        private static void RegisterUser(string userName, string password, string confirmPassword)
        {
            if (avilableUsers.ContainsKey(userName))
            {
                Console.WriteLine("The given username already exists.");
                return;
            }

            if (password != confirmPassword)
            {
                Console.WriteLine("The two passwords must match.");
                return;
            }

            avilableUsers[userName] = password;

            File.AppendAllLines(path, new[] { $"{userName} {password}" });
        }
    }
}
