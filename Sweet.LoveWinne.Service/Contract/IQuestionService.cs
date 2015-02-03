using System;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Infrastructure;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Service
{
	public interface IQuestionService
	{
		/// <summary>
		/// Gets the question list.
		/// </summary>
		/// <returns>The question list.</returns>
		/// <param name="request">Request.</param>
		ServicesResult<List<QuestionDto>> GetQuestionList (GetQuestionListParameter request);

		/// <summary>
		/// Answert the question list.
		/// </summary>
		/// <returns>The question list.</returns>
		/// <param name="request">Request.</param>
		ServicesResult<bool> AnswertQuestionList (AnswertQuestionListParameter request);
	}
}

