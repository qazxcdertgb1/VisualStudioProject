using System;
using System.Threading;

namespace ScriptTest
{
	class Controller
	{ 
		public void Select()
		{
			for (; ;Console.WriteLine("\n请按任意键继续，，，"),Console.ReadKey(), Console.Clear())
			{
				try
				{
					Console.Write(
									"选择设备:\n" +
									"1. TapePlayer\n" +
									"2. DVDPlayer\n" +
									"3. CDPlayer\n" +
									"4. 退出"
									);

					switch (Convert.ToByte(Console.ReadLine()))
					{
						case 1:
							TapePlayerControl();
							break;
						case 2:
							DVDPlayerControl();
							break;
						case 3:
							CDPlayerControl();
							break;
						case 4:
							return;
						default:
							throw new Exception("未知的设备类型");
					}
				}
				catch(FormatException)
				{
					Console.WriteLine("输入错误: 输入的不是数字");
				}
				catch(OverflowException)
				{
					Console.WriteLine("输入错误: 输入的数字过大");
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex);
				}
			}

		}

		private void TapePlayerControl()
		{
			Console.Clear();

			Console.WriteLine(
							"输入要切换的状态:\n" +
							"1. 播放\n" +
							"2. 停止\n" +
							"3. 弹出"
							);
			switch (Convert.ToByte(Console.ReadLine()))
			{
				case 1:
					new TapePlayer().Play();
					break;
				case 2:
					new TapePlayer().Stop();
					break;
				case 3:
					new TapePlayer().Open();
					break;
				default:
					throw new Exception("未知的状态");
			}
		}

		private void DVDPlayerControl()
		{
			Console.Clear();

			Console.WriteLine(
							"输入要切换的状态:\n" +
							"1. 播放\n" +
							"2. 停止\n" +
							"3. 弹出"
							);
			switch (Convert.ToByte(Console.ReadLine()))
			{
				case 1:
					new DVDPlayer().Play();
					break;
				case 2:
					new DVDPlayer().Stop();
					break;
				case 3:
					new DVDPlayer().Open();
					break;
				default:
					throw new Exception("未知的状态");
			}
		}

		private void CDPlayerControl()
		{
			Console.Clear();

			Console.WriteLine(
							"输入要切换的状态:\n" +
							"1. 播放\n" +
							"2. 停止\n" +
							"3. 弹出"
							);
			switch (Convert.ToByte(Console.ReadLine()))
			{
				case 1:
					new CDPlayer().Play();
					break;
				case 2:
					new CDPlayer().Stop();
					break;
				case 3:
					new CDPlayer().Open();
					break;
				default:
					throw new Exception("未知的状态");
			}
		}
	}

	//----------------------------------------------------------------

	interface IMediaPlayer
	{
		void Play();
		void Stop();
		void Open();
	}

	class TapePlayer : IMediaPlayer
	{
		public void Play()
		{
			Console.WriteLine("Tape播放");
		}

		public void Stop()
		{
			Console.WriteLine("Tape停止");
		}

		public void Open()
		{
			Console.WriteLine("Tape弹出");
		}
	}

	class DVDPlayer : IMediaPlayer
	{
		public void Play()
		{
			Console.WriteLine("DVD播放");
		}

		public void Stop()
		{
			Console.WriteLine("DVD停止");
		}

		public void Open()
		{
			Console.WriteLine("DVD弹出");
		}
	}
	class CDPlayer : IMediaPlayer
	{
		public void Play()
		{
			Console.WriteLine("CD播放");
		}

		public void Stop()
		{
			Console.WriteLine("CD停止");
		}

		public void Open()
		{
			Console.WriteLine("CD弹出");
		}
	}
}
