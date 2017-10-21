using System;
using System.Media;
using System.IO;

namespace MusicTest
{
	class MusicTest
	{
		public void MusicTestInside()
		{
			Stream stream = File.OpenRead("../../Assets/Music/music_background.wav");
			SoundPlayer player = new SoundPlayer(stream);
			player.PlayLooping();
			Console.ReadKey(true);
			player.Stop();
			stream.Dispose();
		}
	}
}
