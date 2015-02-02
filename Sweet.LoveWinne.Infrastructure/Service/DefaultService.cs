using System;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Infrastructure
{
	public abstract class DefaultService
	{
		public ServicesResult<T> Success<T> (T data)
		{
			var result = new ServicesResult<T> { 
				StatusCode = (int)StatusCode.Succeed.OK, 
				Result = data
			};

			return result;
		}

		public ServicesResult<T> Fail<T> (int errorStatusCode)
		{
			var result = new ServicesResult<T> { 
				StatusCode = errorStatusCode
			};

			return result;
		}
	}
}

