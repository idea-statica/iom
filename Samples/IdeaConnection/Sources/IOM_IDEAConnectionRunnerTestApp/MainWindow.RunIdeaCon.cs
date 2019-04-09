using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace IOM_IDEAConnectionRunnerTestApp
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
			string outDir = System.IO.Path.GetDirectoryName(iomFilename);
			string fileNoExt = Path.GetFileNameWithoutExtension(iomFilename);

			string filename = System.IO.Path.Combine(outDir, fileNoExt + ".ideaCon");
			if (string.IsNullOrEmpty(filename))
			{
				return;
			}
			string fileINI = GenerateSettinsFile("newproject", filename, null);
			StartConnectionProcess(fileINI);
			OnProjOpened();
		}

		private void UpdateIOMInIdeaCon(string iomFilename, string templateFileName, bool isHiddenCalculation)
		{
			if (string.IsNullOrEmpty(iomFilename))
			{
				return;
			}

			if (string.IsNullOrEmpty(my_ideaIOMFileName))
			{
				MessageBox.Show("You have to open IOM file or generate IOM", "Error", MessageBoxButton.OK);
				return;
			}
			string outDir = System.IO.Path.GetDirectoryName(iomFilename);
			string fileNoExt = Path.GetFileNameWithoutExtension(iomFilename);

			string filename = System.IO.Path.Combine(outDir, fileNoExt + ".ideaCon");
			if (string.IsNullOrEmpty(filename))
			{
				return;
			}
			string outDirUpd = System.IO.Path.GetDirectoryName(my_ideaIOMFileName);
			string fileNoExtUpd = Path.GetFileNameWithoutExtension(my_ideaIOMFileName);
			string filenameUpd = System.IO.Path.Combine(outDirUpd, fileNoExtUpd + ".ideaCon");

			string fileINI = GenerateSettinsFile("updateproject", filename, filenameUpd);
			StartConnectionProcess(fileINI);
			OnProjOpened();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="action"> There can be : 
		/// updateproject
		/// newproject
		/// protocol</param>
		/// <param name="filename"></param>
		/// <param name="filenameIdeaConUpdate"></param>
		/// <returns></returns>
		private string GenerateSettinsFile(string action, string filename, string filenameIdeaConUpdate)
		{
			string outDir = System.IO.Path.GetDirectoryName(filename);
			string fileNoExt = Path.GetFileNameWithoutExtension(filename);
			string fileINI = System.IO.Path.Combine(outDir, fileNoExt + ".ini");
			string fileXML = System.IO.Path.Combine(outDir, fileNoExt + ".xml");
			//; updateproject - update of existing project; newproject - new project; protocol - html report; test - test of conversion
			List<string> sb = new List<string>();
			string ss = string.Format("//; updateproject - update of existing project; newproject - new project; protocol - html report; test - test of conversion"); sb.Add(ss);
			ss = string.Format("SETTINGS;{0}", action); sb.Add(ss);
			if (!string.IsNullOrEmpty(filenameIdeaConUpdate))
			{
				ss = string.Format("OUTPUTFILE;{0}", filenameIdeaConUpdate); sb.Add(ss);
			}
			else
			{
				ss = string.Format("OUTPUTFILE;{0}", filename); sb.Add(ss);
			}
			ss = string.Format("USEWIZARD;TRUE"); sb.Add(ss);
			ss = string.Format("DESIGNCODE;ECEN"); sb.Add(ss);  // AICS, CISC
			ss = string.Format("WAITFOREXIT;TRUE"); sb.Add(ss);
			ss = string.Format("IOM;{0}", fileXML); sb.Add(ss);
			File.WriteAllLines(fileINI, sb.ToArray(), Encoding.Unicode);
			return fileINI;
		}

	}
}