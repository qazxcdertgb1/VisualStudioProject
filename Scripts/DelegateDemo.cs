using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Project_Script.Scripts
{
	public delegate void fdskaljfkasdljhiogp();

	class DelegateDemo
	{
		public void Run()
		{
			fdskaljfkasdljhiogp deleTest = new fdskaljfkasdljhiogp(Show);
			deleTest();
		}
		public void Show()
		{
			Console.WriteLine("...");
		}

	}

}
