using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public class ServicesResult<T> : DefaultServicesResult
	{
		internal ServicesResult ()
		{			
		}

		/// <summary>
		/// Gets or sets the Result of ServicesResult{T}
		/// </summary>
		/// <value>
		/// The Result
		/// </value>
		public T Result { get; set; }
	}
}

