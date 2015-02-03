using System;
using Castle.DynamicProxy;

namespace Sweet.LoveWinne.Infrastructure
{
	/// <summary>
	/// Need be authenticated
	/// </summary>
	public class AuthenticationInterceptor : IInterceptor
	{
		public void Intercept (IInvocation invocation)
		{
			throw new NotImplementedException ();
		}

		private bool ValidateAuth (long userId)
		{

		}

	}
}

