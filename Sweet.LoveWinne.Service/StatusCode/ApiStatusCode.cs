using System;

namespace Sweet.LoveWinne.Model
{
	public partial class ApiStatusCode
	{
		/// <summary>
		/// 用户错误码
		/// </summary>
		public enum Account
		{
			/// <summary>
			/// 未知错误
			/// </summary>
			UnknowError = 10000,

			/// <summary>
			/// 注册失败
			/// </summary>
			RegisterFailed = 10001,

			/// <summary>
			/// 用户名或密码错误
			/// </summary>
			InvalidUserNameOrPassword = 10002,
		}

		public enum ShadowServer
		{
			GetServerListFailed = 20001,
		}
	}
}

