using System;

namespace ScriptTest
{
	class InterfaceDemoInside
	{
		public void Start()
		{
			new Chinese("中国人", 20).PerformEat();
			new American("美国人", 20).PerformEat();
		}
	}

	interface EatBehavior
	{
		void Eat();
	}

	class ChineseMeal : EatBehavior
	{
		public void Eat()
		{
			Console.WriteLine("中餐");
		}
	}

	class WesternStyleFood : EatBehavior
	{
		public void Eat()
		{
			Console.WriteLine("西餐");
		}
	}

	abstract class Person_InterfaceDemo
	{
		protected string name;
		protected int age;

		protected Person_InterfaceDemo(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		abstract public void PerformEat();
	}

	class Chinese : Person_InterfaceDemo
	{
		public Chinese(string name, int age) : base(name, age) { }

		public override void PerformEat()
		{
			Console.Write("我{0}要吃", name);
			new ChineseMeal().Eat();
		}
	}

	class American : Person_InterfaceDemo
	{
		public American(string name, int age) : base(name, age) { }

		public override void PerformEat()
		{
			Console.Write("我{0}要吃", name);
			new WesternStyleFood().Eat();
		}
	}
}
