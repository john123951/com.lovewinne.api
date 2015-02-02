using System;
using System.Web.Http;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Infrastructure
{
	public abstract class DefaultApiController : ApiController
	{
		public BaseResponse<T> Success<T> (T data)
		{
			var response = new BaseResponse<T> {
				Result = data,
				MessageCode = (int)StatusCode.Succeed.OK
			};

			return response;
		}

		public BaseResponse<T> Fail<T> (int errorStatusCode)
		{
			var data = default(T);

			var response = new BaseResponse<T> {
				Result = data,
				MessageCode = errorStatusCode
			};

			return response;
		}
	}
}

