// This is the main DLL file.

#include "stdafx.h"

#include "IDEA_Caller.h"
//#using "..\\Debug\\StartIDEAfromCpp.dll"

// This is the main DLL file.


// Utilities for Native<>CLI conversions
#include <vcclr.h>
//#include "..\\StartIDEAfromCpp\\StartIDEAfromCpp.h"


using namespace System;
using namespace System::Reflection;
using namespace System::Diagnostics;
using namespace System::IO;
//using namespace System::Windows::Forms;
using namespace System::Text;
//using namespace IDEARS;
//
//namespace IDEARS {
//namespace IOM_N {


	IDEA_Caller::IDEA_Caller(string ideaInstallDir)
	{
		//MessageBox::Show("IOM #1", "Debug", MessageBoxButtons::OK, MessageBoxIcon::Information);
		//this->m_pConnectionLink = nullptr;
		//this->ideaInstallDir = ideaInstallDir;
		this->m_pOpenModel = false;
		this->ideaInstallDir = ideaInstallDir;
		//ConnectionLink létrehozása az IdeaRS.ConnectionLink.dll betöltésével
	};

	IDEA_Caller::~IDEA_Caller()
	{
		if (this->m_pOpenModel)
		{
			// Get the CLR handle wrapper
			//gcroot<Object^> *pIOM =  static_cast<gcroot<Object^>*>(this->m_pOpenModel);
			// Delete the wrapper; this will release the underlying CLR instance
			//delete pIOM;
			// Set to null
			this->m_pOpenModel = false;
		}
	}

	unsigned int IDEA_Caller::StartIDEA(IMKPAppDataPtr pMKPData)
	{
		String^ myideaInstallDir = gcnew String(ideaInstallDir.c_str());
		String^ pszFilePath = gcnew String("C:\\Temp\\Test.xml");

		IDEARS::IOM_Wrapper^ wrapper = gcnew IDEARS::IOM_Wrapper(pszFilePath);
		
		// Create IOM Data and store in "C:\\Temp\\Test.xml"
		wrapper->CreateIDEAOpenModel((void*)pMKPData);
		delete wrapper;

		// IDEA StatiCa Connection will be opened
		IDEARS::IDEAConnectionStart^ run = gcnew IDEARS::IDEAConnectionStart();
		run->Run(myideaInstallDir, pszFilePath);
		delete run;


		return 0;
	}


//}
