using System;

namespace ScriptTest
{

	public class Inherit
	{
		public static void Run()
		{
			Console.Clear();

			Child1 c1 = new Child1("C1",20);
			Child2 c2 = new Child2();

			c1.Output();
			c2.Output();

			c1.Child_1_Special();
			c2.Child_2_Special();

			Exit(c1, c2);
			
		}

		private static void Exit(Child1 c1,Child2 c2)
		{
			c1 = null;
			c2 = null;
		}
	}

	internal class Father
	{

		protected string name;

		protected int age;

		internal Father(string name,int age)
		{
			this.name = name;
			this.age = age;
		}

		internal void Output()
		{
			Console.WriteLine("{0}, {1}",this.name,this.age);
		}
	}

	internal class Child1 : Father
	{
		internal Child1(string name = "null", int age = -1) : base(name, age) { }
			
		internal void Child_1_Special()
		{
			Console.WriteLine("C1Sp");
		}
	}

	internal class Child2 : Father
	{
		internal Child2(string name = "null", int age = -1) : base(name, age) { }

		internal void Child_2_Special()
		{
			Console.WriteLine("C2Sp");
		}
	}
}
