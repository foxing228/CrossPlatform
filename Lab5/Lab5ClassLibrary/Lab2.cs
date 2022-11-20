namespace Lab5ClassLibrary;

public class Lab2
{

    public int GetCountOfWaysToShowNumber(int number)
    {
        int result = 0;
        int currPower = 0;
        while (Math.Pow(2, currPower) <= number)
        {
            result += GetCountOfWaysToShowNumberWithPower(number, currPower);
            currPower++;
        }
        return result;
    }
        
    private static int GetCountOfWaysToShowNumberWithPower(int number, int mainPower)
    {
        if (number == 0)
        {
            return 0;
        }
        if (mainPower == 0)
        {
            return 1;
        }
        
        var count = 0;
        var numOfMainPowerNums = 1;
        
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
                    count += GetCountOfWaysToShowNumberWithPower(nextNumber, i);
                }
                numOfMainPowerNums++;
            }
        }
        return count;
    }
}