using System;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Repository
{
	public interface INotifyRepository
	{
		NotifyInfo GetUserNotify (long userId);
	}
}

