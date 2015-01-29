using System;
using Sweet.LoveWinne.Infrastructure;
using ServiceStack.DataAnnotations;

namespace Sweet.LoveWinne.Model
{
	/// <summary>
	/// Action info.
	/// </summary>
	[Alias ("ActionInfo")]
	public class ActionInfo : BaseEntity
	{
		public long Id{ set; get; }

		public string Name{ set; get; }

		public string Description{ set; get; }

		public long CreateAdminUser{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

