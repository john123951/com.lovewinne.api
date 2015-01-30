using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class NotifyInfo : BaseEntity
	{
		public long Id { get; set; }

		public string Content { get; set; }
	}
}

