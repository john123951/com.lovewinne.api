using System;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Service
{
	public interface IAccountService
	{
		/// <summary>
		/// Register User
		/// </summary>
		/// <param name="request">Request.</param>
		ServicesResult<UserInfo> Register (RegisterParameter parameter);

		/// <summary>
		/// Login
		/// unknowError
		/// login_000001	用户密码错误
		/// login_000002	用户未授权
		/// </summary>
		/// <param name="request">Request.</param>
		ServicesResult<LoginModel> Login (LoginParameter parameter);
	}
}

