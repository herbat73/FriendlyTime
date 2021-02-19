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

                DisplayFriendlyTime(timeEntered);
            }
        }

        private static void DisplayFriendlyTime(DateTime dateTime)
        {
            Console.WriteLine(dateTime.ToHumanFriendlyDateString());
        }
        
        private static void DisplayFriendlyTime(string time)
        {
            var hours = Convert.ToInt32(time.Substring(0, 2));
            var minutes = Convert.ToInt32(time.Substring(3, 2));
            var ts = DateTime.Now;
            ts = new DateTime(ts.Year, ts.Month, ts.Day, hours, minutes, 0);
            DisplayFriendlyTime(ts);
        }        
    }
}