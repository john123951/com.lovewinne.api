using System;
using System.Web;
using System.Text;

namespace Sweet.LoveWinne.Infrastructure
{
	public class TraceModule : IHttpModule
	{
		public void Init (HttpApplication context)
		{
			context.BeginRequest += context_BeginRequest;
		}

		void context_BeginRequest (object sender, EventArgs e)
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

		public void Dispose ()
		{
		}
	}
}

