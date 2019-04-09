using IdeaRS.OpenModel.Message;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;

namespace IOM_IDEAConnectionRunnerTestApp
{


	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private string IDEA_InstallDir;
		private string my_ideaIOMFileName = null;
		public MainWindow()
		{

			IDEA_InstallDir = IOM_IDEAConnectionRunnerTestApp.Properties.Settings.Default.IdeaInstallDir;

			InitializeComponent();
			this.iomName.Content = string.Empty;
			this.templateName.Content = string.Empty;

			//this.writeIdeaProjBtn.IsEnabled = false;
			this.showProtocolBtn.IsEnabled = true;
			this.updateIDEABtn01.IsEnabled = false;
			this.updateIDEABtn02.IsEnabled = false;
			//this.writeCheckResultsBtn.IsEnabled = false;
			//this.writeFEAResultsBtn.IsEnabled = false;
			//this.writeProtocolBtn.IsEnabled = false;

			string logFilePath = System.IO.Path.Combine(Environment.GetEnvironmentVariable("TMP", EnvironmentVariableTarget.User), "IdeaConnectionLinkLog.txt");
			if (File.Exists(logFilePath))
			{
				this.logFileLabel.Content = logFilePath;
				this.showLogBtn.IsEnabled = true;
				this.clearLogBtn.IsEnabled = true;
			}
			else
			{
				this.logFileLabel.Content = string.Empty;
				this.showLogBtn.IsEnabled = false;
				this.clearLogBtn.IsEnabled = false;
			}

			var assembly = Assembly.GetExecutingAssembly();
			using (Stream stream = assembly.GetManifestResourceStream("IOM_IDEAConnectionRunnerTestApp.IdeaConImportSettings.xml"))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					importSettingsTextBox.Text = reader.ReadToEnd();
				}
			}
		}

		private void OnSelectConnectionBtnClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".ideaCon"; // Default file extension
			dlg.Filter = "Idea Connection File (.ideaCon)|*.ideaCon"; // Filter files by extension

			// Show open file dialog box
			Nullable<bool> result = dlg.ShowDialog();

			// Process open file dialog box results
			if (result != true)
			{
				this.iomName.Content = string.Empty;
				this.selectIOMBtn.IsEnabled = true;
				this.openInIdeaConnection.IsEnabled = false;
				return;
			}

			// Open document
			string filename = dlg.FileName;
			this.iomName.Content = filename;
			this.openInIdeaConnection.IsEnabled = true;

			UpdateButtons();
		}

		private void OnSelectIOMBtnClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".xml"; // Default file extension
			dlg.Filter = "Idea IOM xml (.xml)|*.xml"; // Filter files by extension

			// Show open file dialog box
			Nullable<bool> result = dlg.ShowDialog();

			// Process open file dialog box results
			if (result != true)
			{
				this.iomName.Content = string.Empty;
				this.selectIOMBtn.IsEnabled = true;
				this.openInIdeaConnection.IsEnabled = false;
				return;
			}

			// Open document
			string filename = dlg.FileName;
			this.iomName.Content = filename;
			this.openInIdeaConnection.IsEnabled = true;

			UpdateButtons();
		}

		private void OnSelectTempleteBtnClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".contemp"; // Default file extension
			dlg.Filter = "Connection Template|*.contemp|Connection Project|*.ideacon"; // Filter files by extension

			// Show open file dialog box
			Nullable<bool> result = dlg.ShowDialog();

			// Process open file dialog box results
			if (result != true)
			{
				this.templateName.Content = string.Empty;
				this.selectIOMBtn.IsEnabled = true;
				return;
			}

			// Open document
			string filename = dlg.FileName;
			this.templateName.Content = filename;

			UpdateButtons();
		}


		public void CreateIOM(IIOMSettings structuralSettings, IDEAProgress progress)
		{
			var generator = new IOMGenerator4();

			char[] charsToTrim = { ',', '.', ' ' };
			string sourceProjectPath = System.IO.Path.GetDirectoryName(structuralSettings.FileName);
			string projectName = System.IO.Path.GetFileNameWithoutExtension(structuralSettings.FileName).TrimEnd(charsToTrim);
			string myprojectName = sourceProjectPath + "\\" + projectName + ".xml";

			structuralSettings.FileName = generator.CreateIOMTst(myprojectName);
			structuralSettings.CreatedSuccessfully = true;
			//return true;
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);

			Properties.Settings.Default.Save();
		}

		private void OnProjOpened()
		{
			this.selectIOMBtn.IsEnabled = false;
			//this.writeIdeaProjBtn.IsEnabled = true;
			this.showProtocolBtn.IsEnabled = true;
			this.updateIDEABtn01.IsEnabled = true;
			this.updateIDEABtn02.IsEnabled = true;
			//this.writeCheckResultsBtn.IsEnabled = true;
			//this.writeFEAResultsBtn.IsEnabled = true;
			//this.writeProtocolBtn.IsEnabled = true;
		}


		private void BatchHiddenCalulation()
		{
			Type conLinkType = Type.GetType("IdeaRS.ConnectionLink.ConnectionLink,IdeaRS.ConnectionLink");

			using (IDisposable dipObj = Activator.CreateInstance(conLinkType) as IDisposable)
			{
				string iomFileName = string.Empty;

				dynamic dynObj = dipObj;
				Stream outProjStream = null;

				FileStream iom = new FileStream(iomFileName, FileMode.Open, FileAccess.Read);
				FileStream iomResults = null;

				string filenameRes = iomFileName + "R";
				if (System.IO.File.Exists(filenameRes))
				{
					iomResults = new FileStream(filenameRes, FileMode.Open, FileAccess.Read);
				}

				dynObj.WriteProjectData(outProjStream);
			}
		}

		private void RunIdeaConnection_Click(object sender, RoutedEventArgs e)
		{
			if (this.iomName.Content == null)
			{
				return;
			}

			string iomFileName = this.iomName.Content.ToString();
			if (string.IsNullOrEmpty(iomFileName))
			{
				return;
			}

			string templateFileName = null;
			if (this.templateName.Content != null)
			{
				templateFileName = this.templateName.Content.ToString();
			}
#if !DEBUG
			try
#endif
			{
				this.selectIOMBtn.IsEnabled = false;
				this.selectTempleteBtn.IsEnabled = false;
				this.openInIdeaConnection.IsEnabled = false;
				//this.runHiddenCalcBtn.IsEnabled = false;

				var fe = sender as FrameworkElement;
				bool isHidden = (fe != null && fe.Tag != null && fe.Tag.ToString().Equals("RunCalcHidden", StringComparison.InvariantCultureIgnoreCase)) ? true : false;
				OpenIOMInIdeaCon(iomFileName, templateFileName, isHidden);
				my_ideaIOMFileName = iomFileName;
			}
#if !DEBUG
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
				return;
			}
