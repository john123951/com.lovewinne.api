using System;
using Castle.Windsor;
using System.Reflection;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;

namespace Sweet.LoveWinne.Infrastructure
{
	public class WindsorUtility
	{
		private static WindsorUtility _instance;

		private WindsorUtility ()
		{
		}

		public static WindsorUtility GetInstance ()
		{
			if (_instance == null) {
				_instance = new WindsorUtility ();
			}
			return _instance;
		}

		public IWindsorContainer Container {
			get;
			private set;
		}

		#region 实例方法

		/// <summary>
		/// 使用AppConfig的设置注册组件
		/// </summary>
		public void RegisterAppConfig ()
		{
			if (Container == null) {
				new WindsorContainer ();
			}
			Container.Install (Configuration.FromAppConfig ());
		}

		/// <summary>
		/// 扫描自身程序集并自动注册组件
		/// </summary>
		public void Register (Assembly asm)
		{
			if (Container == null) {
				new WindsorContainer ();
			}
			Container.Install (FromAssembly.Instance (asm));
		}

		/// <summary>
		/// 使用XML文件注册组件
		/// </summary>
		public void Register (string configFile)
		{
			if (Container == null) {
				new WindsorContainer ();
			}
			Container.Install (Configuration.FromXmlFile (configFile));
		}

		/// <summary>
		/// 注册一个组件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="TM"></typeparam>
		public void Register<T, TM> ()
			where TM : T
			where T : class
		{
			if (Container == null) {
				new WindsorContainer ();
			}

			Container.Register (Component.For<T> ().ImplementedBy<TM> ());
		}

		/// <summary>
		/// 获取一个组件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T Resolve<T> ()
		{
			if (Container == null) {
				throw new NullReferenceException ("Container");
			}

			return Container.Resolve<T> ();
		}

		#endregion 实例方法
	}
}

