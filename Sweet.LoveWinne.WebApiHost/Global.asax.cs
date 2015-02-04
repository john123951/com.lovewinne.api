
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using System.Text;
using Sweet.LoveWinne.Infrastructure;
using System.Net.Http.Formatting;

namespace Sweet.LoveWinne.WebApiHost
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start ()
		{
			BootstrapManager.GetInstance ().AppServerInitialize ();

			//注册路由
			WebApiConfig.Register (GlobalConfiguration.Configuration);
			//RouteConfig.RegisterRoutes(RouteTable.Routes);

			//设置API返回格式
			GlobalConfiguration.Configuration.Formatters.Clear ();
			GlobalConfiguration.Configuration.Formatters.Add (new JsonFormatter ());
			GlobalConfiguration.Configuration.Services.Replace (typeof(IContentNegotiator), new JsonContentNegotiator (new JsonFormatter ()));

			//注册管道事件
			Configure (GlobalConfiguration.Configuration);
		}

		private static void Configure (HttpConfiguration configuration)
		{
			//兼容请求头
			configuration.MessageHandlers.Add (new IgnoreJsonHeaderHandler ());
		}

		void Application_BeginRequest (object sender, EventArgs e)
		{
		}
	}
}
