using System;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Service
{
	public interface IQuestionService
	{
		/// <summary>
		/// Gets the question list.
		/// </summary>
		/// <returns>The question list.</returns>
		/// <param name="request">Request.</param>
		GetQuestionListResponse GetQuestionList (GetQuestionListRequest request);

		/// <summary>
		/// Answert the question list.
		/// </summary>
		/// <returns>The question list.</returns>
		/// <param name="request">Request.</param>
		AnswertQuestionListResponse AnswertQuestionList (AnswertQuestionListRequest request);
	}
}

