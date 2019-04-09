using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace IOM_IDEAConnectionRunnerTestApp
{
	public partial class MainWindow
	{
		//private void writeCheckResultsBtn_Click(object sender, RoutedEventArgs e)
		//{
		//	SaveFileDialog dlg = new SaveFileDialog();
		//	dlg.DefaultExt = ".xml"; // Default file extension
		//	dlg.Filter = "Idea Connection Check results (.xml)|*.xml"; // Filter files by extension
		//	dlg.CheckPathExists = true;

		//	if (dlg.ShowDialog() != true)
		//	{
		//		return;
		//	}

		//	try
		//	{
		//		using (Stream outStream = dlg.OpenFile())
		//		{
		//			this.dynLinkLazy.Value.WriteConCheckResults(outStream);
		//			outStream.Close();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Debug.Assert(false, ex.Message);
		//		MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
		//	}
		//}
	}
}