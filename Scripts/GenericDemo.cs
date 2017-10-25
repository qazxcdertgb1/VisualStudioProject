using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Project_Script.Scripts
{
	class GenericDemo
	{
		public void Run()
		{
			GenericTest();


			new DM().Run();
		}

		private void GenericTest()
		{
			//List<>
			List<string> ls = new List<string>
			{
				"erqg rfeafdeasfdfd",
				"safdsagdafd",
				"sa dsaf13124d",
				"1919",
				"2121312412",
				"114514",
				" d fad",
				"adsfea",
				"das fea"
			};
			//ls.Add(123456); //Nope


			foreach (string tempStr in ls)
			{
				Console.WriteLine(tempStr);
			}

			Console.WriteLine();

			for (int i = 0; i != ls.Count; i++)
			{
				Console.WriteLine(ls[i]);
			}

			//ArrayList

			System.Collections.ArrayList arrList = new System.Collections.ArrayList();


		}
	}
	//---------------------------------------------------------------------------------------------------------------------
	struct Student
	{
		public string name;
		public int age;
		private bool sex;
		public long id;

		public Student(string name, int age, string sex, long id)
		{
			this.name = name;
			this.age = age;
			this.id = id;
			switch (sex)
			{
				case "0":
				case "woman":
				case "Woman":
				case "woMan":
				case "WoMan":
				case "WOman":
				case "WOMan":
				case "woMAN":
				case "WoMAN":
				case "WOMAN":
				case "female":
				case "Female":
				case "feMale":
				case "FeMale":
				case "FEmale":
				case "FEMale":
				case "feMALE":
				case "FeMALE":
				case "FEMALE":
					this.sex = false;
					break;
				case "1":
				case "man":
				case "Man":
				case "MAN":
				case "male":
				case "Male":
				case "MALE":
					this.sex = true;
					break;
				default:
					this.sex = false;
					break;

			}
		}

		public string Sex()
		{
			if (sex)
			{
				return "Male";
			}
			else
			{
				return "Female";
			}
		}
	}

	internal class DM
	{
		internal void Run()
		{
			long idBase = 5000000000;
			List<Student> stu = new List<Student>(10);

			for (int i = 0; i != 10; i++)
			{
				Console.WriteLine("姓名年龄性别，请: ");

				stu.Add(new Student(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), idBase + i));
			}

			Show(stu);
		}

		private void Show(List<Student> stu)
		{
			foreach (Student stuSingle in stu)
			{
				Console.WriteLine("姓名: {0}\n年龄: {1}\n性别: {2}\n学号: {3}\n", stuSingle.name, stuSingle.age, stuSingle.Sex(), stuSingle.id);
			}
		}
	}

}
