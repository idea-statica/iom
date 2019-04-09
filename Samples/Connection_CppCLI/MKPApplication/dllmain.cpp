// dllmain.cpp : Implementation of DllMain.

#include "stdafx.h"
#include "resource.h"
#include "MKPApplication_i.h"
#include "dllmain.h"

CMKPApplicationModule _AtlModule;

class CMKPApplicationApp : public CWinApp
{
public:

// Overrides
	virtual BOOL InitInstance();
	virtual int ExitInstance();

	DECLARE_MESSAGE_MAP()
};

BEGIN_MESSAGE_MAP(CMKPApplicationApp, CWinApp)
END_MESSAGE_MAP()

CMKPApplicationApp theApp;

BOOL CMKPApplicationApp::InitInstance()
{
	return CWinApp::InitInstance();
}

int CMKPApplicationApp::ExitInstance()
{
	return CWinApp::ExitInstance();
}
