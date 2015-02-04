using System;
using System.Web.Http;

namespace Sweet.LoveWinne.Infrastructure
{
	public sealed class BootstrapManager
	{
		private BootstrapManager ()
		{			
		}

		public static BootstrapManager GetInstance ()
		{
			return new BootstrapManager ();
		}

		public void AppServerInitialize ()
		{


		}

	}
}

