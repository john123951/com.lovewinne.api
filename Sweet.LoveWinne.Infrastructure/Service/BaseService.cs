using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public abstract class BaseService
	{
		public T Success<T> (T response = null)
			where T : BaseResponse, new()
		{
			if (response == null) {
				response = new T ();
			}

			response.IsSuccess = true;
			return response;
		}

		public T Fail<T> (string messageCode)
			where T : BaseResponse, new()
		{
			return Fail<T> (messageCode, null);
		}

		public T Fail<T> (string messageCode, string content)
			where T : BaseResponse, new()
		{
//			var returnMsg = MessageCodesConfigs.GetMessageContent (messageCode);
//			if (string.IsNullOrEmpty (returnMsg)) {
//				returnMsg = content;
//			}

			var response = new T ();

			response.IsSuccess = false;
			response.MessageCode = messageCode;
//			response.Message = returnMsg;

			return response;
		}
	}
}

