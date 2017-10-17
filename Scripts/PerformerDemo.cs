using System;

namespace ScriptTest
{
	class Program
	{
		private IPerformer[] arrActor = { new Singer(), new Dancer(), new Player() };

		public void Show()
		{
			for (int i = 0; i != arrActor.Length; i++)
			{
				arrActor[i].Perform();
			}
		}
	}

	interface IPerformer
	{
		void Perform();
	}

	class Singer : IPerformer
	{
		public void Perform()
		{
			Console.WriteLine("恩，哼，哼，啊啊啊啊啊啊啊啊啊啊啊啊，啊啊啊啊啊啊啊啊啊啊啊啊");
		}
	}

	class Dancer : IPerformer
	{
		public void Perform()
		{
			Console.WriteLine("跳舞");
		}
	}

	class Player : IPerformer
	{
		public void Perform()
		{
			Console.WriteLine("演奏");
		}
	}
}
