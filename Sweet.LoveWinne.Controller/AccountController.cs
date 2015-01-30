using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Sweet.LoveWinne.Service;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Controller
{
	public class AccountController : ApiController //, IAccountService
	{
		IAccountService _accountService;

		public AccountController (IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		public RegisterResponse Register (RegisterRequest request)
		{
			var result = _accountService.Register (request);

			return result;
		}

		[HttpPost]
		public LoginResponse Login (LoginRequest request)
		{
			var result = _accountService.Login (request);

			return result;
		}

	}
}
