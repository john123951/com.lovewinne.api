using System;
using Sweet.LoveWinne.Infrastructure;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Model
{
	public class GetQuestionListResult
	{
		/// <summary>
		/// Question title.
		/// </summary>
		/// <value>The question title.</value>
		public string QuestionTitle { get; set; }

		/// <summary>
		/// The validate question list.
		/// </summary>
		/// <value>The question list.</value>
		public List<QuestionDto>  QuestionList { get; set; }
	}
}

