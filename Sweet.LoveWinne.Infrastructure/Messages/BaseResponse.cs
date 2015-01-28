using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public abstract class BaseResponse
	{
		public bool IsSuccess { get; set; }

		public string Message { get; set; }

		public string MessageCode { get; set; }
	}
}

