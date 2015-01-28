using System;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Service
{
	public interface IAccountService
	{
		/// <summary>
		/// Registry User
		/// </summary>
		/// <param name="request">Request.</param>
		RegistryResponse Registry (RegistryRequest request);

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="request">Request.</param>
		LoginResponse Login (LoginRequest request);
	}
}

