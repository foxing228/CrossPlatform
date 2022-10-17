namespace Lab1
{
	public class Program
	{
		public static string InputFilePath = @"Input.txt";
		public static string OutputFilePath = @"Output.txt";

		static void Main(string[] args)
		{
			FileInfo outputFileInfo = new FileInfo(OutputFilePath);

			var analyzer = new DNAnalyzer();
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

		public class DNAnalyzer
		{
			FileInfo inputFileInfo = new FileInfo(InputFilePath);

			public bool Analyze()
			{
				var inputFilelength = inputFileInfo.Length;

				if (inputFilelength > 262144 || inputFilelength == 0) return false;

				if(File.ReadLines(InputFilePath).FirstOrDefault() is null) return false;
				if(File.ReadLines(InputFilePath).Skip(1).FirstOrDefault() is null) return false;

				var parentDNA = File.ReadLines(InputFilePath).First();
				var childDNA = File.ReadLines(InputFilePath).Skip(1).First();
				
				Console.WriteLine(parentDNA + " " + childDNA);

				var childCouldEvolve = CheckHeritability(parentDNA, childDNA);

				return childCouldEvolve;
			}

			private bool CheckHeritability(string parentDNAChain, string childDNAChain)
			{
				var lastDNAIndex = -1;

				foreach (var parentDNA in parentDNAChain)
				{
					if (childDNAChain.Contains(parentDNA))
					{
						lastDNAIndex = childDNAChain.IndexOf(parentDNA);
						childDNAChain = childDNAChain.Remove(0, lastDNAIndex + 1);
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
}