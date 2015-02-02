using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public class StatusCode
	{
		/// <summary>
		/// 成功状态
		/// </summary>
		public enum Succeed
		{
			/// <summary>
			/// 操作成功
			/// </summary>
			OK = 200,

			/// <summary>
			/// 查询结果为空
			/// </summary>
			Empty = 201
		}

		/// <summary>
		/// 系统错误码
		/// </summary>
		public enum System
		{
			/// <summary>
			/// 未知错误
			/// </summary>
			UnknowError = 1000,

			/// <summary>
			/// 签名错误
			/// </summary>
			InvalidSign = 1001,

			/// <summary>
			/// 内部服务器错误
			/// </summary>
			InternalServerError = 1002,

			/// <summary>
			/// 请求参数错误
			/// </summary>
			InvalidRequest = 1003,

			/// <summary>
			/// 请求验证失败
			/// </summary>
			Unauthorized = 1004,

			/// <summary>
			/// 支付参数错误
			/// </summary>
			InvalidPaymentRequest = 1005,

			/// <summary>
			/// 无效的请求地址
			/// </summary>
			InvalidRequestUrl = 1006
		}
	}
}

