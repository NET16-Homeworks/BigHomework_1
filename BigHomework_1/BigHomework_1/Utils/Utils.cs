using BigHomework_1.Exceptions;

namespace BigHomework_1.Utils
{
    public class ConsoleHelper
    {
        public string ReadString(string message)
        {
            Console.WriteLine("{0}", message);

            var input = Console.ReadLine();

            if (input == string.Empty || input == null)
            {
                throw new InvalidInputException();
            }

            return input;
        }

        public int ReadInt(string message)
        {
            Console.WriteLine("{0}", message);

            var isSuccess = int.TryParse(Console.ReadLine(), out var input);

            if (!isSuccess)
            {
                throw new InvalidInputException();
            }

            return input;
        }

        public double ReadDouble(string message)
        {
            Console.WriteLine("{0}", message);

            var isSuccess = double.TryParse(Console.ReadLine(), out var input);

            if (!isSuccess)
            {
                throw new InvalidInputException();
            }

            return input;
        }
    }
}
