using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManagementSystem.Classes
{
	public sealed class Logger
	{
		private static Logger instance = null;
		private static readonly object padlock = new object();
		private static string? log_full_path;
		private static StreamWriter? writer;

		/// <summary>
		/// Calling the constructor initializes the logger automatically and leaves the singleton ready to write in a file
		/// 
		/// Log file name will be determined by local system date
		/// </summary>
		/// <exception cref="NullReferenceException"></exception>
		public static void Init()
		{
			//	Log path according to build mode
			#if DEBUG
				string log_path = "../../../logs/";
			#else
				string log_path = "";
			#endif

			//	Create folder if it doesn't exist
			if (!Directory.Exists(log_path))
			{
				Directory.CreateDirectory(log_path);
			}
			else
			{
				Debug.WriteLine("Folder already exists!");
			}

			//	Check if log file for today exists
			log_full_path = log_path + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
			if (!File.Exists(log_full_path) && log_full_path != null)
			{
				File.Create(log_full_path);
			}
			else
			{
				Debug.WriteLine("File exists!");
			}

			//	Assign the writer to the static StreamWriter object to keep the file open in memory constantly for faster access
			if (log_full_path == null)
			{
				throw new NullReferenceException("Log path was empty when initializing logger!");
			}			
		}

		/// <summary>
		/// Singleton getter to only instance the logger one, and return the existing instance in every other newer call
		/// </summary>
		public static Logger Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new Logger();
					}
					return instance;
				}
			}
		}

		/// <summary>
		/// Execute log, receives the messae to log and the level needed to display.
		/// 
		/// Every other parameters are fetched with attributes from compiler services
		/// </summary>
		/// <param name="message"></param>
		/// <param name="level"></param>
		/// <param name="sourceFilePath"></param>
		/// <param name="sourceLineNumber"></param>
		/// <param name="memberName"></param>
		public void Log(
			string message, 
			LogLevel level,
			[System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
			[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0,
			[System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
		{
			string level_str;

			switch(level)
			{
				case LogLevel.Debug:
					level_str = "[DEBUG]\t";
					break;
				case LogLevel.Info:
					level_str = "[INFO]\t";
					break;
				case LogLevel.Warning:
					level_str = "[WARNING]";
					break;
				case LogLevel.Error:
					level_str = "[ERROR]\t";
					break;
				default:
					level_str = "[DEBUG]\t";
					break;
			}

			this.LogExec(this.BuildLogMessage(
				DateTime.Now,
				level_str,
				sourceFilePath,
				sourceLineNumber,
				memberName,
				message));
		}

		/// <summary>
		/// Formats the log message to be written into the log file
		/// </summary>
		/// <param name="datetime"></param>
		/// <param name="level"></param>
		/// <param name="fileName"></param>
		/// <param name="fileLine"></param>
		/// <param name="methodName"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private string BuildLogMessage(
			DateTime datetime,
			string level,
			string fileName,
			int fileLine,
			string methodName,
			string message)
		{
			int index = fileName.LastIndexOf('\\');
			string fileNameFormatted = fileName.Substring(index + 1);

			return datetime.ToString("yy/MM/ddThh:mm:ss.ffffff") + "\t" + level + "\t" + fileNameFormatted + ":" + fileLine + " -> " + methodName + "()\t\t\t" + message;
		}

		/// <summary>
		/// Executes the log writing by opening the writer, writing the message into the file and closing the stream
		/// </summary>
		/// <param name="log"></param>
		/// <exception cref="ArgumentNullException"></exception>
		private void LogExec(string log)
		{
			if (log_full_path == null)
			{
				throw new ArgumentNullException("Logger writer was nulled");
			}
			StreamWriter writer = new StreamWriter(log_full_path, true);

			writer.WriteLine(log);
			writer.Close();
		}
	}

	/// <summary>
	///	Enables the logger to write a message separating by levels to display different information
	/// </summary>
	public enum LogLevel
	{
		Debug,
		Info,
		Warning,
		Error,
	}
}
