using System;
using ServiceStack.DataAnnotations;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	[Alias ("RoleInfo")]
	public class RoleInfo : BaseEntity
	{
		[AutoIncrement]
		public long Id{ set; get; }

		public string RoleName{ set; get; }

		public string Description{ set; get; }

		public long CreateAdminUser{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

