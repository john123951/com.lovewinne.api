using System;
using Sweet.LoveWinne.Infrastructure;
using ServiceStack.DataAnnotations;

namespace Sweet.LoveWinne.Model
{
	[Alias ("UserInfo")]
	public class UserInfo : BaseEntity
	{
		[AutoIncrement]
		public long Id{ set; get; }

		[StringLength (16)]
		public string UserName{ set; get; }

		[StringLength (256)]
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

