using System;


namespace ScriptTest
{
	public class DuckGameInside
	{
		public void Run()
		{
			try
			{
				Console.Write("1. 红头鸭子\n2. 绿头鸭子\n3. 橡胶鸭子\n4. 木头鸭子\n选择种类: ");

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
			Console.WriteLine();

			switch (type)
			{
				case 1:
					new RedHeadDuck(new QuackGa(),new FlyWithWind()).ShowSelf();
					break;
				case 2:
					new MallardDuck(new QuackZhi(),new FlyWithWind()).ShowSelf();
					break;
				case 3:
					new RubberDuck(new QuackNull(),new FlyWithNull()).ShowSelf();
					break;
				case 4:
					new WoodDuck(new QuackNull(), new FlyWithRocket()).ShowSelf();
					break;
				default:
					throw new Exception("未知的鸭子类型");
			}

			Console.WriteLine();
		}
	}

	/// <summary>
	/// 鸭子的共性
	/// </summary>
	abstract class Duck
	{
		protected abstract void Display();

		protected IQuack quackType;
		protected IFly flyType;

		protected Duck(IQuack quackType,IFly flyType)
		{
			this.quackType = quackType;
			this.flyType = flyType;
		}

		protected void Swim()
		{
			Console.WriteLine("游泳");
		}

		//输出自身所有属性
		public void ShowSelf()
		{
			Display();
			Swim();
			quackType.Quack();
			flyType.Fly();
		}
	}
	//-------------------------叫-----------------------------------
	interface IQuack
	{
		void Quack();
	}

	class QuackZhi : IQuack
	{
		public void Quack()
		{
			Console.WriteLine("吱吱");
		}
	}

	class QuackGa : IQuack
	{
		public void Quack()
		{
			Console.WriteLine("嘎嘎");
		}
	}

	class QuackNull : IQuack
	{
		public void Quack()
		{
			Console.WriteLine("....");
		}
	}
	//-------------------------飞-----------------------------------
	interface IFly
	{
		void Fly();
	}

	class FlyWithWind : IFly
	{
		public void Fly()
		{
			Console.WriteLine("翅膀");
		}
	}

	class FlyWithRocket : IFly
	{
		public void Fly()
		{
			Console.WriteLine("火箭");
		}
	}

	class FlyWithNull : IFly
	{
		public void Fly()
		{
			Console.WriteLine("Drop");
		}
	}
	//----------------------鸭子定义--------------------------------
	class RedHeadDuck : Duck
	{
		public RedHeadDuck(IQuack quackType,IFly flyType) : base(quackType, flyType) { }

		protected override void Display()
		{
			Console.WriteLine("红头");
		}
	}

	class MallardDuck : Duck
	{
		public MallardDuck(IQuack quackType, IFly flyType) : base(quackType, flyType) { }

		protected override void Display()
		{
			Console.WriteLine("绿头");
		}
	}

	class RubberDuck : Duck
	{
		public RubberDuck(IQuack quackType, IFly flyType) : base(quackType, flyType) { }

		protected override void Display()
		{
			Console.WriteLine("橡胶");
		}
	}

	 class WoodDuck:Duck
	 {
		public WoodDuck(IQuack quackType, IFly flyType) : base(quackType, flyType) { }

		protected override void Display()
		{
			Console.WriteLine("木头");
		}
	}
	 
	//-------------------------------鸭子定义End--------------------------------
}
