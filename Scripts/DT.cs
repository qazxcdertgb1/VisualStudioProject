using System;

namespace ScriptTest
{
	public class DTInside
	{
		public void Run()
		{
			Animal dog = new Dog();
			Animal cat = new Cat();

			dog.Eat();
			cat.Eat();

			Console.WriteLine("----------------------------");

			Cat c1 = (Cat)cat;
			c1.Catch();
		}

	}


	class Dog : Animal
	{
		public override void Eat()
		{
			Console.WriteLine("狗: 吃骨头");
		}

		public void Home()
		{
			Console.WriteLine("狗: 看家");
		}
	}

	class Cat : Animal
	{
		public override void Eat()
		{
			Console.WriteLine("猫: 吃鱼");
		}

		public void Catch()
		{
			Console.WriteLine("猫: 抓老鼠");
		}
	}

	abstract class Animal
	{
		abstract public void Eat();
	}
}


