using System;

namespace ScriptTest
{

	/// <summary>
	/// Hunger
	/// </summary>
	public class Hunger
	{
		private Hunger hu = new Hunger();

		private Hunger() { }

		public Hunger RerurnHunger()
		{
			return hu;
		}
	}

	/// <summary>
	/// Lazy
	/// </summary>
	public class Lazy
	{
		private Lazy la = null;

		private Lazy() { }

		public Lazy ReturnLasy()
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

