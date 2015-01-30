using System;
using System.Web.Http;
using Sweet.LoveWinne.Service;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Controller
{
	public class QuestionController: ApiController, IQuestionService
	{
		IQuestionService _questionService;

		public QuestionController (IQuestionService questionService)
		{
			_questionService = questionService;
		}

		[HttpPost]
		public GetQuestionListResponse GetQuestionList (GetQuestionListRequest request)
		{
			var result = _questionService.GetQuestionList (request);

			return result;
		}

		[HttpPost]
		public AnswertQuestionListResponse AnswertQuestionList (AnswertQuestionListRequest request)
		{
			var result = _questionService.AnswertQuestionList (request);

			return result;
		}
	}
}

