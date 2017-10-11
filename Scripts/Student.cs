using System;


namespace ScriptTest
{
	public class Student
	{
		private int studentKG;

		private string studentName;

		/// <summary>
		/// 注册学生
		/// </summary>
		/// <param name="studentName"></param>
		/// <param name="studentKG"></param>
		public Student(string studentName,int studentKG)
		{
			this.studentKG = studentKG;
			this.studentName = studentName;
		}

		/// <summary>
		/// 比较体重是否相同，并输出体重差
		/// </summary>
		/// <param name="stu"></param>
		/// <returns></returns>
		public int Comp(Student stu)
		{
			
			return this.studentKG - stu.studentKG;
		}


		//获取名字和体重
		public string GetStudentName()
		{
			return this.studentName;
		}

		public int GetStudentKG()
		{
			return this.studentKG;
		}

	}

	public class Name
	{
		/*public static void Main(string[] args)
		{
			Student stu1 = new Student("abc",70);
			Student stu2 = new Student("xyz",1200);
			Console.WriteLine("学生 "+stu1.GetStudentName()+" 的体重为:"+stu1.GetStudentKG()+"公斤，，，\n学生 "+stu2.GetStudentName()+" 的体重为:"+stu2.GetStudentKG()+"公斤，，，");
			Console.Write(stu1.GetStudentName() + "的体重比" + stu2.GetStudentName());
			if(stu1.Comp(stu2) < 0)
			{
				Console.Write("轻");
			}
			else
			{
				Console.Write("重");
			}
			Console.Write(Math.Abs(stu1.Comp(stu2)) + "公斤，，，\n");
		}*/
	}


}
