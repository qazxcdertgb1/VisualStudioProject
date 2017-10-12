using System;
using System.Text.RegularExpressions;

namespace ScriptTest.Class3_Test
{


	/// <summary>
	/// 主函数
	/// </summary>
	public class Class3_Test
	{
		public void Run()
		{
			for (; ; GC.Collect(), Console.WriteLine(), Console.WriteLine("请按任意键继续，，，"), Console.ReadKey(), Console.Clear())
			{
				Console.WriteLine("1，有十个数放入数组中，用户输入一个数值，找出这个数值在本数组中的索引，如果没有输出“-1”！（使用两种方式）");
				Console.WriteLine("2，在程序大奖赛中，有10个评委为参赛的选手打分，分数为1~100分。选手最后得分为：去掉一个最高分和一个最低分后其余8个分数的平均值。请编写一个程序实现。");
				Console.WriteLine("3，编写程序，统计4 * 5二维数组中奇数的个数和偶数的个数。");
				Console.WriteLine("4，定义一个行数和列数相等的二维数组，并执行初始化，然后计算该数组两条对角线上的元素值之和。");
				Console.WriteLine("5，一个5位数，判断它是不是回文数。即12321是回文数，个位与万位相同，十位与千位相同");
				Console.WriteLine("6，输入一行字符，分别统计出其中英文字母、空格、数字和其它字符的个数");
				Console.WriteLine("7，判断一个数组中是否有相同的数字，如果有则找出来这个元素和其所有的位置");
				Console.WriteLine("8，根据输入行数打印出杨辉三角形");
				Console.WriteLine("9，退出，，，");

				try         //处理字母输入
				{
					switch (Convert.ToByte(Console.ReadLine()))

					{
						case 1:
							Test_1 t1 = new Test_1();
							break;
						case 2:
							Test_2 t2 = new Test_2();
							break;
						case 3:
							Test_3 t3 = new Test_3();
							break;
						case 4:
							Test_4 t4 = new Test_4();
							break;
						case 5:
							Test_5 t5 = new Test_5();
							break;
						case 6:
							Test_6 t6 = new Test_6();
							break;
						case 7:
							Test_7 t7 = new Test_7();
							break;
						case 8:
							Test_8 t8 = new Test_8();
							break;
						case 9:
							Console.Clear();
							return;
						default:
							Console.WriteLine("输入的内容不符。");
							break;
					}
				}
				catch (System.FormatException)
				{
					Console.WriteLine("输入的内容不符。");
					continue;
				}
			}

		}
	}

	/// <summary>
	/// 有十个数放入数组中，用户输入一个数值，找出这个数值在本数组中的索引，如果没有输出“-1”！（使用两种方式）
	/// </summary>
	public class Test_1
	{
		public Test_1()
		{
			Console.Clear();

			int[] arrInt = {    23, 423, 123, 32, 22,
								65, 334, 12 , 89, 54 };

			Console.Write("请输入一个数字: ");
			int inside = Convert.ToInt32(Console.ReadLine());

			int i = 0;


			Console.Write("输入0使用算法0，输入1使用算法1: ");

			if (Convert.ToBoolean(Convert.ToInt32(Console.ReadLine())))
			{
				//Type 1
				foreach (int Ele in arrInt)
				{
					if (inside == Ele)
					{
						Printout(i, inside.ToString());
						return;
					}
					i++;
				}
			}
			else
			{
				//Type 0
				for (; i != arrInt.Length; i++)
				{
					if (inside == arrInt[i])
					{
						Printout(i, inside.ToString());
						return;
					}
				}
			}

			i = -1;
			Printout(i);
		}

		public void Printout(int i, string inNum = null)
		{
			//Nothing Found
			if (i == -1)
			{
				Console.WriteLine("\n-1:Null");
				return;
			}


			Console.WriteLine("\n{0}:数字\"{1}\"位于第{2}位，索引为{0}", i, inNum, i + 1);
		}
	}

