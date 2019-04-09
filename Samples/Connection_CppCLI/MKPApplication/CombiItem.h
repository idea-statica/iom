// CombiItem.h : Declaration of the CCombiItem

#pragma once
#include "resource.h"       // main symbols



#include "MKPApplication_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CCombiItem

class ATL_NO_VTABLE CCombiItem :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCombiItem, &CLSID_CombiItem>,
	public IDispatchImpl<ICombiItem, &IID_ICombiItem, &LIBID_MKPApplicationLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CCombiItem()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_COMBIITEM)


BEGIN_COM_MAP(CCombiItem)
	COM_INTERFACE_ENTRY(ICombiItem)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()


	ILoadCase *m_LoadCase;
	double m_coeff;
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:

	HRESULT STDMETHODCALLTYPE put_LoadCase(  /* [in] */ ILoadCase* Val) { m_LoadCase = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_LoadCase( /* [retval][out] */ ILoadCase **pVal) { *pVal = m_LoadCase; return S_OK;}

	HRESULT STDMETHODCALLTYPE get_Coeff( /* [retval][out] */ double *pVal) { *pVal =  m_coeff; return S_OK;}
	HRESULT STDMETHODCALLTYPE put_Coeff( double pVal) { m_coeff = pVal ; return S_OK;}


};

OBJECT_ENTRY_AUTO(__uuidof(CombiItem), CCombiItem)
