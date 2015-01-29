using System;
using Sweet.LoveWinne.Infrastructure;
using ServiceStack.DataAnnotations;

namespace Sweet.LoveWinne.Model
{
	/// <summary>
	/// 注册时，需验证问题
	/// </summary>
	[Alias ("Question")]
	public class Question:BaseEntity
	{
		[AutoIncrement]
		public long Id{ set; get; }

		public string QuestionContent{ set; get; }

		public QuestionTypeEnum QuestionType{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

