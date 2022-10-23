using BigHomework_1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Services
{
    internal static class InputCheckMethods
    {
        public static string StringReadAndCheck()
        {
            string? input;
            input = Console.ReadLine();
            if (input == null || input == string.Empty)
            {
                throw new InvalidInputException();
            }
            else
            {
                return input;
            }
        }

        public static int IntReadAndCheck()
        {
            string? input;
            input = Console.ReadLine();

            bool result = int.TryParse(input, out var number);

            if (result == false)
            {
                throw new InvalidInputException();
            }

            return number;
        }

        public static double DoubleReadAndCheck()
        {
            string? input;
            input = Console.ReadLine();

            bool result = double.TryParse(input, out var number);

            if (result == false)
            {
                throw new InvalidInputException();
            }

            return number;
        }
    }
}
