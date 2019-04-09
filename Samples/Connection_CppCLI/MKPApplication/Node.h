// Node.h : Declaration of the CNode

#pragma once
#include "resource.h"       // main symbols



#include "MKPApplication_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CNode

class ATL_NO_VTABLE CNode :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CNode, &CLSID_Node>,
	public IDispatchImpl<INode, &IID_INode, &LIBID_MKPApplicationLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CNode()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_NODE)


BEGIN_COM_MAP(CNode)
	COM_INTERFACE_ENTRY(INode)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()

private :
	double m_X;
	double m_Y;
	double m_Z;
	int m_Id;

public:

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

	HRESULT STDMETHODCALLTYPE put_X(  /* [in] */ double Val) { m_X = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_X( /* [retval][out] */ double *pVal) { *pVal = m_X; return S_OK;}
	HRESULT STDMETHODCALLTYPE put_Y(  /* [in] */ double Val) { m_Y = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_Y( /* [retval][out] */ double *pVal) { *pVal = m_Y; return S_OK;}
	HRESULT STDMETHODCALLTYPE put_Z(  /* [in] */ double Val) { m_Z = Val; return S_OK;}
	HRESULT STDMETHODCALLTYPE get_Z( /* [retval][out] */ double *pVal) { *pVal = m_Z; return S_OK;}


};

OBJECT_ENTRY_AUTO(__uuidof(Node), CNode)
