using System.Text.RegularExpressions;

namespace FriendlyTimeUtils
{
    public class CommandValidator : ICommandValidator
    {
        private const string TimeRegexp = "^(?:[01][0-9]|2[0-3]):[0-5][0-9]$";

        /// <summary>
        /// Checks if command is valid: must be 24 hrs time format MM:HH
        /// </summary>
        /// <param name="command">Command as string, for example 13:05</param>
        /// <returns>Boolean value indicating if command is valid</returns>
        public bool IsValid(string command)
        {
            return !string.IsNullOrWhiteSpace(command) && 
                   Regex.IsMatch(command, TimeRegexp);
        }
    }
}    