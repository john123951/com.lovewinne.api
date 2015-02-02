using System;
using log4net;

namespace Sweet.LoveWinne.Utility
{
	public enum Log4NetType
	{
		Debug,
		Info,
		Warn,
		Error,
		Fatal,
	}

	public class LogUtility
	{
		private static LogUtility _instance;

		private LogUtility ()
		{
		}

		public static LogUtility GetInstance ()
		{
			if (_instance == null) {
				throw new Exception ("Must Call Register() Method");
			}
			return _instance;
		}

		public static void Register ()
		{
			log4net.Config.XmlConfigurator.Configure ();
			_instance = new LogUtility ();
		}

		public static void Register (string xmlPath)
		{
			log4net.Config.XmlConfigurator.ConfigureAndWatch (new System.IO.FileInfo (xmlPath));
			_instance = new LogUtility ();
		}

		public ILog GetLog (string name)
		{
			var logger = LogManager.GetLogger (name);
			return logger;
		}
	}
}

