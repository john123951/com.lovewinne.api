using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;

namespace Sweet.LoveWinne.WebApiHost
{
	public static class WebApiConfig
	{
		public static void Register (HttpConfiguration config)
		{
			//测试
			config.Routes.MapHttpRoute (
				name: "Home",
				routeTemplate: "{controller}/{action}",
				defaults: new { controller = "Trace", action = "Test", httpMethod = new HttpMethodConstraint (HttpMethod.Get) }
			);
		}
	}
}