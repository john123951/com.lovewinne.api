using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Sweet.LoveWinne.Service;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Controller
{
	public class ShadowServerController : ApiController
	{
		IShadowServerService _shadowProxyService;

		public ShadowServerController (IShadowServerService shadowProxyService)
		{
			_shadowProxyService = shadowProxyService;			
		}

	}
}
