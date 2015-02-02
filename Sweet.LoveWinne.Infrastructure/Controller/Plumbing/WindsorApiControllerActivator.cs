using System;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace Sweet.LoveWinne.Infrastructure
{
	/// <summary>
	/// Web API 控制器工厂
	/// </summary>
	public class WindsorApiControllerActivator : IHttpControllerActivator
	{
		private readonly IKernel _kernel;

		public WindsorApiControllerActivator ()
		{
			_kernel = WindsorUtility.GetInstance ().Container.Kernel;
		}

		public WindsorApiControllerActivator (IKernel kernel)
		{
			_kernel = kernel;
		}

		public IHttpController Create (HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			if (controllerType == null) {
				var httpResponseMessage = new HttpResponseMessage (HttpStatusCode.NotFound) {
					Content = new StringContent (string.Format ("The controller for path '{0}' could not be found.", request.RequestUri))
				};
				throw new HttpResponseException (httpResponseMessage);
			}

			var controller = _kernel.Resolve (controllerType) as IHttpController;
			return controller;
		}
	}
}

