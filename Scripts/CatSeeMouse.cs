using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Project_Script.Scripts
{
	public delegate void Viewer();

	class CatSeeMouse
	{
		public void Run()
		{
			CatLooking cat = new CatLooking();
			Man man = new Man();
			Mouse mouse = new Mouse();
			cat.CatView += man.Listen;
			cat.CatView += mouse.Escape;
			mouse.MouseView += cat.CatSeeMouse;
			mouse.Out();

		}
	}

	class CatLooking
	{
		public event Viewer CatView;

		public void CatSeeMouse()
		{
			Console.WriteLine("...(威压)");
			CatView();
		}
	}

	class Man
	{
		public void Listen()
		{
			Console.WriteLine("WTF???");
		}
	}

	class Mouse
	{
		public event Viewer MouseView;

		public void Out()
		{
			MouseView();
		}

		public void Escape()
		{
			Console.WriteLine("抖抖抖");
		}
	}
}
