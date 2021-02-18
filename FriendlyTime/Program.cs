using System;
using FriendlyTimeUtils;

namespace FriendlyTime
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length==0)
            {
                DisplayFriendlyTime(DateTime.Now);
            }
            else
            {
                var timeEntered = args[0];
                var validator = new CommandValidator();
                
                if (!validator.IsValid(timeEntered))
                {
                    Console.Write($"Cannot parse. Args given {timeEntered} is not in valid format MM:HH like 14:05");
                    return;
                };

                var hours = Convert.ToInt32(timeEntered.Substring(0, 2));
                var minutes = Convert.ToInt32(timeEntered.Substring(3, 2));
                var ts = DateTime.Now;
                ts = new DateTime(ts.Year, ts.Month, ts.Day, hours, minutes, 0);
                DisplayFriendlyTime(ts);
            }
        }

        private static void DisplayFriendlyTime(DateTime dateTime)
        {
            Console.WriteLine(dateTime.ToHumanFriendlyDateString());
        }
    }
}