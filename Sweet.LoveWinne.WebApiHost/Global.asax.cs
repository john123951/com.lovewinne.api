
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using System.Text;

namespace Sweet.LoveWinne.WebApiHost
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start ()
		{
			//注册区域
//			AreaRegistration.RegisterAllAreas();

			//注册路由
			WebApiConfig.Register (GlobalConfiguration.Configuration);
			//RouteConfig.RegisterRoutes(RouteTable.Routes);

			//注册Filters
//			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

			//设置API返回格式
//			GlobalConfiguration.Configuration.Formatters.Clear();
//			GlobalConfiguration.Configuration.Formatters.Add(new JsonFormatter());
//			GlobalConfiguration.Configuration.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(new JsonFormatter()));

			//注册管道事件
			Configure (GlobalConfiguration.Configuration);
		}

		private static void Configure (HttpConfiguration configuration)
		{
			//兼容请求头
//			configuration.MessageHandlers.Add(new IgnoreJsonHeaderHandler());
		}

		void Application_BeginRequest (object sender, EventArgs e)
		{
			HttpApplication app = sender as HttpApplication;
			if (app == null) {
				return;
			}
			var context = app.Context;  //请求上下文


			//只支持/trace
			if (string.Compare (context.Request.RawUrl, "/trace") == 0) {

				var modules = app.Modules;
				var responseBuilder = new StringBuilder ();
				responseBuilder.Append ("<table>");
				responseBuilder.Append ("<tr><th>名称</th><th>类</th></tr>");

				foreach (var moduleName in modules.AllKeys) {
					responseBuilder.Append ("<tr>");
					var typeFullName = modules [moduleName].GetType ().FullName;

					responseBuilder.AppendFormat (@"<td>{0}</td><td>{1}</td>", moduleName, typeFullName);
					responseBuilder.Append ("</tr>");
				}

				responseBuilder.Append ("</table>");

				context.Response.ClearContent ();
				context.Response.Write (responseBuilder.ToString ());
				context.Response.End ();
			}
		}
	}
}
