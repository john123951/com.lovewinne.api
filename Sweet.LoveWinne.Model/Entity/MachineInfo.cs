using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class MachineInfo:BaseEntity
	{
		public long Id{ set; get; }

		public string MachineNo{ set; get; }

		public long UserId{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

