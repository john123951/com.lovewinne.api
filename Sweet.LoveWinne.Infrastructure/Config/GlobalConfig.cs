using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public class GlobalConfig
	{
		private GlobalConfig ()
		{
		}

		public static GlobalConfig GetInstance ()
		{
			return new GlobalConfig ();
		}

		/// <summary>
		/// Db connection string.
		/// </summary>
		/// <value>The connection string.</value>
		public string ConnectionString { get; set; }



	}
}

