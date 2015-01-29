using System;
using Sweet.LoveWinne.Infrastructure;
using ServiceStack.DataAnnotations;

namespace Sweet.LoveWinne.Model
{
	/// <summary>
	/// 正确答案
	/// </summary>
	[Alias ("QuestionAnswer")]
	public class QuestionAnswer : BaseEntity
	{
		[AutoIncrement]
		public long Id{ set; get; }

		public string CorrectAnswer{ set; get; }

		[Index]
		public long QuestionId{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

