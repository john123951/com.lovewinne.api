using System;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Service
{
	public interface IQuestionService
	{
		/// <summary>
		/// Gets the question list.
		/// </summary>
		/// <returns>The question list.</returns>
		/// <param name="request">Request.</param>
		ServicesResult<GetQuestionListResult> GetQuestionList (GetQuestionListRequest request);

		/// <summary>
		/// Answert the question list.
		/// </summary>
		/// <returns>The question list.</returns>
		/// <param name="request">Request.</param>
		ServicesResult<AnswertQuestionListResult> AnswertQuestionList (AnswertQuestionListRequest request);
	}
}

