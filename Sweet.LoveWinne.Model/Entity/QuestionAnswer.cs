using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	/// <summary>
	/// 正确答案
	/// </summary>
	public class QuestionAnswer:BaseEntity
	{
		public long Id{ set; get; }

		public string CorrectAnswer{ set; get; }

		public long QuestionId{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

