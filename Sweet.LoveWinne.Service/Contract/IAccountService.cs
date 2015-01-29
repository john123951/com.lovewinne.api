using System;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Service
{
	public interface IAccountService
	{
		/// <summary>
		/// Register User
		/// </summary>
		/// <param name="request">Request.</param>
		RegisterResponse Register (RegisterRequest request);

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="request">Request.</param>
		LoginResponse Login (LoginRequest request);
	}
}

