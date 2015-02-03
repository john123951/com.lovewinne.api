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
		IShadowProxyService _shadowProxyService;

		public ShadowServerController (IShadowProxyService shadowProxyService)
		{
			_shadowProxyService = shadowProxyService;			
		}

	}
}