#endif
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void showLogBtn_Click(object sender, RoutedEventArgs e)
		{
			using (Process proc = new Process())
			{
				ProcessStartInfo psi = new ProcessStartInfo(this.logFileLabel.Content.ToString());
				proc.StartInfo = psi;
				proc.Start();
			}
		}

		private void clearLogBtn_Click(object sender, RoutedEventArgs e)
		{
			var logPath = this.logFileLabel.Content.ToString();
			if (!string.IsNullOrEmpty(logPath) && File.Exists(logPath))
				File.WriteAllText(logPath, string.Empty);
		}

		private void UpdateButtons()
		{
			//if (!(string.IsNullOrEmpty(this.iomName.Content.ToString()) || string.IsNullOrEmpty(this.templateName.Content.ToString())))
			//{
			//	this.runHiddenCalcBtn.IsEnabled = true;
			//}
			//else
			//{
			//	this.runHiddenCalcBtn.IsEnabled = false;
			//}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string ideaIOMFileName = string.Empty;
			if (Btn1.IsChecked == true)
			{
				var generator = new IOMGenerator();
				ideaIOMFileName = generator.CreateIOMTst();
			}
			else if (Btn2.IsChecked == true)
			{
				var generator = new IOMGenerator2();
				ideaIOMFileName = generator.CreateIOMTst();
			}
			else if (Btn3.IsChecked == true)
			{
				var generator = new IOMGenerator3();
				ideaIOMFileName = generator.CreateIOMTst();
			}
			else if (Btn4.IsChecked == true)
			{
				var generator = new IOMGenerator4();
				ideaIOMFileName = generator.CreateIOMTst(null);
			}

			if (ideaIOMFileName != null && ideaIOMFileName != string.Empty)
			{
				OpenIOMInIdeaCon(ideaIOMFileName, null, false);
				my_ideaIOMFileName = ideaIOMFileName;
				OnProjOpened();
			}
		}

		private void UpdateIDEAConnection_Click(object sender, RoutedEventArgs e)
		{
			string ideaIOMFileName = OpenXMLFileName();
			UpdateIOMInIdeaCon(ideaIOMFileName, null, false);
			OnProjOpened();
		}
		private static string GetXMLFileName()
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = ".xml"; // Default file extension
			dlg.Filter = "IOM file name (.xml)|*.xml"; // Filter files by extension
			dlg.CheckPathExists = true;

			if (dlg.ShowDialog() != true)
			{
				return null;
			}

			return dlg.FileName;
		}

		private static string OpenXMLFileName()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".xml"; // Default file extension
			dlg.Filter = "IOM file name (.xml)|*.xml"; // Filter files by extension
			dlg.CheckPathExists = true;
			if (dlg.ShowDialog() != true)
			{
				return null;
			}

			return dlg.FileName;
		}

		private void CSS_Click_Test(object sender, RoutedEventArgs e)
		{
			string iomFileName = this.iomName.Content.ToString();
			if (string.IsNullOrEmpty(iomFileName))
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.DefaultExt = ".txt"; // Default file extension
				dlg.Filter = "Idea txt (.txt)|*.txt"; // Filter files by extension
				Nullable<bool> result = dlg.ShowDialog();
				if (result != true)
				{
					return;
				}
				iomFileName = dlg.FileName;
			}
			string outDir = System.IO.Path.GetDirectoryName(iomFileName);
			string fileNoExt = Path.GetFileNameWithoutExtension(iomFileName);

			string filename = System.IO.Path.Combine(outDir, fileNoExt);
			if (string.IsNullOrEmpty(filename))
			{
				return;
			}
			if (string.IsNullOrEmpty(ListCss.Text))
			{
				return;
			}
