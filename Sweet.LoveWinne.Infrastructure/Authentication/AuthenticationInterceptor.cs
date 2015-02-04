using System;
using Castle.DynamicProxy;

namespace Sweet.LoveWinne.Infrastructure
{
	/// <summary>
	/// Need be authenticated
	/// </summary>
	public class AuthenticationInterceptor : IInterceptor
	{
		public long UserId { get; set; }

		public void Intercept (IInvocation invocation)
		{
			var authResult = ValidateAuth (this.UserId);

			if (authResult.IsSuccess) {
				invocation.Proceed ();
			} else {
				invocation.ReturnValue = authResult;
			}
		}

		private DefaultServicesResult ValidateAuth (long userId)
		{
			return new DefaultServicesResult ();
		}
	}
}

