using System;


namespace ScriptTest
{
	public class Teacher
	{
		private string teacherName;
		private long teacherID;
		private string teacherJob;
		private int teacherPay;
		private static string teacherSchoolName = "第一学校";
		private static string teacherEduClassic = "数学";

		public static void Run()
		{
			Teacher t1 = new Teacher("Teacher_1", 001, "教师", 10086);
			Teacher t2 = new Teacher("Teacher_2", 002, "教师", 12580);

		}

		public Teacher(string name, long ID, string job, int pay)
		{
			teacherName = name;
			teacherID = ID;
			teacherJob = job;
			teacherPay = pay;
		}

		public string Teach()
		{
			return teacherEduClassic;
		}

		public static string Teach(string sbject)
		{
			switch (sbject)
			{
				case "教师":
					sbject = teacherEduClassic;
					break;
				default:
					break;
			}
			return sbject;
		}

	}
}
