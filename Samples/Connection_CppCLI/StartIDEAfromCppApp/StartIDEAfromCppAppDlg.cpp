
// StartIDEAfromCppAppDlg.cpp : implementation file
//

#include "stdafx.h"
#include "StartIDEAfromCppApp.h"
#include "StartIDEAfromCppAppDlg.h"
#include "afxdialogex.h"
#include "IDEA_Caller.h"
#import "..\\MKPApplication\\Debug\\MKPApplication.tlb" named_guids no_namespace

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

/*extern "C" __declspec(dllimport) */
/*
class IOM
{
	// Initialization
	public:	
IOM();
~IOM();

	// Accessors
public:	unsigned int CreateIDEAOpenModel();
public:	void AddMaterialsToOpenModel();
public:	void SaveToFiles(char*  pszFilePath);
public:	void OpenIOMInIdeaCon(char*  pszFilePath);

};
*/
//using namespace IDEARS;
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CStartIDEAfromCppAppDlg dialog



CStartIDEAfromCppAppDlg::CStartIDEAfromCppAppDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CStartIDEAfromCppAppDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CStartIDEAfromCppAppDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CStartIDEAfromCppAppDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CStartIDEAfromCppAppDlg::OnBnClickedButton1)
END_MESSAGE_MAP()


// CStartIDEAfromCppAppDlg message handlers

BOOL CStartIDEAfromCppAppDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CStartIDEAfromCppAppDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CStartIDEAfromCppAppDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CStartIDEAfromCppAppDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CStartIDEAfromCppAppDlg::OnBnClickedButton1()
{
	IDEA_Caller* idea;
	idea = new IDEA_Caller("c:\\Program Files\\IDEAStatiCa\\StatiCa8");

	IMKPAppDataPtr pMKPData(__uuidof(MKPAppData));
	pMKPData->CreateDefault();
	//IMember* pList(__uuidof(Member));//, NULL, CLSCTX_INPROC_SERVER);

	idea->StartIDEA(pMKPData);
	// TODO: Add your control notification handler code here
}
