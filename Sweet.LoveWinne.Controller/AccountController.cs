using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Sweet.LoveWinne.Service;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Infrastructure;
using AutoMapper;

namespace Sweet.LoveWinne.Controller
{
	public class AccountController : DefaultApiController
	{
		IAccountService _accountService;

		public AccountController (IAccountService accountService)
		{
			_accountService = accountService;
		}

		public BaseResponse<bool> Register (RegisterRequest request)
		{
			var parameter = Mapper.Map<RegisterParameter> (request);

			var regResult = _accountService.Register (parameter);

			if (regResult.IsSuccess) {
				return Success (regResult.Result != null && regResult.Result.Id > 0);
			}
			return Fail<bool> (regResult.StatusCode);
		}

		public BaseResponse<LoginResult> Login (LoginRequest request)
		{
			var parameter = Mapper.Map<LoginParameter> (request);

			var loginResult = _accountService.Login (parameter);

			if (loginResult.IsSuccess) {
				var data = Mapper.Map<LoginResult> (loginResult.Result);
				return Success (data);
			}

			return Fail<LoginResult> (loginResult.StatusCode);
		}
	}
}
