// Combination.h : Declaration of the CCombination

#pragma once
#include "resource.h"       // main symbols
#include <vector>



#include "MKPApplication_i.h"
#include "CombiItem.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CCombination

class ATL_NO_VTABLE CCombination :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCombination, &CLSID_Combination>,
	public IDispatchImpl<ICombination, &IID_ICombination, &LIBID_MKPApplicationLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CCombination()
	{
		CombiItems = new std::vector<ICombiItem*>();
	}
	int m_Id;
	CString m_Name;
	std::vector<ICombiItem*>* CombiItems;

DECLARE_REGISTRY_RESOURCEID(IDR_COMBINATION)


BEGIN_COM_MAP(CCombination)
	COM_INTERFACE_ENTRY(ICombination)
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

	HRESULT STDMETHODCALLTYPE get_NumLoadCases( int* num) 
	{ 
		*num = CombiItems->size();
		return S_OK;
	}
	HRESULT STDMETHODCALLTYPE LoadCase( int at , ILoadCase** lc, double* coeff ) 
	{ 
		ICombiItem* nd = (ICombiItem*)CombiItems->at(at);
		nd->get_LoadCase(lc);
		nd->get_Coeff(coeff);
		return S_OK;
	}

	HRESULT STDMETHODCALLTYPE AddLoadCase( ILoadCase* lc, double coeff ) 
	{ 
		CCombiItem* pC = new CComObject<CCombiItem>;
		pC->m_LoadCase = lc;
		pC->m_coeff = coeff;
		CombiItems->push_back(pC); 
		return S_OK;
	}
};

OBJECT_ENTRY_AUTO(__uuidof(Combination), CCombination)
