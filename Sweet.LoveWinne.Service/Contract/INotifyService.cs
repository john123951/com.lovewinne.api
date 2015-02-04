using System;
using Sweet.LoveWinne.Infrastructure;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Service
{
	public interface INotifyService
	{
		/// <summary>
		/// Gets the user notify.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		ServicesResult<NotifyDto> GetUserNotify (long userId);
	}
}