	/// <summary>
	/// 在程序大奖赛中，有10个评委为参赛的选手打分，分数为1~100分。选手最后得分为：去掉一个最高分和一个最低分后其余8个分数的平均值。
	/// 请编写一个程序实现。
	/// </summary>
	public class Test_2
	{
		public Test_2()
		{
			Console.Clear();
			int[] arrInt = new int[10];

			//分数输入
			for (int i = 0; i != 10; i++)
			{
				Console.Write("第{0}位评委的分数: ", i + 1);
				int tempInt = Convert.ToInt32(Console.ReadLine());
				if (tempInt <= 0 || tempInt > 100)
				{
					Console.WriteLine("分数不符");
					i--;
					continue;
				}
				arrInt[i] = tempInt;
			}

			//去除最高最低分
			int maxScoreNum = 0;
			int minScoreNum = 0;
			int allScore = arrInt[0];

			for (int j = 1; j != arrInt.Length; j++)
			{
				//最大值
				if (arrInt[maxScoreNum] < arrInt[j])
				{
					maxScoreNum = j;
				}

				//最小值
				if (arrInt[minScoreNum] > arrInt[j])
				{
					minScoreNum = j;
				}

				allScore += arrInt[j];
			}

			//平均分
			float pingJunZhi = (float)(allScore - (arrInt[maxScoreNum] + arrInt[minScoreNum])) / 8f;

			Console.WriteLine("选手的平均分数为{0}分。", pingJunZhi);
		}
	}

	/// <summary>
	/// 编写程序，统计4 * 5二维数组中奇数的个数和偶数的个数。
	/// </summary>
	public class Test_3
	{
		public Test_3()
		{
			Console.Clear();

			int[,] arrIntD = {  { 456   , 8     , 2     , 144   , 58     },
								{ 24    , 8     , 72    , 48    , 2      },
								{ 15    , 87    , 202   , 14    , 87     },
								{ 567   , 123   , 0     , 313   , 75     } };

			int singleNum = 0, doubleNum = 0;

			//统计奇偶
			foreach (int Ela in arrIntD)
			{
				if (Ela % 2 == 1)
				{
					singleNum++;
				}
				else
				{
					doubleNum++;
				}
			}

			//输出
			Console.WriteLine("数组[4,5]内有{0}个奇数，{1}个偶数", singleNum, doubleNum);
		}
	}

	/// <summary>
	/// 定义一个行数和列数相等的二维数组，并执行初始化，然后计算该数组两条对角线上的元素值之和。
	/// </summary>
	public class Test_4
	{
		public Test_4()
		{
			Console.Clear();

			int[,] arrIntD = {  { 864   , 23    , 1231  , 18    , 8945   },
								{ 1564  , 81    , 857   , 56    , 576    },
								{ 546   , 87    , 23    , 74    , 231    },
								{ 86    , 5     , 20    , 7     , 35     },
								{ 53    , 1     , 8     , 354   , 7      } };

			int bianChang = (int)Math.Sqrt(arrIntD.Length);
			int numAdd = 0;

			//对角线相加
			for (int i = 0; i != bianChang; i++)
			{
				numAdd += (arrIntD[i, i] + arrIntD[i, bianChang - 1 - i]);
			}

			//奇数边长处理
			if (bianChang % 2 != 0)
			{
				numAdd -= arrIntD[bianChang / 2, bianChang / 2];
			}

			Console.WriteLine("二维数组[{0},{0}]的对角线元素值之和为{1}", bianChang, numAdd);
		}
	}

	/// <summary>
	/// 一个5位数，判断它是不是回文数。即12321是回文数，个位与万位相同，十位与千位相同
	/// </summary>
	public class Test_5
	{
		public Test_5()
		{
			Console.Clear();

			string strNum;

			Console.Write("输入5位数字: ");
			strNum = Console.ReadLine();

			if (strNum[0] == strNum[4] || strNum[1] == strNum[3])
			{
				Console.WriteLine("该数字是回文数。");
				return;
			}
			Console.WriteLine("该数字不是回文数。");
		}
	}

