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
		ServicesResult<UserInfoDto> Register (RegisterParameter parameter);

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="request">Request.</param>
		ServicesResult<LoginDto> Login (LoginParameter parameter);
	}
}

