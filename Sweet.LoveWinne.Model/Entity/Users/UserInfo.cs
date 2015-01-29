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

		[StringLength (64)]
		public string UserName{ set; get; }

		[StringLength (256)]
		public string Password{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

