using IdeaRS.OpenModel.Message;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace ConnectionLinkTestApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Lazy<dynamic> dynLinkLazy;

		public MainWindow()
		{
			InitializeComponent();

			this.dynLinkLazy = new Lazy<dynamic>(() =>
				{
					string ideaInstallDir = ConnectionLinkTestApp.Properties.Settings.Default.IdeaInstallDir;
					string ideaConLinkFullPath = System.IO.Path.Combine(ideaInstallDir, "IdeaRS.ConnectionLink.dll");
					var conLinkAssembly = Assembly.LoadFrom(ideaConLinkFullPath);

					object obj = conLinkAssembly.CreateInstance("IdeaRS.ConnectionLink.ConnectionLink");
					Debug.Assert(obj != null);
					dynamic d = obj;
					return d;
				});

			this.iomName.Content = string.Empty;
			this.templateName.Content = string.Empty;

			this.writeIdeaProjBtn.IsEnabled = false;
			this.showProtocolBtn.IsEnabled = false;
			this.writeCheckResultsBtn.IsEnabled = false;
			this.writeFEAResultsBtn.IsEnabled = false;
			this.writeProtocolBtn.IsEnabled = false;

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
			using (Stream stream = assembly.GetManifestResourceStream("ConnectionLinkTestApp.IdeaConImportSettings.xml"))
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

		private void Button_Click_CallBack(object sender, RoutedEventArgs e)
		{
			if (dynLinkLazy.Value != null)
			{
				//var myCall = new Action<IIOMSettings , IDEAProgress>(CreateIOM);

				dynLinkLazy.Value.OpenIdeaConnection(new Action<IIOMSettings, IDEAProgress>(CreateIOM));
				OnProjOpened();
			}
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

			if (this.dynLinkLazy != null && this.dynLinkLazy.IsValueCreated && this.dynLinkLazy.Value != null)
			{
				this.dynLinkLazy.Value.Dispose();
				this.dynLinkLazy = null;
			}

			Properties.Settings.Default.Save();
		}

		private void OnProjOpened()
		{
			this.selectIOMBtn.IsEnabled = false;
			this.writeIdeaProjBtn.IsEnabled = true;
			this.showProtocolBtn.IsEnabled = true;
			this.writeCheckResultsBtn.IsEnabled = true;
			this.writeFEAResultsBtn.IsEnabled = true;
			this.writeProtocolBtn.IsEnabled = true;
		}

		private void writeIdeaProjBtn_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = ".ideaCon"; // Default file extension
			dlg.Filter = "Idea Connection project (.ideaCon)|*.ideaCon"; // Filter files by extension
			dlg.CheckPathExists = true;

			if (dlg.ShowDialog() != true)
			{
				return;
			}

			using (Stream outStream = dlg.OpenFile())
			{
				this.dynLinkLazy.Value.WriteProjectData(outStream);
				outStream.Close();
			}
		}

		private void writeFEAResultsBtn_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = ".ideaCon"; // Default file extension
			dlg.Filter = "Idea Connection FEA results (.ideaCon.Archiv)|*.ideaCon.Archiv"; // Filter files by extension
			dlg.CheckPathExists = true;

			if (dlg.ShowDialog() != true)
			{
				return;
			}

			using (Stream outStream = dlg.OpenFile())
			{
				this.dynLinkLazy.Value.WriteFEAResultsArchive(outStream);
				outStream.Close();
			}
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
			else if (Btn5.IsChecked == true)
			{
				var generator = new IOMGenerator5();
				ideaIOMFileName = generator.CreateIOMTst(null);
			}

			if (ideaIOMFileName != null && ideaIOMFileName != string.Empty)
			{
				OpenIOMInIdeaCon(ideaIOMFileName, null, false);
				OnProjOpened();
			}
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
				this.runHiddenCalcBtn.IsEnabled = false;

				var fe = sender as FrameworkElement;
				bool isHidden = (fe != null && fe.Tag != null && fe.Tag.ToString().Equals("RunCalcHidden", StringComparison.InvariantCultureIgnoreCase)) ? true : false;
				OpenIOMInIdeaCon(iomFileName, templateFileName, isHidden);
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
			if (!(string.IsNullOrEmpty(this.iomName.Content.ToString()) || string.IsNullOrEmpty(this.templateName.Content.ToString())))
			{
				this.runHiddenCalcBtn.IsEnabled = true;
			}
			else
			{
				this.runHiddenCalcBtn.IsEnabled = false;
			}
		}
	}
}