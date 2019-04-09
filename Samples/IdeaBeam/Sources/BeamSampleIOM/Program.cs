using IdeaRS.OpenModel.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace SampleIOM
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			// Only one parameter with the file name to store an Open Model in the XML format.
			if (args.Length < 1)
			{
				return;
			}

			var outputFilePath = args[0];
			var dir = Path.GetDirectoryName(outputFilePath);
			if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			var sample = new BeamSampleIOM();

			// Gets Open Model structure
			var iom = sample.IOM;
			if (iom != null)
			{
				// Save to file
				iom.SaveToXmlFile(outputFilePath);
			}

			// Gets Open Model Results
			var iomR = sample.IOMResults;
			if (iomR != null)
			{
				// Save to file... add "r" at the end of file name
				iomR.SaveToXmlFile(outputFilePath + "R");
			}
			int myVersion = 2;
			if (myVersion == 1)
			{
				string ideaConLinkFullPath = System.IO.Path.Combine("k:\\IDEA_RS\\SVN\\Deve_Trunk\\_Sources\\bin\\Debug", "IdeaRS.BeamLink.dll");
				var conLinkAssembly = Assembly.LoadFrom(ideaConLinkFullPath);

				object obj = conLinkAssembly.CreateInstance("IdeaRS.BeamLink.BeamLink");
				dynamic d = obj;

				FileStream fs = new FileStream(outputFilePath, FileMode.Open, FileAccess.Read);
				FileStream fsR = new FileStream(outputFilePath+"R", FileMode.Open, FileAccess.Read);
				d.OpenIdeaBeam(fs, fsR, null, true);

			}


			//public void OpenIdeaBeam(Stream iomStream,
			//Stream resultsStream,
			//Stream importSettingsStream,
			//bool closeInputStreams)


			if (myVersion == 2)
			{
				string fileINI = GenerateSettinsFile("newproject", Path.ChangeExtension(outputFilePath,".ideaBeam"));
				StartBeamProcess(fileINI);
			}

		}

		private static void StartBeamProcess(string fileINI)
		{
			using (Process proc = new Process())
			{
				string arguments = string.Format("\"{0}\"", fileINI);
				ProcessStartInfo psi = new ProcessStartInfo(Path.Combine("k:\\IDEA_RS\\SVN\\Deve_Trunk\\_Sources\\bin\\Debug", "IOM_IDEABeamRunner.exe"), arguments);
				proc.StartInfo = psi;
				proc.Start();
				proc.WaitForExit();

				//if (LinkLogger.IsInfoEnabled)
				//{
				//	LinkLogger.Info("IdeaConnection.exe has finished");
				//}
			}
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
			private static  string GenerateSettinsFile(string action, string filename)
		{
			string outDir = System.IO.Path.GetDirectoryName(filename);
			string fileNoExt = Path.GetFileNameWithoutExtension(filename);
			string fileINI = System.IO.Path.Combine(outDir, fileNoExt + ".ini");
			string fileXML = System.IO.Path.Combine(outDir, fileNoExt + ".xml");
			//; updateproject - update of existing project; newproject - new project; protocol - html report; test - test of conversion
			List<string> sb = new List<string>();
			string ss = string.Format("SETTINGS;{0}", action); sb.Add(ss);
			ss = string.Format("OUTPUTFILE;{0}", filename); sb.Add(ss);
			ss = string.Format("USEWIZARD;FALSE"); sb.Add(ss);
			ss = string.Format("WAITFOREXIT;TRUE"); sb.Add(ss);
			ss = string.Format("IOM;{0}", fileXML); sb.Add(ss);
			File.WriteAllLines(fileINI, sb.ToArray(), Encoding.Unicode);
			return fileINI;
		}

	}
}