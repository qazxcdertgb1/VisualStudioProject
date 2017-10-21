using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Project_Script.Scripts
{
	struct Person
	{
		private string name;
		private int age;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Age
		{
			get { return age; }
			set
			{
				if(value <0)
				{
					age = 0;
				}
				else
				{
					age = value;
				}
			}
		}

		public Person(string name,int age)
		{
			this.name = name;
			this.age = age;
		}

		public void Speak()
		{
			Console.WriteLine("\nThis is a sub named Speak.\nName: {0}\nAge: {1}\n", name, age);
		}
	}

	struct Cat
	{
		private string name;
		private int age;
		//false(0) = woman, true(1) = man;
		private bool sex;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Age
		{
			get { return age; }
			set
			{
				if(age < 0)
				{
					age = 0;
				}
				else
				{
					age = value;
				}
			}
		}

		public bool Sex
		{
			get { return sex; }
			set
			{
				sex = Convert.ToBoolean(value);
			}
		}

	}

	class StructDemo
	{
		public void Run()
		{
			Person p = new Person("UDK", 0);

			Console.WriteLine(p.Name);
			Console.WriteLine(p.Age);

			p.Speak();

			p.Age = 24;
			p.Name = "YJNSP";

			p.Speak();
		}
	}

	class StructDemo_Cat
	{
		public void Run()
		{
			Cat c = new Cat();
			c.Age = 20;
			c.Name = "...";
			c.Sex = true;

			Console.WriteLine("Name: {0}\nAge: (1}\nSex: {2}", c.Name, c.Age, c.Sex);
		}
	}
}
