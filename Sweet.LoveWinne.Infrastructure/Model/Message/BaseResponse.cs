using System;
using Sweet.LoveWinne.Utility;

namespace Sweet.LoveWinne.Infrastructure
{
	public class BaseResponse<T> : ApiResponse
	{
		public T Result { get; set; }
	}

	public abstract class ApiResponse
	{
		/// <summary>
		/// 状态码
		/// </summary>
		/// <value>The status code.</value>
		public int MessageCode { get; set; }

		/// <summary>
		/// 错误信息
		/// </summary>
		/// <value>The message.</value>
		public string Message {
			get {
				return StatusUtility.GetInstance ().GetMessage (this.MessageCode.ToString ());
			}
		}
	}
}

