using System;
using System.IO;

namespace ConnectionLinkTestApp
{
	public partial class MainWindow
	{
		/// <summary>
		/// Calls method IdeaRS.ConnectionLink.ConnectionLink.OpenIdeaConnection to run Idea Connection
		/// </summary>
		/// <param name="iomFilename">IOM filename - includes geometry of the connection (connected members)</param>
		/// <param name="templateFileName">Idea connection template or connection project file name</param>
		/// <param name="isHiddenCalculation">Set true to run hidden calculation </param>
		private void OpenIOMInIdeaCon(string iomFilename, string templateFileName, bool isHiddenCalculation)
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

			if (!string.IsNullOrEmpty(importSettingsTextBox.Text))
			{
				importSettingsStream = new System.IO.MemoryStream();
				var encoding = new System.Text.UnicodeEncoding();
				importSettingsStream.Write(encoding.GetBytes(importSettingsTextBox.Text), 0, encoding.GetByteCount(importSettingsTextBox.Text));
				importSettingsStream.Flush();
				importSettingsStream.Seek(0, SeekOrigin.Begin);
			}

			if (dynLinkLazy.Value != null)
			{
				if (!isHiddenCalculation)
				{
					dynLinkLazy.Value.OpenIdeaConnection(fs, fsr, connProjectStream, connTemplateStream, importSettingsStream, true);
				}
				else
				{
					dynLinkLazy.Value.RunHiddenAnalysis(fs, fsr, connProjectStream, connTemplateStream, importSettingsStream, true);
					if (!dynLinkLazy.Value.IsProjectCalculated())
					{
						this.resultBrowser.NavigateToString("Results doesn't exist");
						return;
					}

					string conCheckResFilename = dynLinkLazy.Value.GetCheckResultsFilename();
					this.resultBrowser.Navigate(conCheckResFilename);
				}

				OnProjOpened();
			}
		}
	}
}