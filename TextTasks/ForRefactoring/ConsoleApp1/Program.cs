namespace Kravchuk
{
    sealed class Program
    {
        static void Main()
        {
            uint _inputedNumber;

            InputOutputData.Welcome();

            if (!InputOutputData.TryReadUint(out _inputedNumber)) return;

            InputOutputData.PrintResults(
                _inputedNumber.Factorial(),
                _inputedNumber.SumFromOne(),
                _inputedNumber.MaxOdd());
        }
    }

    static class InputOutputData
    {
        /// <summary>
        /// String to exit
        /// </summary>
        private static string _stopSymbol = "q";

        /// <summary>
        /// Print welcome message
        /// </summary>
        public static void Welcome()
        {
            Console.WriteLine("Здравствуйте. Вас приветствует математическая программа\n");
            Console.WriteLine("Пожалуйста, введите число.");
        }

        /// <summary>
        /// Return true if input is correct
        /// </summary>
        /// <param name="result">Inputed number</param>
        /// <returns></returns>
        public static bool TryReadUint(out uint result)
        {
            result = 0;
            string input = "";

            // Input data must be positive integer
            do
            {
                Console.WriteLine($"Необходимо ввести целое положительное число меньше {UInt32.MaxValue}. Для выхода введите \'{_stopSymbol}\':");
                input = Console.ReadLine();

                if (input == _stopSymbol)
                    return false;
            }
            while (!UInt32.TryParse(input, out result));

            return true;
        }

        /// <summary>
        /// Print results
        /// </summary>
        /// <param name="factorial"></param>
        /// <param name="sumDigits"></param>
        /// <param name="maxOdd"></param>
        public static void PrintResults(ulong factorial, ulong sumDigits, uint maxOdd)
        {
            if (factorial != 0)
                Console.WriteLine($"\nФакториал равен {factorial}");
            else
                Console.WriteLine($"\nНевозможно рассчитать факториал - значение слишком велико");

            Console.WriteLine($"Сума от 1 до N равна {sumDigits}");
            Console.WriteLine($"Максимальное четное число меньше N равно {maxOdd}\n");
            Console.WriteLine("Для завершения нажмите любую кнопку");
            Console.ReadKey();
        }
    }

    static class DataManipulation
    {
        /// <summary>
        /// Calculate factorial. Return 0, if result greater than ulong (if inputNumber greater than 21)
        /// </summary>
        /// <param name="inputNumber">Must be less than 21</param>
        /// <returns></returns>
        public static ulong Factorial(this uint inputNumber)
        {
            byte maxValue = 21;
            ulong result = 1;

            if (inputNumber < maxValue)
            {
                for (uint i = 1; i <= inputNumber; i++)
                {
                    result *= i;
                }

                return result;
            }
            else
                return 0;
        }

        /// <summary>
        /// Calculate sum of numbers from 1 to inputNumber
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns></returns>
        public static ulong SumFromOne(this uint inputNumber)
        {
            return inputNumber * (inputNumber + 1) / 2;
        }

        /// <summary>
        /// Return max odd less than inputNumber
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns></returns>
        public static uint MaxOdd(this uint inputNumber)
        {
            uint result = 0;
            if (inputNumber > 2)
                if (inputNumber % 2 == 0)
                    result = inputNumber - 2;
                else
                    result = inputNumber - 1;

            return result;
        }
    }
}
