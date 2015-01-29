using System;
using Sweet.LoveWinne.Infrastructure;
using ServiceStack.DataAnnotations;

namespace Sweet.LoveWinne.Model
{
	[Alias ("MachineInfo")]
	public class MachineInfo : BaseEntity
	{
		[AutoIncrement]
		public long Id{ set; get; }

		[Index]
		[StringLength (256)]
		public string MachineNo{ set; get; }

		[Index]
		public long UserId{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

