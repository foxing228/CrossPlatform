namespace Lab5ClassLibrary;

public class Lab1Resolver
{

    // public bool resolveLab()
    // {
    //
    //     var analyzer = new DnaAnalyzer(string DnaOne, string DnaTwo);
    //     var analysisResult = analyzer.Analyze();
    //
    //     return analysisResult;
    // }
    
    public class DnaAnalyzer
    {
        public DnaAnalyzer(string DnaOne, string DnaTwo)
        {
            this.DnaOne = DnaOne;
            this.DnaTwo = DnaTwo ;
        }

        private readonly string DnaOne;
        private readonly string DnaTwo;

        public bool Analyze()
        {
            var inputLength = DnaOne.Length * sizeof(Char) + DnaTwo.Length * sizeof(Char);
            

            if (inputLength > 262144 || inputLength == 0) throw new ArgumentException("dnas length is 0");

            var parentDNA = DnaOne;
            var childDNA = DnaTwo;
				
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
