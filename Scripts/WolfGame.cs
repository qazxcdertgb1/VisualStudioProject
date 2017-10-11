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
			//游戏主循环
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
				int programRunTimeSec = 0;
				int length = wolfs.Length + 4;

				//初始化狼群
				for (int i = 0; i != wolfs.Length; i++)
				{
					wolfs[i] = new WolfData();
				}

				//狼群数量
				for (int i = 0; i != 6; i++)
				{
					wolfs[i].Spawn();
				}

				//用于计算帧数的循环(未实现)
				for (int i = 0; ;)
				{
					//用于计算帧数(BUG)

					/*d2 = DateTime.Now;
					TimeSpan t1 = d2 - d1;
					d1 = d2;
					Console.WriteLine(i/t1.Milliseconds*3);*/

					i = 0;

					//游戏内容循环
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
							Fail(length, lionKillNum, wolfDeadNum, programRunTimeSec);
							System.Threading.Thread.Sleep(2000);
							Console.WriteLine("Lions killed: {0}\nWolfs dead: {1}\nRun time: {2} Seconds", lionKillNum, wolfDeadNum, programRunTimeSec);
							return;
						}
						//Mob respawn
						RespawnTime();
						//Show UI
						UIShow(false, length, wolfs, lionKillNum, wolfDeadNum, programRunTimeSec);

						//keep fps low than 60
						i++;
						Console.WriteLine(i);
						System.Threading.Thread.Sleep(1000 / 30);
					}

					programRunTimeSec++;
				}
			}
		}

		/// <summary>
		/// 显示游戏内容UI
		/// </summary>
		/// <param name="inData"></param>
		/// <param name="lionK"></param>
		/// <param name="wolfD"></param>
		public void UIShow(bool noClear, int length, WolfData[] inData, int lionK, int wolfD, int runTime)
		{
			if (!noClear)
			{
				Console.Clear();
			}

			for (int i = 0; i != (length < inData.Length ? length : inData.Length); i++)
			{
				Console.WriteLine("Wolf {0}		LP: {1}		Alive: {2}", i + 1, inData[i].ShowLP(), inData[i].ShowState());
			}

			if (length - inData.Length >= 1)
			{
				Console.WriteLine("\n");
			}

			if (length - inData.Length >= 2)
			{
				Console.WriteLine("Lion killed: {0}", lionK);
			}

			if (length - inData.Length >= 3)
			{
				Console.WriteLine("Wolf dead: {0}", wolfD);
			}

			if (length - inData.Length >= 4)
			{
				Console.WriteLine("Run time: {0} Seconds", runTime);
			}


			bool debugOutput = false;
			//Debug Output
			if (debugOutput)
			{
				Console.WriteLine(lion.ShowLP());
				Console.WriteLine(lion.ShowState());
			}
		}

		/// <summary>
		/// 游戏失败UI特效处理
		/// </summary>
		public void Fail(int length, int lionKillNum, int wolfDeadNum, int runTime)
		{
			int high = length - 3;

			string[] gameOver = {
								"\n",
								"\n",
								"	  #######           #            ##   ##       ###########\n",
								"	 #       #         # #           ##   ##       #          \n",
								"	#         #       #   #         #  # #  #      #          \n",
								"	#                #######        #  # #  #      #########  \n",
								"	#      ####     #       #       #  # #  #      #          \n",
								"	#         #    #         #     #    #    #     #          \n",
								"	 #       #     #         #     #    #    #     #          \n",
								"	  #######      #         #     #    #    #     ###########\n",
								"\n",
								"	   #####       #         #     ###########     #########  \n",
								"	  #     #      #         #     #               #        # \n",
								"	 #       #     #         #     #               #         #\n",
								"	#         #     #       #      #########       ########## \n",
								"	#         #      #     #       #               #      #   \n",
								"	 #       #        #   #        #               #       #  \n",
								"	  #     #          # #         #               #        # \n",
								"	   #####            #          ###########     #         #\n",
								"\n"
								};

			int tempLength = gameOver.Length;

			for (; length != -1; length--)
			{
				Console.Clear();

				tempLength--;
				for (int i = tempLength + 1; i != gameOver.Length; i++)
				{
					Console.Write(gameOver[i]);
				}
				UIShow(true, length, wolfs, lionKillNum, wolfDeadNum, runTime);
				System.Threading.Thread.Sleep(200);
				//Console.WriteLine("Fail");

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
