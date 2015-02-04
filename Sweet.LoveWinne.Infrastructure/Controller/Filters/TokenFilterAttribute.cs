using System;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using Sweet.LoveWinne.Utility;

namespace Sweet.LoveWinne.Infrastructure
{
	public class TokenFilterAttribute : ActionFilterAttribute
	{
		const string logName = "token";

		public override void OnActionExecuting (HttpActionContext actionContext)
		{
			var controller = actionContext.ControllerContext.Controller as DefaultApiController;
			if (controller == null) {
				return;
			}

			//验证Token
			var token = actionContext.Request.Headers.Read ("Token");

			if (token.IsNullOrEmpty ()) {
				var exception = new Exception ("Token为空");
				exception.WriteLog (logName);
				throw exception;
			}

			var filterServices = WindsorUtility.GetInstance ().Resolve<IAuthenticationProvider> ();
			if (filterServices == null) {
				throw new Exception ("未找到IAuthenticationProvider实例");
			}

			var result = filterServices.ValidateToken (controller.UserId, token);
			if (result.IsSuccess) {
				return;//正常执行
			}

			if (result != null) {
				var message = StatusUtility.GetInstance ().GetMessage (result.StatusCode.ToString ());
				var exception = new Exception (message);
				exception.WriteLog (logName);
				throw exception;
			}

			var lastException = new Exception ("Token验证错误");
			lastException.WriteLog (logName);
			throw lastException;
		}
	}
}

