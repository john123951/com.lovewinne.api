using System;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Infrastructure
{
	public class ServicesResultList<T> : DefaultServicesResult
	{
		/// <summary>
		/// Gets or sets the Result of ServicesResultList{T}
		/// </summary>
		/// <value>
		/// The Result
		/// </value>
		public List<T> Result { get; set; }

		/// <summary>
		/// Gets or sets the Count of ServicesResultList{T}
		/// </summary>
		/// <value>
		/// The Count
		/// </value>
		public int TotalCount { get; set; }
	}
}