#if DEBUG
			string fileINI = GenerateTestCSSFile(filename);
			StartConnectionProcess(fileINI);
#else
			dynamic connectionLink;
			string ideaInstallDir = IDEA_InstallDir;
			string ideaConLinkFullPath = System.IO.Path.Combine(ideaInstallDir, "IdeaRS.ConnectionLink.dll");
			var conLinkAssembly = Assembly.LoadFrom(ideaConLinkFullPath);

			object obj = conLinkAssembly.CreateInstance("IdeaRS.ConnectionLink.ConnectionLink");
			Debug.Assert(obj != null);
			connectionLink = obj;
			IList<string> notValidNames;
			List<string> testedNames = new List<string>();
			testedNames.Add("IPE240");
			testedNames.Add("IPE240B");
			testedNames.Add("IPE280Q");

			connectionLink.TestValidCSSInIDEADatabase(testedNames, out notValidNames);
			connectionLink.Dispose();
			connectionLink = null;

#endif

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
		private string GenerateTestCSSFile(string filename)
		{
			string outDir = System.IO.Path.GetDirectoryName(filename);
			string fileNoExt = Path.GetFileNameWithoutExtension(filename);
			string fileINI = System.IO.Path.Combine(outDir, fileNoExt + ".ini");
			string fileCSS = System.IO.Path.Combine(outDir, fileNoExt + ".css");
			string fileOUT = System.IO.Path.Combine(outDir, fileNoExt + ".txt");
			//; updateproject - update of existing project; newproject - new project; protocol - html report; test - test of conversion
			List<string> sb = new List<string>();
			string ss = string.Format("SETTINGS;CSSTEST"); sb.Add(ss);
			ss = string.Format("OUTPUTFILE;{0}", fileOUT); sb.Add(ss);
			ss = string.Format("IOM;{0}", fileCSS); sb.Add(ss);
			File.WriteAllLines(fileINI, sb.ToArray(), Encoding.Unicode);

			List<string> sbcss = new List<string>();
			File.WriteAllText(fileCSS, ListCss.Text, Encoding.Unicode);


			return fileINI;
		}



	}
}
