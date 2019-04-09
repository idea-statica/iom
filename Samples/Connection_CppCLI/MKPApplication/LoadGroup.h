// LoadGroup.h : Declaration of the CLoadGroup

#pragma once
#include "resource.h"       // main symbols



#include "MKPApplication_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CLoadGroup

class ATL_NO_VTABLE CLoadGroup :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CLoadGroup, &CLSID_LoadGroup>,
	public IDispatchImpl<ILoadGroup, &IID_ILoadGroup, &LIBID_MKPApplicationLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CLoadGroup()
	{
	}

	int m_Id;
	CString m_Name;
	eLoadGroupType m_LoadGroupType;

DECLARE_REGISTRY_RESOURCEID(IDR_LOADGROUP)


BEGIN_COM_MAP(CLoadGroup)
	COM_INTERFACE_ENTRY(ILoadGroup)
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

	HRESULT STDMETHODCALLTYPE get_Name( /* [retval][out] */ BSTR *pVal) { *pVal =  m_Name.AllocSysString(); return S_OK;}
	HRESULT STDMETHODCALLTYPE put_Name( CString pVal) { m_Name = pVal ; return S_OK;}

	HRESULT STDMETHODCALLTYPE put_Type(  /* [in] */ eLoadGroupType Val) { m_LoadGroupType = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_Type( /* [retval][out] */ eLoadGroupType *pVal) { *pVal = m_LoadGroupType; return S_OK;}

};

OBJECT_ENTRY_AUTO(__uuidof(LoadGroup), CLoadGroup)
