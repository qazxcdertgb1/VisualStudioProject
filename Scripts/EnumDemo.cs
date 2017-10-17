using System;

namespace ScriptTest
{
	class EnumDemoInside
	{
		enum WeekDay
		{
			Monday,Tuesday,Sunday
		}

		public void Run()
		{
			WeekDay wed;
			for(wed = WeekDay.Monday; (int)wed !=(int)WeekDay.Sunday+1;wed++)
			{
				Console.WriteLine("{0}\n{1}",(int)wed,wed);
			}
		}
	}
}
