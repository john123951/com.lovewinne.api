using System;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Sweet.LoveWinne.Infrastructure;
using System.Web;
using Sweet.LoveWinne.WebApiHost;

[assembly: PreApplicationStartMethod (typeof(PreApplicationStartCode), "PreStart")]

namespace Sweet.LoveWinne.WebApiHost
{
	public class PreApplicationStartCode
	{
		private static bool _hasLoaded;

		public static void PreStart ()
		{
			if (!_hasLoaded) {
				_hasLoaded = true;
				DynamicModuleUtility.RegisterModule (typeof(TraceModule));
			}
		}
	}
}

