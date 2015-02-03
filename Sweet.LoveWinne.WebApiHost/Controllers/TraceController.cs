using System;
using System.Web.Http;

namespace Sweet.LoveWinne.Controller
{
	public class TraceController: ApiController
	{
		[HttpGet]
		public string Test ()
		{
			return "OK";
		}
	}
}

