using System;

namespace Sweet.LoveWinne.Model
{
	public class LoginModel
	{
		/// <summary>
		/// 用户信息
		/// </summary>
		/// <value>The user info.</value>
		public UserInfo UserInfo { get; set; }

		/// <summary>
		/// 访问令牌
		/// </summary>
		/// <value>The access token.</value>
		public string AccessToken { get; set; }

		/// <summary>
		/// 通告
		/// </summary>
		/// <value>The notify.</value>
		public string Notify { get; set; }
	}
}

