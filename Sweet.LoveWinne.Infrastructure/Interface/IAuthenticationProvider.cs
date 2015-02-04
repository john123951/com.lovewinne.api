using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Infrastructure
{
	public interface IAuthenticationProvider
	{
		/// <summary>
		/// Set the access token.
		/// </summary>
		/// <returns>The token.</returns>
		/// <param name="accessToken">Access token.</param>
		ServicesResult<bool> SetToken (TokenDto accessToken);

		/// <summary>
		/// Gets the token.
		/// </summary>
		/// <returns>The token.</returns>
		/// <param name="userId">User identifier.</param>
		/// <param name="accessToken">Access token.</param>
		ServicesResult<TokenDto> ValidateToken (long userId, string accessToken);
	}
}

