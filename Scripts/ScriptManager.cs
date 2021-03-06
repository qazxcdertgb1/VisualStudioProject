﻿using System;
using Test_Project_Script.Scripts;

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
								"14. InterfaceDemo.cs",
								"15. DT.cs",
								"16. PerformerDemo.cs",
								"17. MediaPlayerDemo.cs",
								"18. DuckGameDemo.cs",
								"19. EnumDemo.cs",
								"20. MusicTest.cs",
								"21. QuickSort.cs",
								"22. StructDemo.cs--Person",
								"23. StructDemo.cs--Cat",
								"24. ArrayListDemo.cs",
								"25. HashDemo.cs",
								"26. GenericDemo.cs",
								"27. DelegateDemo.cs",
								"28. CatSeeMouse.cs",
								"29. Counter_Strike.cs",
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
						case 14:
							new InterfaceDemoInside().Start();
							break;
						case 15:
							new DTInside().Run();
							break;
						case 16:
							new Program().Show();
							break;
						case 17:
							new Controller().Select();
							break;
						case 18:
							new DuckGameInside().Run();
							break;
						case 19:
							new EnumDemoInside().Run();
							break;
						case 20:
							new MusicTest.MusicTest().MusicTestInside();
							break;
						case 21:
							test.QuickSort.Run(); //static Run();
							break;
						case 22:
							new StructDemo().Run();
							break;
						case 23:
							new StructDemo_Cat().Run();
							break;
						case 24:
							new ArrayListDemo().Run();
							break;
						case 25:
							new HashDemo().Run();
							break;
						case 26:
							new GenericDemo().Run();
							break;
						case 27:
							new DelegateDemo().Run();
							break;
						case 28:
							new CatSeeMouse().Run();
							break;
						case 29:
							new Counter_Strike().Run();
							break;
						case 100:
							return;
						default:
							throw new OverflowException();
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("输入类型不符");
					continue;
				}
				catch (OverflowException)
				{
					Console.WriteLine("序号不符");
					continue;
				}
				finally { }
			}
		}
	}
}
