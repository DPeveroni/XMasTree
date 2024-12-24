using System;
using System.Threading;

namespace XMasTree
{
	class Program
	{
		private const string STANDARD_LEAF = "*";
		private const string STANDAR_DBAUBLE = "o";
		private const string SUPER_BAUBLE = "$";
		private const string TRUNK_CHAR= "|";
		private const string NOTHING = " ";

		private const string OH = "OH!";


		static void Main(string[] args)
		{
			var treeHeight = 25;

			AddLaughs(treeHeight);

			PrintXMasTree(treeHeight);

			Console.ReadLine();
		}

		private static void AddLaughs(int treeHeight)
		{
			var numberOfLaugh = treeHeight / 4;
			for (int l = 0; l < numberOfLaugh; l++)
				AddLaugh();
		}

		private static void PrintXMasTree(int height)
		{
			var width = height * 2;
			AddTree(height, width);
			AddTrunk(width);
		}

		private static void AddTree(int height, int width)
		{
			for (int i = 0; i < height; i++)
			{
				int treeRowBeginning = (width / 2) - i;
				int treeRowEnd = width - treeRowBeginning;
				var previousIsABauble = false;
				for (int k = 1; k <= width; k++)
				{
					var baubleAdded = false;
					if (k > treeRowBeginning && k < treeRowEnd)
						baubleAdded = TryAddBauble(previousIsABauble);					
					else
						AddEmpty();
					previousIsABauble = baubleAdded;
				}
				Console.WriteLine();
			}
		}

		private static bool TryAddBauble(bool previusIsABauble)
		{
			var currentIsBauble = false;
			var rand = new Random(DateTime.Now.Millisecond);
			var nextRand = rand.NextDouble();
			if (!previusIsABauble
			&& nextRand >= 0.75)
			{
				if (nextRand >= 0.9)
					AddSuperBauble();
				else
					AddBauble();
					currentIsBauble = true;
			}
			else
				RelaxedPrint(STANDARD_LEAF);
			return currentIsBauble;
		}

		private static void AddTrunk(int treeWidth)
		{
			int trunkheight = GetTrunkHeight(treeWidth);
			for (int h = 0; h < trunkheight; h++)
				AddTrunkRow(treeWidth);
		}

		private static int GetTrunkHeight(int treeWidth)
		{
			int trunkheight = treeWidth / 10;
			if (trunkheight == 0)
				trunkheight++;
			else if (trunkheight > 2)
				trunkheight--;
			return trunkheight;
		}

		private static void AddTrunkRow(int treeWidth)
		{
			int trunkWidth = GetTrunkWith(treeWidth);

			int begin = (treeWidth - (trunkWidth + 2)) / 2;
			int end = treeWidth - begin;
			var trunkAdded = false;
			for (int k = 1; k <= treeWidth; k++)
			{
				if (k > begin && k < end)
				{
					if (!trunkAdded)
					{
						AddTrunkToRow(treeWidth); 
						trunkAdded = true;
					}
				}
				else
					AddEmpty();
			}
			Console.WriteLine();
		}

		private static void AddTrunkToRow(int width)
		{
			int trunkWidth = GetTrunkWith(width);
			AddTrunkChar();
			for (int t = 0; t < trunkWidth; t++)
				AddEmpty();
			AddTrunkChar();
		}

		private static int GetTrunkWith(int width) => width / 10;

		private static void AddEmpty() => RelaxedPrint(NOTHING);

		private static void AddTrunkChar() => RelaxedPrint(TRUNK_CHAR);

		private static void AddBauble() => RelaxedPrint(STANDAR_DBAUBLE);

		private static void AddSuperBauble() => RelaxedPrint(SUPER_BAUBLE);

		private static void AddLaugh() => RelaxedPrint(string.Concat(NOTHING, OH, NOTHING));

		private static void RelaxedPrint(string msg)
		{
			Thread.Sleep(10);
			Console.Write(msg);
		}
	}
}
