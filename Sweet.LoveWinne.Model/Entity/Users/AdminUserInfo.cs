using System;
using ServiceStack.DataAnnotations;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	/// <summary>
	/// Admin user info.
	/// </summary>
	[Alias ("AdminUserInfo")]
	public class AdminUserInfo : BaseEntity
	{
		public long Id{ set; get; }

		public string AdminUserName{ set; get; }

		public string Password{ set; get; }

		public DateTime CreateDate{ set; get; }

		public long CreateAdminUser{ set; get; }

		public bool IsValid{ set; get; }
	}
}

