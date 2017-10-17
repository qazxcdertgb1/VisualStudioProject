using System;


namespace ScriptTest
{
	public class DuckGameInside
	{
		public void Run()
		{
			try
			{
				Console.Write("1. 红头鸭子\n2. 绿头鸭子\n3. 橡胶鸭子\n选择种类: ");

				new SearchDuck(Convert.ToSByte(Console.ReadLine()));
			}
			catch (FormatException)
			{
				Console.WriteLine("输入的值不是数字");
			}
			catch (OverflowException)
			{
				Console.WriteLine("输入的值过大");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}

	/// <summary>
	/// 查找对应的鸭子
	/// </summary>
	class SearchDuck
	{
		public SearchDuck(int type)
		{
			switch (type)
			{
				case 1:
					new RedHeadDuck().ShowSelf();
					break;
				case 2:
					new MallardDuck().ShowSelf();
					break;
				case 3:
					new RubberDuck().ShowSelf();
					break;
				default:
					throw new Exception("未知的鸭子类型");
			}
		}
	}

	/// <summary>
	/// 鸭子的共性
	/// </summary>
	abstract class Duck
	{
		protected abstract void Display();

		protected abstract void Quack();

		protected void Swim()
		{
			Console.WriteLine("游泳");
		}

		//输出自身所有属性
		public void ShowSelf()
		{
			Display();
			Quack();
			Swim();
		}
	}

	//----------------------鸭子定义--------------------------------
	class RedHeadDuck : Duck
	{
		protected override void Display()
		{
			Console.WriteLine("红头");
		}

		protected override void Quack()
		{
			Console.WriteLine("呱");
		}
	}

	class MallardDuck : Duck
	{
		protected override void Display()
		{
			Console.WriteLine("绿头");
		}

		protected override void Quack()
		{
			Console.WriteLine("呱");
		}
	}

	class RubberDuck : Duck
	{
		protected override void Display()
		{
			Console.WriteLine("橡胶");
		}

		protected override void Quack()
		{
			Console.WriteLine("吱");
		}
	}

	/*
	 *class WoodDuck
	 * {
	 *		
	 * }
	 */

	//-------------------------------鸭子定义End--------------------------------
}
