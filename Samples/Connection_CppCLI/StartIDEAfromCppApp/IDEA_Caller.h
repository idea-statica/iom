// StartIDEAfromCpp.h

#pragma once

//using namespace System;
//#include <msclr/auto_gcroot.h>

#include <string>
using namespace std;

#import "..\\MKPApplication\\Debug\\MKPApplication.tlb" named_guids no_namespace

#ifdef _UNICODE
typedef wstring tstring;
#else
typedef string tstring;
#endif

//namespace IDEARS {//#pragma unmanaged
class IDEA_Caller
{
			// Initialization
		public: IDEA_Caller(string ideaInstallDir);
		public:	~IDEA_Caller();

						// Accessors
		public:	unsigned int StartIDEA(IMKPAppDataPtr pMKPData);

						//unsigned int get_Age() const;
						//tstring get_BirthDateStr() const;
						//msclr::auto_gcroot<Foo^> m_foo;
		private:
			//void* m_pOpenModel;
			bool m_pOpenModel;
			string ideaInstallDir;
};
//}
//#pragma managed
