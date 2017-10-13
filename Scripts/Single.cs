using System;

namespace ScriptTest
{

	/// <summary>
	/// Hunger
	/// </summary>
	public class Hunger
	{
		private static Hunger hu = new Hunger();

		private Hunger() { }

		public static Hunger RerurnHunger()
		{
			return hu;
		}
	}

	/// <summary>
	/// Lazy
	/// </summary>
	public class Lazy
	{
		private static Lazy la = null;

		private Lazy() { }

		public static Lazy ReturnLasy()
		{
			lock (la)
			{

				if (la == null)
				{
					la = new Lazy();
				}
				return la;
			}
		}
	}
}

