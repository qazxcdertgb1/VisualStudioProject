using System;

namespace ScriptTest
{
	class Day14_1_Main
	{
		public void Run()
		{

			for (; ; Console.WriteLine("\n请按任意键继续，，，"), Console.ReadKey(), Console.Clear())
			{
				Console.Write("1. 雇员示例\n2. 老师示例\n3. 学员示例\n4. 生物示例\n5. 几何示例\n6. 退出\n输入数字: ");
				try
				{
					byte byt = Convert.ToByte(Console.ReadLine());
					Console.Clear();

					switch (byt)
					{
						case 1:
							new EmployeeTest().Start();
							break;
						case 2:
							new TeacherTest().Start();
							break;
						case 3:
							new StudentTest().Start();
							break;
						case 4:
							new AnimalTest().Start();
							break;
						case 5:
							new ShapeTest().Start();
							break;
						case 6:
							return;
						default:
							break;
					}
				}
				catch (System.FormatException)
				{
					continue;
				}
			}
		}
	}


	//-----------------------------------------------------------------雇员示例-------------------------------------------------------------------
	class EmployeeTest
	{
		public void Start()
		{
			new Programer("此处应有程序员", 110108123456780000, 5000).Speak();
			Console.WriteLine();
			new Manager("此处不应有经理(喵喵喵???)", 110108876543219999, 50000, 1).Speak();
		}
	}

	abstract class Worker
	{
		private string name;
		private long ID;
		private int payNum;

		protected Worker(string name, long ID, int payNum)
		{
			this.name = name;
			this.ID = ID;
			this.payNum = payNum;
		}

		abstract protected void Work();

		public virtual void Speak()
		{
			Console.WriteLine("姓名: {0}\nID: {1}\n工资: {2}", name, ID, payNum);
			Console.Write("工作内容: ");
			Work();
		}
	}

	class Programer : Worker
	{
		public Programer(string name, long ID, int payNum) : base(name, ID, payNum) { }

		protected override void Work()
		{
			Console.WriteLine("Working,working...Zzzzzzzz...");
		}
	}

	class Manager : Worker
	{
		private int bonus;

		public Manager(string name, long ID, int payNum, int bonus) : base(name, ID, payNum)
		{
			this.bonus = bonus;
		}

		protected override void Work()
		{
			Console.WriteLine("Get the FUCK UP!");
		}

		public override void Speak()
		{
			base.Speak();
			Console.WriteLine("奖金: {0}", bonus);
		}
	}
	//--------------------------------------------------------------------------------------------------------------------------------------------

	//-----------------------------------------------------------------老师示例-------------------------------------------------------------------
	class TeacherTest
	{
		public void Start()
		{
			new CSharpTeacher("C#教师", "教室10086", "C#").Speak();
			Console.WriteLine();
			new UnityTeacher("Unity教师", "教室10011", "Unity").Speak();
		}
	}

	abstract class Teachers
	{
		private string name;
		private string classroom;
		private string techClass;

		protected Teachers(string name, string classroom, string techClass)
		{
			this.name = name;
			this.classroom = classroom;
			this.techClass = techClass;
		}

		public void Speak()
		{
			Console.WriteLine("姓名: {0}\n所属班级: {1}\n所讲课程: {2}", name, classroom, techClass);
			TechClass();
		}

		abstract protected void TechClass();
	}

	class CSharpTeacher : Teachers
	{
		public CSharpTeacher(string name, string classroom, string techClass) : base(name, classroom, techClass) { }

		protected override void TechClass()
		{
			Console.WriteLine("Teaching C#...");
		}
	}

	class UnityTeacher : Teachers
	{
		public UnityTeacher(string name, string classroom, string techClass) : base(name, classroom, techClass) { }

		protected override void TechClass()
		{
			Console.WriteLine("Teaching Unity...");
		}
	}
	//--------------------------------------------------------------------------------------------------------------------------------------------

	//-----------------------------------------------------------------学员示例-------------------------------------------------------------------
	class StudentTest
	{
		public void Start()
		{
			Students basicStu = new BasicStudent("基础学员", "Basic");
			Students advStu = new AdvanceStudent("大脑升级学员", "Advance");

			basicStu.Speak();
			basicStu.Study();
			basicStu.Free();
			Console.WriteLine();
			advStu.Speak();
			advStu.Study();
			advStu.Free();
		}
	}

	abstract class Students
	{
		private string name;
		private string studyClass;

		protected Students(string name, string studyClass)
		{
			this.name = name;
			this.studyClass = studyClass;
		}

		public void Speak()
		{
			Console.WriteLine("姓名: {0}\n学习内容: {1}", name, studyClass);
		}

		abstract public void Study();

		public void Free()
		{
			Console.WriteLine("We are free,WE ARE FREE!!!($0)");
		}
	}

	class BasicStudent : Students
	{
		public BasicStudent(string name, string studyClass) : base(name, studyClass) { }

		public override void Study()
		{
			Console.WriteLine("Basic+1+1+1");
		}
	}

	class AdvanceStudent : Students
	{
		public AdvanceStudent(string name, string studyClass) : base(name, studyClass) { }

		public override void Study()
		{
			Console.WriteLine("Advance+1+1+1");
		}
	}
	//--------------------------------------------------------------------------------------------------------------------------------------------

	//-----------------------------------------------------------------生物示例-------------------------------------------------------------------
	class AnimalTest
	{
		public void Start()
		{
			new Bird().WhatAmIDo();
			Console.WriteLine();
			new Person_1().WhatAmIDo();
			Console.WriteLine();
			new Fish().WhatAmIDo();
		}
	}

	abstract class FlyAble
	{
		abstract protected void Fly();
		public void WhatAmIDo()
		{
			Fly();
		}
	}

	abstract class TalkAble
	{
		abstract protected void Talk();
		public void WhatAmIDo()
		{
			Talk();
		}
	}

	abstract class SwimAble
	{
		abstract protected void Swim();
		public void WhatAmIDo()
		{
			Swim();
		}
	}

	class Bird : FlyAble
	{
		protected override void Fly()
		{
			Console.WriteLine("Crashland,Please");
		}
	}

	class Person_1 : TalkAble
	{
		protected override void Talk()
		{
			Console.WriteLine("Fuck You");
		}
	}

	class Fish : SwimAble
	{
		protected override void Swim()
		{
			Console.WriteLine("要溺死了!要溺死了!");
		}
	}
	//--------------------------------------------------------------------------------------------------------------------------------------------

	//-----------------------------------------------------------------几何示例-------------------------------------------------------------------
	class ShapeTest
	{
		public void Start()
		{
			new Triangle().Output(5, 10);
			Console.WriteLine();
			new Rect_1().Output(3, 4);
			Console.WriteLine();
			new Circle_1().Output(10);
		}
	}

	abstract class Shape
	{
		abstract protected double getArea(int a, int b);

		public void Output(int a, int b)
		{
			Console.WriteLine(getArea(a, b));
		}
	}

	class Triangle : Shape
	{
		protected override double getArea(int a, int b)
		{
			return (a * b) / 2;
		}
	}

	class Rect_1 : Shape
	{
		protected override double getArea(int a, int b)
		{
			return a * b;
		}
	}

	class Circle_1 : Shape
	{
		protected override double getArea(int a, int b = -1)
		{
			return Math.PI * a * a;
		}

		public new void Output(int a, int b = -1)
		{
			base.Output(a, b);
		}
	}
}
