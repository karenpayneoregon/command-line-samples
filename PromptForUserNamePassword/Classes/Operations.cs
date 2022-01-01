using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PromptForUserNamePassword.LanguageExtensions;

namespace PromptForUserNamePassword.Classes
{
    public class Operations
    {
        /// <summary>
        /// Dummy work for the application
        /// </summary>
        /// <param name="options"><see cref="CommandLineOptions"/></param>
        public static void RunWork(CommandLineOptions options)
        {
            var userName = options.Username.Trim();
            var password = options.Password.Trim();

            if (Secrets.UsersInformation().ContainsKey(userName))
            {
                if (Secrets.UsersInformation()[userName] == password)
                {
                    Console.WriteLine($"Welcome {userName.FirstCharToUpper()} using password {password.FirstCharToUpper()}");
                }
                else
                {
                    ConsoleColors.WriteLineRed("Access denied");
                }
            }
            else
            {
                ConsoleColors.WriteLineRed("Access denied");
            }

            ConsoleWaiter.ReadLineWithTimeout();
        }

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "User name and password demo";
        }
    }
}
