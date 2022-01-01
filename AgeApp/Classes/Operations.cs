using System;
using myage.Extensions;

// ReSharper disable once IdentifierTypo
namespace myage.Classes
{
    public class Operations
    {
        public static void RunWork(CommandLineOptions options)
        {
            var fromDateTime = options.From;
            
            if (options.To.CheckDate(options.From))
            {
                Console.WriteLine($"Invalid date(s): From {options.From:d} To {options.To:d}");
                Environment.Exit(-1);
            }

            if (options.To == DateTime.MinValue)
            {
                options.To = DateTime.Now;
            }

            var toDateTime = options.To;
            var age = fromDateTime.Age(toDateTime);

            Console.WriteLine($"Age is {age.YearsMonthsDays}");
        }
    }
}
