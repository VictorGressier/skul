using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Assign4ErrorHandling.Utilities
{
	public class Logger
	{
		private static Logger theInstance = null;
		public static Logger Instance
		{
			get
			{
				if (theInstance == null)
				{
					theInstance = new Logger();
				}
				return theInstance;
			}
		}

		public void LogException(Exception ex)
		{
			string logFilePath = ConfigurationManager.AppSettings["LogFile"];

			string message = string.Format("{0} was thrown on the {1}.{2}", 
				ex.Message, DateTime.Now, Environment.NewLine);

			string logPath = "";

			if (!Directory.Exists(logFilePath))
			{
				//retrieve only the path of the error message
				int pos = logFilePath.LastIndexOf('\\');
				if (pos >= 0)
					logPath = logFilePath.Substring(0, pos+1);

				Directory.CreateDirectory(logPath);
			}
			using (StreamWriter writer = new StreamWriter(logFilePath, true, Encoding.Default))
			{
				writer.WriteLine(message);
			}

		}
	}
}