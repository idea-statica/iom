// Member.h : Declaration of the CMember

#pragma once
#include "resource.h"       // main symbols



#include "MKPApplication_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CMember

class ATL_NO_VTABLE CMember :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CMember, &CLSID_Member>,
	public IDispatchImpl<IMember, &IID_IMember, &LIBID_MKPApplicationLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CMember()
	{
	}

private :
	int m_Id;
	int m_BeginNode;
	int m_EndNode;
	int m_CrossSection;

public:
	DECLARE_REGISTRY_RESOURCEID(IDR_MEMBER)


	BEGIN_COM_MAP(CMember)
		COM_INTERFACE_ENTRY(IMember)
		COM_INTERFACE_ENTRY(IDispatch)
	END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:

	HRESULT STDMETHODCALLTYPE put_Id(  /* [in] */ long Val) { m_Id = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_Id( /* [retval][out] */ long *pVal) { *pVal = m_Id; return S_OK;}

	HRESULT STDMETHODCALLTYPE put_BeginNode( /* [in] */ long Val) { m_BeginNode = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_BeginNode( /* [retval][out] */ long *pVal) { *pVal = m_BeginNode; return S_OK;}

	HRESULT STDMETHODCALLTYPE put_EndNode(  /* [in] */ long Val) { m_EndNode = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_EndNode( /* [retval][out] */ long *pVal) { *pVal = m_EndNode; return S_OK;}

	HRESULT STDMETHODCALLTYPE put_CrossSection(  /* [in] */ long Val) { m_CrossSection = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_CrossSection( /* [retval][out] */ long *pVal) { *pVal = m_CrossSection; return S_OK;}


};

OBJECT_ENTRY_AUTO(__uuidof(Member), CMember)