	/// <summary>
	/// 输入一行字符，分别统计出其中英文字母、空格、数字和其它字符的个数
	/// </summary>
	public class Test_6
	{
		public Test_6()
		{
			Console.Clear();

			//正则规则
			Regex reEnglish = new Regex("[a-zA-Z]");
			Regex reNumber = new Regex("[0-9]");
			Regex reSpace = new Regex(" ");

			Console.WriteLine("请输入任意字符串: ");
			string str = Console.ReadLine();

			//统计变量
			int englishNum = 0, numberNum = 0, spaceNum = 0, specialNum = 0;

			//统计字母
			for (int i = 0; i != str.Length; i++)
			{
				string tempStr = Convert.ToString(str[i]);
				if (reEnglish.IsMatch(tempStr))
				{
					englishNum++;
				}
				else if (reNumber.IsMatch(tempStr))
				{
					numberNum++;
				}
				else if (reSpace.IsMatch(tempStr))
				{
					spaceNum++;
				}
				else
				{
					specialNum++;
				}

			}

			Console.WriteLine("字符串中有{0}个英文字母，{1}个数字，{2}个空格和{3}个特殊字符。", englishNum, numberNum, spaceNum, specialNum);
		}
	}

	/// <summary>
	/// 判断一个数组中是否有相同的数字，如果有则找出来这个元素和其所有的位置
	/// </summary>
	public class Test_7
	{
		public Test_7()
		{
			Console.Clear();

			int[] arrInt = {    1, 4, 5, 3, 6,
								6, 1, 4, 9, 7 };

			int charNum = 0;

			char[,] arrCharD = new char[arrInt.Length - 1, arrInt.Length];

			//查找重复的数字并存储
			for (int i = 0; i != arrInt.Length; i++)
			{
				for (int j = i + 1; j != arrInt.Length; j++)
				{
					if (arrInt[i] == arrInt[j])
					{
						arrCharD[i, 0] = (char)arrInt[i];
						charNum++;
						arrCharD[i, charNum] = (char)j;
					}
				}
				charNum = 0;
			}


			/*//Debug Output
			foreach(char Ela in arrCharD)
			{
				Console.WriteLine((int)Ela);
			}*/

			//输出
			for (int i = 0; i != arrInt.Length - 1; i++)
			{
				if ((int)arrCharD[i, 0] != 0)
				{
					Console.Write("重复的数字{0}在{1}", (int)arrCharD[i, 0], i);
					for (int j = 1; j != arrInt.Length; j++)
					{
						if ((int)arrCharD[i, j] != 0)
						{
							Console.Write(",{0}", (int)arrCharD[i, j]);
						}
					}
					Console.WriteLine("位置。");
				}
			}
		}
	}

	/// <summary>
	/// 根据输入行数打印出杨辉三角形
	/// </summary>
	public class Test_8
	{
		public Test_8()
		{
			Console.Clear();

			Console.Write("输入行数: ");
			int tempI = Convert.ToInt32(Console.ReadLine());

			try
			{
				long[,] arrLongD = new long[tempI, tempI];
				arrLongD[0, 0] = 1;

				//计算对应位置的数值并存储
				for (int i = 1; i != tempI; i++)
				{
					arrLongD[i, 0] = 1;
					for (int j = 1; j != tempI; j++)
					{
						arrLongD[i, j] = arrLongD[i - 1, j - 1] + arrLongD[i - 1, j];
					}
				}

				//输出数值图形
				for (int i = 0; i != tempI; i++)
				{
					for (int j = 0; j != tempI; j++)
					{
						if (arrLongD[i, j] != 0)
						{
							Console.Write(arrLongD[i, j] + " ");
						}
					}
					Console.WriteLine();
				}
			}
			catch (OutOfMemoryException)
			{
				Console.WriteLine("内存溢出，行数过多，诉控");
			}
			catch (OverflowException)
			{
				Console.WriteLine("行数过多，变量溢出");
			}
		}
	}


}
