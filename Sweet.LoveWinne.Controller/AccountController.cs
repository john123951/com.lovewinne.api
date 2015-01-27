using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sweet.LoveWinne.Controller
{
    public class AccountController : ApiController
    {
		[HttpGet]
        public string Index()
        {
			return "Account";
        }
    }
}
