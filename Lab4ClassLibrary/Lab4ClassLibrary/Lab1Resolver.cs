namespace Lab4ClassLibrary;

public class Lab1Resolver : LabsResolver
{
    private readonly string inputFilePath;
    private readonly string outputFilePath;
    
    public Lab1Resolver(string inputFilePath, string outputFilePath)
    {
        this.inputFilePath = inputFilePath;
        this.outputFilePath = outputFilePath;
    }
    
    public void resolveLab()
    {
        FileInfo outputFileInfo = new FileInfo(this.outputFilePath);

        var analyzer = new DnaAnalyzer(this.inputFilePath);
        var analysisResult = analyzer.Analyze();

        if(analysisResult is true)
        {
            Console.WriteLine("I did return 'YES'");

            using (StreamWriter sw = outputFileInfo.CreateText())
            {
                sw.WriteLine("YES");
            }
        }
        else
        {
            Console.WriteLine("I did return 'NO'");

            using (StreamWriter sw = outputFileInfo.CreateText())
            {
                sw.WriteLine("NO");
            }
        }
    }
    
    public class DnaAnalyzer
    {
        public DnaAnalyzer(string inputFilePath)
        {
            this._inputFilePath = inputFilePath;
            this._inputFileInfo = new FileInfo(inputFilePath);
        }

        private readonly string _inputFilePath;
        private readonly FileInfo _inputFileInfo;

        public bool Analyze()
        {
            var inputFileLength = _inputFileInfo.Length;

            if (inputFileLength > 262144 || inputFileLength == 0) return false;

            if(File.ReadLines(_inputFilePath).FirstOrDefault() is null) return false;
            if(File.ReadLines(_inputFilePath).Skip(1).FirstOrDefault() is null) return false;

            var parentDNA = File.ReadLines(_inputFilePath).First();
            var childDNA = File.ReadLines(_inputFilePath).Skip(1).First();
				
            Console.WriteLine(parentDNA + " " + childDNA);

            var childCouldEvolve = CheckHeritability(parentDNA, childDNA);

            return childCouldEvolve;
        }

        private bool CheckHeritability(string parentDnaChain, string childDnaChain)
        {
            var lastDnaIndex = -1;

            foreach (var parentDNA in parentDnaChain)
            {
                if (childDnaChain.Contains(parentDNA))
                {
                    lastDnaIndex = childDnaChain.IndexOf(parentDNA);
                    childDnaChain = childDnaChain.Remove(0, lastDnaIndex + 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
