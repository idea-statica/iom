using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ConnectionLinkTestApp
{
	public partial class MainWindow
	{
		private void showProtocolBtn_Click(object sender, RoutedEventArgs e)
		{
			string protocolArchiveName = string.Empty;
			try
			{
				object obj = this.dynLinkLazy.Value.GetProtocolArchive();

				if (obj == null)
				{
					MessageBox.Show("Report was not generated", "Error", MessageBoxButton.OK);
					return;
				}

				// Create dialog and shows generated report
				protocolArchiveName = obj.ToString();
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

		private void writeProtocolBtn_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = ".zip"; // Default file extension
			dlg.Filter = "Connection protocol archive (.zip)|*.zip"; // Filter files by extension
			dlg.CheckPathExists = true;

			if (dlg.ShowDialog() != true)
			{
				return;
			}

			using (Stream outStream = dlg.OpenFile())
			{
				this.dynLinkLazy.Value.WriteProtocolArchive(outStream);
				outStream.Close();
			}
		}
	}
}