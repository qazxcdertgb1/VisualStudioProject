using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Project_Script.Scripts
{
	public delegate void dkslafjdioaf(string param);

	class Counter_Strike
	{
		public void Run()
		{
			new Center().Start();
		}
	}

	class TeamA
	{
		public void Attack(string code)
		{
			if (code == "df" || code == "gyk")
				Console.WriteLine("Team A report, Mission Complete.");
		}
	}

	class TeamB
	{
		public void Attack(string code)
		{
			if (code == "xm" || code == "gyk")
				Console.WriteLine("Team B report, Mission Complete.");
		}
	}

	class Center
	{
		public event dkslafjdioaf SendSignal;

		public void Start()
		{
			TeamA a = new TeamA();
			TeamB b = new TeamB();
			SendSignal += a.Attack;
			SendSignal += b.Attack;
			Sendmsg("gyk");
		}

		public void Sendmsg(string code)
		{
			SendSignal(code);
		}
	}
}
