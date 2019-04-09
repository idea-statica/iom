// StartIDEAfromCpp.h

#pragma once

#import "..\\MKPApplication\\Debug\\MKPApplication.tlb" named_guids no_namespace
//#using "..\\MKPApplication\\Debug\\MKPApplication.dll" as_friend

using namespace System;
using namespace IdeaRS::OpenModel;
using namespace IdeaRS::OpenModel::Message;
using namespace IdeaRS::OpenModel::Connection;
using namespace IdeaRS::OpenModel::CrossSection;
using namespace IdeaRS::OpenModel::Geometry3D;
using namespace IdeaRS::OpenModel::Loading;
using namespace IdeaRS::OpenModel::Material;
using namespace IdeaRS::OpenModel::Model;
using namespace IdeaRS::OpenModel::Result;

//#ifdef NATIVEDLL_EXPORTS
//#define NATIVE_IOM_API __declspec(dllexport)
//#else
//#define NATIVE_IOM_API __declspec(dllimport)
//#endif
//#include <msclr/auto_gcroot.h>
#include <string>
using namespace std;

#ifdef _UNICODE
typedef wstring tstring;
#else
typedef string tstring;
#endif

namespace IDEARS {

	public ref class IOM_Wrapper
	{
		// Initialization
	public: IOM_Wrapper(String^ IOMfile);
	public:	~IOM_Wrapper();

					//public:	void SetIDEADir(System::String^ ideaInstallDir);
					// Accessors
					//public:	int CreateIDEAOpenModel();
	public:	int CreateIDEAOpenModel(void* pMKPData);
					//public:	void SaveToFiles(System::String^ pszFilePath);
					//public:	void OpenIOMInIdeaCon(System::String^ pszFilePath);

					//unsigned int get_Age() const;
					//tstring get_BirthDateStr() const;
					//msclr::auto_gcroot<Foo^> m_foo;
	private:

		int CreateMembersIOM();
		int CreateCrossSectionsIOM();
		int CreateMaterialIOM();
		int CreateNodesIOM();
		int CreateLoadGroupsIOM();
		int CreateLoadCasesIOM();
		int CreateCombinationsIOM();

		int CreateConnectionPointIOM();

		int CreateIDEAOpenModelResults();

		//void* m_pOpenModel;
		//void* m_pOpenModelResult;	//A csomópont igénybevételei
		String^ IOMfile;

		IMKPAppData *data;
		OpenModel^ openStructModel;
		OpenModelResult^ openStructModelR;
		//Object^ m_pConnectionLink;	//Az IDEA Connection program meghívása
	};
}
