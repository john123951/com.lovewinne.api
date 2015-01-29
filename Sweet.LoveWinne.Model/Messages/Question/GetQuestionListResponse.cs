﻿using System;
using Sweet.LoveWinne.Infrastructure;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Model
{
	public class GetQuestionListResponse: BaseResponse
	{
		/// <summary>
		/// The validate question list.
		/// </summary>
		/// <value>The question list.</value>
		public List<QuestionDto>  QuestionList { get; set; }
	}
}

