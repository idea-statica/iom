using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace IOM_IDEAConnectionRunnerTestApp
{
	public partial class MainWindow
	{
		private void showProtocolBtn_Click(object sender, RoutedEventArgs e)
		{
			string protocolArchiveName = string.Empty;
			try
			{

				string filename = GetConnectionFileNameOpen();
				if (string.IsNullOrEmpty(filename))
				{
					return;
				}
				string fileINI = GenerateSettinsFile("protocol", filename, null);
				StartConnectionProcess(fileINI);
				string outDir = System.IO.Path.GetDirectoryName(filename);
				string fileNoExt = Path.GetFileNameWithoutExtension(filename);
				protocolArchiveName = System.IO.Path.Combine(outDir, fileNoExt + ".zip");

				//object obj = this.dynLinkLazy.Value.GetProtocolArchive();

				//if (obj == null)
				//{
				//	MessageBox.Show("Report was not generated", "Error", MessageBoxButton.OK);
				//	return;
				//}

				// Create dialog and shows generated report
				//protocolArchiveName = obj.ToString();
				var dlg = new ProtocolWindow(protocolArchiveName);
				dlg.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
				return;
			}
			finally
			{
				try
				{
					string dirPath = System.IO.Path.GetDirectoryName(protocolArchiveName);
					string dirName = System.IO.Path.GetFileNameWithoutExtension(protocolArchiveName);

					string reportDir = System.IO.Path.Combine(dirPath, dirName);
					if (Directory.Exists(reportDir))
					{
						Directory.Delete(reportDir, true);
					}
				}
				catch (Exception ex)
				{
					Debug.Assert(false, ex.Message);
				}
			}
		}

		private void StartConnectionProcess(string fileINI)
		{
			using (Process proc = new Process())
			{
				string arguments = string.Format("\"{0}\"", fileINI);
				ProcessStartInfo psi = new ProcessStartInfo(Path.Combine(IDEA_InstallDir, "IOM_IDEAConnectionRunner.exe"), arguments);
				proc.StartInfo = psi;
				proc.Start();
				proc.WaitForExit();

				//if (LinkLogger.IsInfoEnabled)
				//{
				//	LinkLogger.Info("IdeaConnection.exe has finished");
				//}
			}
		}

		private static string GetConnectionFileName()
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = ".ideaCon"; // Default file extension
			dlg.Filter = "Idea Connection project (.ideaCon)|*.ideaCon"; // Filter files by extension
			dlg.CheckPathExists = true;

			if (dlg.ShowDialog() != true)
			{
				return null;
			}

			return dlg.FileName;
		}

		private static string GetConnectionFileNameOpen()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".ideaCon"; // Default file extension
			dlg.Filter = "Idea Connection project (.ideaCon)|*.ideaCon"; // Filter files by extension
			dlg.CheckPathExists = true;

			if (dlg.ShowDialog() != true)
			{
				return null;
			}

			return dlg.FileName;
		}

	}
}