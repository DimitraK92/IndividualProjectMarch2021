using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjPartA.Utilities
{
    class GetFromKeyboard
    {
        public static string GetStringFromKeyboard(string labelName)
        {
            Console.Write($"Please, give {labelName}:");
            var stringFromKeyboard = "";
            do
            {
                stringFromKeyboard = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringFromKeyboard))
                {
                    Console.Write($"Please enter a valid {labelName}:");
                }
            }
            while (string.IsNullOrWhiteSpace(stringFromKeyboard));
            return stringFromKeyboard;
        }
        public static decimal GetDecimalFromKeyboard(string labelName)
        {
            Console.Write($"Please, give {labelName} in euros:");
            decimal decimalFromKeyboard;
            while (!decimal.TryParse(Console.ReadLine(), out decimalFromKeyboard) || decimalFromKeyboard < 0)
            {
                Console.Write($"Please enter a valid {labelName}:");
            }
            return decimalFromKeyboard;
        }
        public static float GetFloatFromKeyboard(string labelName)
        {
            Console.Write($"Please, give {labelName}:");
            float floatlFromKeyboard;
            while (!float.TryParse(Console.ReadLine(), out floatlFromKeyboard) || floatlFromKeyboard < 0)
            {
                Console.Write($"Please enter a valid {labelName}:");
            }
            return floatlFromKeyboard;
        }       
        public static DateTime GetDateFromKeyboard(string labelName)
        {
            Console.Write($"Please, give {labelName} in this format: (year),(month),(day):");
            DateTime dateFromKeyboard;
            while (!DateTime.TryParse(Console.ReadLine(), out dateFromKeyboard))
            {
                Console.Write($"Please enter a valid {labelName}:");
            }
            return dateFromKeyboard;
        }
    }
}
