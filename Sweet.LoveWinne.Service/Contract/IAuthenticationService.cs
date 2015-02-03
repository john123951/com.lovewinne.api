using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Service
{
	public interface IAuthenticationService
	{
		/// <summary>
		/// 获取Token
		/// </summary>
		/// <param name="accessToken">The accessToken</param>
		/// <returns>
		/// ServicesResult{TokenModel}
		/// </returns>
		//		ServicesResult<TokenModel> GetToken (string accessToken);

		/// <summary>
		/// 验证客户端
		/// </summary>
		/// <param name="appKey">The appKey</param>
		/// <param name="appPassword">The appPassword</param>
		/// <returns>
		/// Boolean}
		/// </returns>
		ServicesResult<bool> ValidateApp (string appKey, string appPassword);
	}
}

