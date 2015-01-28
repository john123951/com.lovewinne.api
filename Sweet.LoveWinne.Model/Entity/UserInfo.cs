using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class UserInfo:BaseEntity
	{
		public long Id{ set; get; }

		public string UserName{ set; get; }

		public string Password{ set; get; }

		/// <summary>
		/// 已激活
		/// </summary>
		/// <value><c>true</c> if this instance is activated; otherwise, <c>false</c>.</value>
		public bool IsActivated{ set; get; }

		public DateTime ActivateDate{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

