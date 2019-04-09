using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RunIDEAConnection
{
	public class IDEAApp : Application
	{
		public IDEAApp()
		{
			ShutdownMode = ShutdownMode.OnExplicitShutdown;
		}
	};

	public class RunIDEAConnection
	{

		private dynamic dynLink;
		string ideaInstallDir;
		public RunIDEAConnection(string ideaInstallDir)
		{
			//string ideaInstallDir = ConnectionLinkTestApp.Properties.Settings.Default.IdeaInstallDir;
			this.ideaInstallDir = ideaInstallDir;
			if (Application.Current == null)
			{
				// create the Application object
				new IDEAApp(); //System::Windows::Application();
			}

		}

		private dynamic LinkAssembly
		{
			get
			{
				if (dynLink == null)
				{
					string ideaConLinkFullPath = System.IO.Path.Combine(ideaInstallDir, "IdeaRS.ConnectionLink.dll");
					if (!File.Exists(ideaConLinkFullPath))
					{
						//MessageBox.Show(string.Format("File {0} cannot be found.\n Please change path in Settings TabItem ", ideaConLinkFullPath), "Error", MessageBoxButton.OK);
						return null;
					}
					var conLinkAssembly = Assembly.LoadFrom(ideaConLinkFullPath);
					dynLink = conLinkAssembly.CreateInstance("IdeaRS.ConnectionLink.ConnectionLink");
				}

				return dynLink;
			}
		}


		/// <summary>
		/// Calls method IdeaRS.ConnectionLink.ConnectionLink.OpenIdeaConnection to run Idea Connection
		/// </summary>
		/// <param name="iomFilename">IOM filename - includes geometry of the connection (connected members)</param>
		/// <param name="templateFileName">Idea connection template or connection project file name</param>
		/// <param name="isHiddenCalculation">Set true to run hidden calculation </param>
		public void OpenIOMInIdeaCon(string iomFilename, string templateFileName, bool isHiddenCalculation)
		{
			FileStream fs = new FileStream(iomFilename, FileMode.Open, FileAccess.Read);
			FileStream fsr = null;

			string filenameRes = iomFilename + "R";
			if (System.IO.File.Exists(filenameRes))
			{
				fsr = new FileStream(filenameRes, FileMode.Open, FileAccess.Read);
			}

			FileStream connTemplateStream = null;
			FileStream connProjectStream = null;
			MemoryStream importSettingsStream = null;

			if (!string.IsNullOrEmpty(templateFileName) && File.Exists(templateFileName))
			{
				string fileExt = System.IO.Path.GetExtension(templateFileName);
				bool isConProject = fileExt.Equals(".ideacon", StringComparison.InvariantCultureIgnoreCase);

				if (isConProject)
				{
					connProjectStream = new FileStream(templateFileName, FileMode.Open, FileAccess.Read);
				}
				else
				{
					connTemplateStream = new FileStream(templateFileName, FileMode.Open, FileAccess.Read);
				}
			}
			string importSettingsText = string.Empty;
			importSettingsText += "<?xml version=\"1.0\"?>";
			importSettingsText += "<IdeaConImportSettings>";
			importSettingsText += "<UseWizard>true</UseWizard>";
			importSettingsText += "<OnePageWizard>true</OnePageWizard>";
			importSettingsText += "<DefaultBoltAssembly>M12 4.6</DefaultBoltAssembly>";
			importSettingsText += "</IdeaConImportSettings>";

			if (!string.IsNullOrEmpty(importSettingsText))
			{
				importSettingsStream = new System.IO.MemoryStream();
				var encoding = new System.Text.UTF8Encoding();
				importSettingsStream.Write(encoding.GetBytes(importSettingsText), 0, importSettingsText.Length);
				importSettingsStream.Flush();
				importSettingsStream.Seek(0, SeekOrigin.Begin);
			}

			if (LinkAssembly != null)
			{
				if (!isHiddenCalculation)
				{
					LinkAssembly.OpenIdeaConnection(fs, fsr, connProjectStream, connTemplateStream, importSettingsStream, true);
				}
				else
				{
					LinkAssembly.RunHiddenAnalysis(fs, fsr, connProjectStream, connTemplateStream, importSettingsStream, true);
					if (!LinkAssembly.IsProjectCalculated())
					{
						//this.resultBrowser.NavigateToString("Results doesn't exist");
						return;
					}

					string conCheckResFilename = LinkAssembly.GetCheckResultsFilename();
					//this.resultBrowser.Navigate(conCheckResFilename);
				}

				//OnProjOpened();
			}
		}
	}

}
