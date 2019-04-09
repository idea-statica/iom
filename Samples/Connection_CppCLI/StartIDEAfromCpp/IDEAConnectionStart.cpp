#include "stdafx.h"
#include "IDEAConnectionStart.h"

namespace IDEARS {

	IDEAConnectionStart::IDEAConnectionStart(void)
	{
	}

	IDEAConnectionStart::~IDEAConnectionStart()
	{
	}

	void IDEAConnectionStart::Run(String^ ideaInstallDir, String^ pszFilePath)
	{
		//MessageBox::Show("OpenIOMInIdeaCon #1", "Debug", MessageBoxButtons::OK, MessageBoxIcon::Information);
		RunIDEAConnection::RunIDEAConnection^ runIDEAConnection = gcnew RunIDEAConnection::RunIDEAConnection(ideaInstallDir);
		bool isHiddenCalculation = false;
		String^ templateFileName;
		// IDEA StatiCa Connection will be opened in C# dll
		runIDEAConnection->OpenIOMInIdeaCon(pszFilePath, templateFileName, isHiddenCalculation);
	}
}