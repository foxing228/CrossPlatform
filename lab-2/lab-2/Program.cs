namespace Lab2
{
    public class Program
    {
        public static string InputFilePath = @"Input.txt";
        public static string OutputFilePath = @"Output.txt";

        static void Main(string[] args)
        {
            FileInfo outputFileInfo = new FileInfo(OutputFilePath);
            var number = Convert.ToInt32(File.ReadLines(InputFilePath).First().Trim());
            using (StreamWriter streamWriter = outputFileInfo.CreateText())
            {
                if (number < 1 || number > 1000)
                {
                    streamWriter.WriteLine("Number is out of range");
                }
                else
                {
                    streamWriter.WriteLine(GetCountOfWaysToShowNumber(number));
                }
            }
        }

        /// <summary>
        /// Отримати кількість способів представлення числа, яке передали у функцію
        /// </summary>
        public static int GetCountOfWaysToShowNumber(int number)
        {
            int result = 0;
            int currPower = 0;
            while (Math.Pow(2, currPower) <= number)
            {
                result += getCountOfWaysToShowNumberWithPower(number, currPower);
                currPower++;
            }
            return result;
        }

        /// <summary>
        /// Кількість способів представлення числа number, у кожному представленні як мінімум одне значення 2**mainPower
        /// </summary>
        private static int getCountOfWaysToShowNumberWithPower(int number, int mainPower)
        {
            if (number == 0)
            {
                return 0;
            }
            if (mainPower == 0)
            {
                return 1;
            }
            int count = 0;
            int numOfMainPowerNums = 1;
            while (true)
            {
                int nextNumber = number - (numOfMainPowerNums * Convert.ToInt32(Math.Pow(2, mainPower)));
                if(nextNumber < 0)
                {
                    break;
                }
                if(nextNumber == 0)
                {
                    count++;
                    break;
                }
                else
                {
                    for (int i = mainPower - 1; i >= 0; i--)
                    {
                        count += getCountOfWaysToShowNumberWithPower(nextNumber, i);
                    }
                    numOfMainPowerNums++;
                }
            }
            return count;
        }
    }
}