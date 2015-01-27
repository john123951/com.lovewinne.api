
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Http;

namespace Sweet.LoveWinne.WebApiHost
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start ()
		{
			//注册区域
//			AreaRegistration.RegisterAllAreas();

			//注册路由
			WebApiConfig.Register(GlobalConfiguration.Configuration);
			//RouteConfig.RegisterRoutes(RouteTable.Routes);

			//注册Filters
//			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

			//设置API返回格式
//			GlobalConfiguration.Configuration.Formatters.Clear();
//			GlobalConfiguration.Configuration.Formatters.Add(new JsonFormatter());
//			GlobalConfiguration.Configuration.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(new JsonFormatter()));

			//注册管道事件
			Configure(GlobalConfiguration.Configuration);
		}

		private static void Configure(HttpConfiguration configuration)
		{
			//兼容请求头
//			configuration.MessageHandlers.Add(new IgnoreJsonHeaderHandler());
		}
	}
}
