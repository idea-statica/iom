using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IOM_IDEAConnectionRunnerTestApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static string IdeaInstallDir;
		public static readonly ILog LinkLogger = LogManager.GetLogger("ConnectionLinkLogger");
		static App()
		{
			IdeaInstallDir = IOM_IDEAConnectionRunnerTestApp.Properties.Settings.Default.IdeaInstallDir;

			//AppDomain currentDomain = AppDomain.CurrentDomain;
			//currentDomain.AssemblyResolve += new ResolveEventHandler(IdeaResolveEventHandler);
		}

	}
}
