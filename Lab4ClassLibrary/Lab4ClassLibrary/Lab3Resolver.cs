namespace Lab4ClassLibrary;

public class Lab3Resolver : LabsResolver
{
    private readonly string inputFilePath;
    private readonly string outputFilePath;
    
    public Lab3Resolver(string inputFilePath, string outputFilePath)
    {
        this.inputFilePath = inputFilePath;
        this.outputFilePath = outputFilePath;
    }
    
    public void resolveLab()
    {
        var inf = Math.Pow(10, 9);
            
        var a = new List<int>();
        var b = new List<int>();
        var c = new List<int>();
        var d = new List<int>();

        List<string> lines = new List<string>();
                
        int linesCount = File.ReadAllLines(this.inputFilePath).Length;
        Console.WriteLine("Count strings = " + linesCount);

        for (int i = 0; i < linesCount; i++)
        {
            lines.Add(File.ReadAllLines(this.inputFilePath)[i]);
        }

        Console.WriteLine("\nContent of input file: \n");
        foreach (var cont in lines)
        {
            Console.WriteLine(cont + " ");
        }

        var n = Convert.ToInt32(lines[0].Split()[0]);
        var f = Convert.ToInt32(lines[0].Split()[1]);
        var m = Convert.ToInt32(lines[1]);

        if (n < 2 || n > 100 || f < 2 || f > 100 || m < 2 || m > 100)
        {
            throw new Exception("Input data doesn't match input conditions");
        }

        Console.WriteLine($"\nn = {n}, f = {f} , m = {m} ");

        lines.RemoveAt(0);
        lines.RemoveAt(0);

        for (int i = 0; i < m; i++)
        {
            var tmp = Convert.ToInt32(lines[i].Split()[0]);
                
            int dod; 
                
            if (tmp % 2 == 0)
            { 
                dod = (tmp * 2) - 2;
            }
            else
            {
                dod = (tmp * 2) - 2;
            }

            if (Convert.ToInt32(lines[i].Split()[0]) > 2)
            {
                for (int j = 1; j < dod; j += 2)
                {
                    a.Add(Convert.ToInt32(lines[i].Split()[j]));
                    b.Add(Convert.ToInt32(lines[i].Split()[j + 1]));
                    c.Add(Convert.ToInt32(lines[i].Split()[j + 2]));
                    d.Add(Convert.ToInt32(lines[i].Split()[j + 3]));
                }
            }

            if (Convert.ToInt32(lines[i].Split()[0]) == 2)
            {
                a.Add(Convert.ToInt32(lines[i].Split()[1]));
                b.Add(Convert.ToInt32(lines[i].Split()[2]));
                c.Add(Convert.ToInt32(lines[i].Split()[3]));
                d.Add(Convert.ToInt32(lines[i].Split()[4]));
            }
        }
            
        Console.Write("\na = ");
        foreach (var ca in a)
        { 
            Console.Write(ca + " ");
        }

        Console.Write("\nb = ");
        foreach (var cb in b)
        { 
            Console.Write(cb + " ");
        }

        Console.Write("\nc = ");
        foreach (var cc in c)
        {
            Console.Write(cc + " ");
        }

        Console.Write("\nd = ");
        foreach (var cd in d)
        {
            Console.Write(cd + " ");
        }

        List<double> distination = new List<double>();

        for (int i = 0; i < n; i++)
        { 
            distination.Add(inf);
        }
            
        var s = a.Count;
        distination[0] = 0; 
            
        for (int i = 0; i < n - 1; i++)
        { 
            for (int j = 0; j < s; j++)
            {
                if (distination[c[j] - 1] > d[j] && distination[a[j] - 1] != inf && b[j] >= distination[a[j] - 1])
                { 
                    distination[c[j] - 1] = d[j];
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (distination[i] == inf)
            {
                distination[i] = 0;
            }
        }

        Console.WriteLine("\n\nDistination: ");

        foreach (var dis in distination)
        {
            Console.Write(dis + " ");
        }

        for (int i = 0; i < n; i++)
        {
            if (distination[i] == 0)
            {
                distination[i] = -1;
                distination[0] = 0;
            }
        }

        Console.WriteLine("\nDistination: ");
            
        foreach (var dis in distination)
        {
            Console.Write(dis + " ");
        }

        var ans = distination[f - 1];
        Console.WriteLine("\n\nAns = " + ans);
        File.WriteAllText(this.outputFilePath, Convert.ToString(ans) + "\n");
    }
}

