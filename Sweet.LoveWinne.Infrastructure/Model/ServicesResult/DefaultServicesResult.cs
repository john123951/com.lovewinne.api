using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public class DefaultServicesResult
	{
		internal DefaultServicesResult ()
		{			
		}

		/// <summary>
		/// Gets or sets the status code.
		/// </summary>
		/// <value>The status code.</value>
		public int StatusCode { get; set; }

		/// <summary>
		/// Gets a value indicating whether this instance is success.
		/// </summary>
		/// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
		public bool IsSuccess {
			get { 
				return StatusCode == (int)Sweet.LoveWinne.Infrastructure.StatusCode.Succeed.OK;
			}
		}
	}
}

