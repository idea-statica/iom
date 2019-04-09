#pragma once
using namespace System;

#include <string>
using namespace std;

#ifdef _UNICODE
typedef wstring tstring;
#else
typedef string tstring;
#endif


namespace IDEARS {
	public ref class IDEAConnectionStart
	{
	public:
		IDEAConnectionStart(void);
		~IDEAConnectionStart();


		void Run(String^ ideaInstallDir, String^ pszFilePath);

	};
}

