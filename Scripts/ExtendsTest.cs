using System;


namespace ScriptTest
{
	class ExtendsTest
	{
		public void Run()
		{
			ChildClass cc = new ChildClass("Y", 24);

			Console.WriteLine("-----------Speak-----------");
			cc.Speak();
			Console.WriteLine("-----------Study-----------");
			cc.Study();
			Console.WriteLine("----------EatFood----------");
			cc.EatFood();
			Console.WriteLine();
		}
	}

	class FatherClass
	{
		private string name;

		private int age;

		public FatherClass(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public void Speak()
		{
			Console.WriteLine("{0},24 years old.", name, age);
			Console.WriteLine("Balabala，，，");
		}

		public void EatFood()
		{
			Console.WriteLine("Emm, OC!");
		}
	}

	class ChildClass : FatherClass
	{
		public ChildClass(string name, int age) : base(name, age) { }

		public void Study()
		{
			Console.WriteLine("Zzzzzz...");
		}
	}
}
