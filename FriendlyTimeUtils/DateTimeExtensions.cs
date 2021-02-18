using System;

namespace FriendlyTimeUtils
{
    public static class DateTimeExtensions
    {
        private static readonly string[] NumberOnes = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static readonly string[] NumberTeens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        public static string ToHumanFriendlyDateString(this DateTime date)
        {
            var formattedDate = "";
            var minutes = date.Minute;
            var hour = date.Hour;

            if (hour == 0 && minutes == 0)
            {
                formattedDate = "midnight";
            }
            else if (minutes == 0)
            {
                formattedDate = $"{FormatHours(hour)} o'clock";
            }
            else if (minutes < 30)
            {
                formattedDate = $"{FormatMinutes(minutes)} past {FormatHours(hour)}";
            }
            else if (minutes == 30)
            {
                formattedDate = $"Half past {FormatHours(hour)}";
            }
            else
            {
                formattedDate = $"{FormatMinutes(60 - minutes)} to {FormatHours(hour + 1)}";
            }
            
            return formattedDate.FirstCharToUpper(); 
        }

        private static string FormatMinutes(int minutes)
        {
            var result = "";
            
            if (minutes < 10)
            {
                result = NumberOnes[minutes];
            }
            else if (minutes < 20)
            {
                result = NumberTeens[minutes - 10];
            }
            else if (minutes < 30)
            {
                result = $"twenty {FormatMinutes(minutes - 20)}";
            }
            else if (minutes == 30)
            {
                result = "half";
            }
            else 
            {
                result = FormatMinutes(minutes - 30);
            }

            return result;
        }
        
        private static string FormatHours(int hours)
        {
            var result = "";
            
            if (hours < 10)
            {
                result = NumberOnes[hours];
            }
            else if (hours <= 12)
            {
                result = NumberTeens[hours - 10];
            }
            else 
            {
                result = FormatHours(hours - 12);
            }

            return result;
        }        
    }
}