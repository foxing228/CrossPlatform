namespace Lab4ClassLibrary;

public class Lab2Resolver : LabsResolver
{
    private readonly string inputFilePath;
    private readonly string outputFilePath;
    
    public Lab2Resolver(string inputFilePath, string outputFilePath)
    {
        this.inputFilePath = inputFilePath;
        this.outputFilePath = outputFilePath;
    }
     
    public void resolveLab()
    {
        FileInfo outputFileInfo = new FileInfo(this.outputFilePath);
        var number = Convert.ToInt32(File.ReadLines(this.inputFilePath).First().Trim());
            
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

    private static int GetCountOfWaysToShowNumber(int number)
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
