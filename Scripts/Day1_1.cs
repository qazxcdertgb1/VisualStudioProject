using System;

namespace ScriptTest
{
	public class Day1_1
	{
		public void Run()
		{
			int num = Convert.ToInt32(Console.ReadLine());
			for (int i = 1; i < num; i++)
			{
				for (int j = num - i - 1; j > 0; j--)
				{

					Console.Write(" ");
				}

				for (int k = (i * 2 - 1); k > 0; k--)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}

}

