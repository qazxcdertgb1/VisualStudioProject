using System;

namespace ScriptTest
{
	public class WolfGame
	{

		static WolfData[] wolfs = new WolfData[16];
		static LionData lion = new LionData();
		/*DateTime d1 = DateTime.Now;
		DateTime d2;*/

		public void Run()
		{
			for (;;)
			{
				Console.Clear();
				Console.Write("输入Start或S开始，输入Exit,E,Quit或q退出: ");
				string str = Console.ReadLine();
				switch (str)
				{
					case "Q":
					case "q":
					case "E":
					case "e":
					case "Quit":
					case "quit":
					case "exit":
					case "Exit":
						return;
					case "S":
					case "s":
					case "start":
					case "Start":
						Console.Clear();
						break;
					case "":
					default:
						continue;

				}




				int lionKillNum = 0;
				int wolfDeadNum = 0;

				for (int i = 0; i != wolfs.Length; i++)
				{
					wolfs[i] = new WolfData();
				}

				for (int i = 0; i != 6; i++)
				{
					wolfs[i].Spawn();
				}
				for (int i = 0; ;)
				{/*
					d2 = DateTime.Now;
					TimeSpan t1 = d2 - d1;
					d1 = d2;
					Console.WriteLine(i/t1.Milliseconds*3);*/
					i = 0;
					for (; i != 60; i++)
					{


						//Attack
						int[] tempArr = Attack();

						if (tempArr != null)
						{
							lionKillNum += tempArr[0];
							wolfDeadNum += tempArr[1];
						}

						//Score add
						if (!wolfs[0].ShowState())
						{
							UIShow(wolfs, lionKillNum, wolfDeadNum);
							Console.WriteLine("Fail");
							Console.WriteLine("请按任意键继续，，，");
							Console.ReadKey();
							Console.Clear();
							return;
						}
						//Mob respawn
						RespawnTime();
						//Show UI
						UIShow(wolfs, lionKillNum, wolfDeadNum);
						//keep fps low than 60
						i++;
						Console.WriteLine(i);
						System.Threading.Thread.Sleep(1000 / 60);
					}
				}
			}
		}

		/// <summary>
		/// 显示UI
		/// </summary>
		/// <param name="inData"></param>
		/// <param name="lionK"></param>
		/// <param name="wolfD"></param>
		public void UIShow(WolfData[] inData, int lionK, int wolfD)
		{
			Console.Clear();
			for (int i = 0; i != inData.Length; i++)
			{
				Console.WriteLine("Wolf {0}		LP: {1}		Alive: {2}", i, inData[i].ShowLP(), inData[i].ShowState());
			}
			Console.WriteLine("\n");
			Console.WriteLine("Lion Killed: {0}\nWolf Dead: {1}", lionK, wolfD);


			bool debugOutput = false;
			//Debug Output
			if (debugOutput)
			{
				Console.WriteLine(lion.ShowLP());
				Console.WriteLine(lion.ShowState());
			}
		}

		/// <summary>
		/// 重生
		/// </summary>
		public void RespawnTime()
		{
			//Lion Respawn
			if (!lion.ShowState() && new Random((int)DateTime.Now.ToFileTime()).NextDouble() < (double)(10d / 1200d))
			{
				lion.Spawn();
			}

			//Wolf Respawn
			if (!wolfs[15].ShowState() && new Random((int)DateTime.Now.ToFileTime()).NextDouble() < (double)(80d / 1000d))
			{
				for (int i = 0; i != wolfs.Length; i++)
				{
					if (!wolfs[i].ShowState())
					{
						wolfs[i].Spawn();
						break;
					}
				}
			}
		}

		/// <summary>
		/// 战斗
		/// </summary>
		/// <returns></returns>
		public int[] Attack()
		{
			//Lion alive?
			if (!lion.ShowState())
			{
				return null;
			}

			int[] deadNum = { 0, 0 };

			bool isAttack = false;

			//Oh,its alive
			for (int i = 15; i != -1; i--)
			{
				if (!wolfs[i].ShowState())
				{
					continue;
				}

				//Try escape if wolf <=8
				if (i <= 8 && !isAttack)
				{
					for (int distance = 0; distance != 10; distance++)
					{
						if (new Random((int)DateTime.Now.ToFileTime()).NextDouble() < 0.35d)
						{
							wolfs[i].ReduceLP(1000);
							i--;
							deadNum[1]++;

							//All dead
							if (i == -1)
							{
								return deadNum;
							}
						}
					}

					//Escape sucessful!
					lion.ReduceLP(8000);
					return deadNum;
				}

				isAttack = true;

				//Try attack if wolf >=9
				if (lion.ShowLP() != 0 && lion.ReduceLP(wolfs[i].ShowLP()))
				{
					deadNum[0]++;
				}
				if (wolfs[i].ReduceLP(lion.ShowLP()))
				{
					deadNum[1]++;
				}

			}
			return deadNum;

		}

	}


	abstract public class AnimalData
	{
		protected int LP;
		protected bool alive = false;

		internal int ShowLP()
		{
			return this.LP;
		}

		abstract internal void Spawn();

		internal bool ShowState()
		{
			return this.alive;
		}

		internal bool ReduceLP(int damage)
		{
			LP -= damage;
			if (LP <= 0)
			{
				LP = 0;
				alive = false;
				return true;
			}
			return false;
		}

	}


	public class WolfData : AnimalData
	{

		internal override void Spawn()
		{
			this.LP = 1000;
			this.alive = true;
		}
	}

	public class LionData : AnimalData
	{
		internal override void Spawn()
		{
			this.LP = 8000;
			this.alive = true;
		}
	}
}
