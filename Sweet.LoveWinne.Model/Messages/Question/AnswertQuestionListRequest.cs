using System;
using Sweet.LoveWinne.Infrastructure;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Model
{
	public class AnswertQuestionListRequest : BaseRequest
	{
		/// <summary>
		/// User answer question list.
		/// </summary>
		/// <value>The answer question list.</value>
		public List<AnswerQuestionItem> AnswerQuestionList { get; set; }
	}
}

