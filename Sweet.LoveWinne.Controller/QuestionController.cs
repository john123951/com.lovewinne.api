using System;
using System.Web.Http;
using Sweet.LoveWinne.Service;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Controller
{
	public class QuestionController: ApiController//, IQuestionService
	{
		IQuestionService _questionService;

		public QuestionController (IQuestionService questionService)
		{
			_questionService = questionService;
		}

	}
}

