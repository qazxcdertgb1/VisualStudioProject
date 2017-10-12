﻿using System;

namespace ScriptTest
{
	public class ScriptManager
	{
		public static void Main(string[] args)
		{
			for (; ; Console.WriteLine("请按任意键继续，，，"), Console.ReadKey(), GC.Collect(), Console.Clear())
			{
				string[] str = {
								"1. Person.cs",
								"2. Student.cs",
								"3. Day1_1.cs",
								"4. Day10_1.cs",
								"5. Class3_Test.cs",
								"6. Teacher.cs",
								"7. WolfGame.cs",
								"8. Single.cs --- Nope",
								"9. Inherit.cs",
								"10. ExtendsTest.cs",
								"11. Day14_1.cs",
								"12. Day14_2.cs",
								"13. Calculator.cs",
								"\n100. 退出\n"
								};

				for (int i = 0; i != str.Length; i++)
				{
					Console.WriteLine(str[i]);
				}

				Console.Write("输入数字: ");
				try
				{
					byte byt = Convert.ToByte(Console.ReadLine());
					Console.Clear();

					switch (byt)
					{
						case 1:
							new DemoScriptClass().Run();
							break;
						case 2:
							new NameClass().Run();
							break;
						case 3:
							new Day1_1().Run();
							break;
						case 4:
							new Day10_1().Run();
							break;
						case 5:
							new Class3_Test.Class3_Test().Run();
							break;
						case 6:
							Teacher.Run();  //Static Run();
							break;
						case 7:
							new WolfGame().Run();
							break;
						case 8:
							Console.WriteLine("Nope");
							break;
						case 9:
							Inherit.Run();  //Static Run();
							break;
						case 10:
							new ExtendsTest().Run();
							break;
						case 11:
							new Day14_1_Main().Run();
							break;
						case 12:
							new RunClass().Run();
							break;
						case 13:
							new CalculatorInside().Start();
							break;
						case 100:
							return;
						default:
							break;
					}
				}
				catch (System.FormatException)
				{

					continue;
				}
			}
		}
	}
}
