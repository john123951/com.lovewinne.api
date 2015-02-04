using System;

namespace Sweet.LoveWinne.Utility
{
	public static class ExceptionExtention
	{
		/// <summary>
		/// Writes the log.
		/// </summary>
		/// <param name="exception">The exception</param>
		/// <param name="logName">The name</param>
		public static void WriteLog (this Exception exception, string logName)
		{
			var log = LogUtility.GetInstance ().GetLog (logName);
			if (log == null) {
				return;
			}

			log.Error (exception);
		}
	}
}

