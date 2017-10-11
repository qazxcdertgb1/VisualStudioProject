using System;

namespace ScriptTest
{

	public class Person
	{
		private int age;

		public Person()
		{

		}

		public Person(int age)
		{
			this.age = age;
		}

		public bool comp(Person p)
		{
			return p.age == this.age;
		}

	}

	public class DemoScript
	{
		/*public static void Main(string[] args)
		{
			Person p1 = new Person(20);
			Person p2 = new Person(30);
			Console.WriteLine(p1.comp(p2));
			
		}*/

	}
}
