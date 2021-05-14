using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjPartA.Utilities
{
    public static class RandomFunctions
    {
        public static Random Rnd = new Random();
        public static string GenerateRandomString(int minLength, int maxLength)
        {
            int length = Rnd.Next(minLength, maxLength);

            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var firstname = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Rnd.Next(s.Length)]).ToArray());
            return FirstCharToUpper(firstname);
        }
        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }


        public static DateTime GenerateRandomDate(DateTime minDate, DateTime maxDate, bool hasToBeWorkDay)
        {
            int range = (maxDate - minDate).Days;
            DateTime date;
            do
            {
                var days = Rnd.Next(range);
                date = minDate.AddDays(days);
                if (!hasToBeWorkDay) { return date; }
            } 
            while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
            return date;
        }

        public static decimal GenerateRandomDecimal(decimal minDecimal, decimal maxDecimal)
        {
            return Rnd.Next((int)Math.Truncate(minDecimal), (int)Math.Truncate(maxDecimal));
        }
        public static float GenerateRandomFloat(float minFloat, float maxFloat)
        {
            return Rnd.Next((int)Math.Truncate(minFloat), (int)Math.Truncate(maxFloat));
        }

    }
}
