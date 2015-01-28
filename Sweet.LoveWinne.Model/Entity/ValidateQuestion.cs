using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	/// <summary>
	/// 注册时，需验证问题
	/// </summary>
	public class ValidateQuestion:BaseEntity
	{
		public long Id{ set; get; }

		public string Question{ set; get; }

		public QuestionTypeEnum QuestionType{ set; get; }

		public DateTime CreateDate{ set; get; }

		public bool IsValid{ set; get; }
	}
}

