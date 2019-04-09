// MKPAppData.h : Declaration of the CMKPAppData

#pragma once
#include "resource.h"       // main symbols
#include <vector>



#include "MKPApplication_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CMKPAppData

class ATL_NO_VTABLE CMKPAppData :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CMKPAppData, &CLSID_MKPAppData>,
	public IDispatchImpl<IMKPAppData, &IID_IMKPAppData, &LIBID_MKPApplicationLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CMKPAppData()
	{
		Nodes = new std::vector<INode*>();
		Members = new std::vector<IMember*>();
		LoadGroups = new std::vector<ILoadGroup*>();
		LoadCases = new std::vector<ILoadCase*>();
		Combinations = new std::vector<ICombination*>();
		CrossSections = new std::vector<ICrossSection*>();
	}
private :
	std::vector<INode*>* Nodes;
	std::vector<IMember*>* Members;
	std::vector<ILoadGroup*>* LoadGroups;
	std::vector<ILoadCase*>* LoadCases;
	std::vector<ICombination*>* Combinations;
	std::vector<ICrossSection*>* CrossSections;

public:

DECLARE_REGISTRY_RESOURCEID(IDR_MKPAPPDATA)


BEGIN_COM_MAP(CMKPAppData)
	COM_INTERFACE_ENTRY(IMKPAppData)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
		if (Members != NULL) delete Members;
		if (Nodes != NULL) delete Nodes;
	}

public:
	HRESULT STDMETHODCALLTYPE CreateDefault();

	HRESULT STDMETHODCALLTYPE get_NumNodes( /* [retval][out] */ int *num);
	HRESULT STDMETHODCALLTYPE get_NumMembers( /* [retval][out] */ int *num);
	HRESULT STDMETHODCALLTYPE get_NumLoadCases( /* [retval][out] */ int *num);
	HRESULT STDMETHODCALLTYPE get_NumLoadGroups( /* [retval][out] */ int *num);
	HRESULT STDMETHODCALLTYPE get_NumCombinations( /* [retval][out] */ int *num);
	HRESULT STDMETHODCALLTYPE get_Node( int id, /* [retval][out] */ INode **pVal);
	HRESULT STDMETHODCALLTYPE get_Member( int id, /* [retval][out] */ IMember **pVal);
	HRESULT STDMETHODCALLTYPE get_LoadCase( int id, /* [retval][out] */ ILoadCase **pVal);
	HRESULT STDMETHODCALLTYPE get_LoadGroup( int id, /* [retval][out] */ ILoadGroup **pVal);
	HRESULT STDMETHODCALLTYPE get_Combination( int id, /* [retval][out] */ ICombination **pVal);
	HRESULT STDMETHODCALLTYPE get_NumCrossSections( /* [retval][out] */ int *num);
	HRESULT STDMETHODCALLTYPE get_CrossSection( int id, /* [retval][out] */ ICrossSection **pVal);


};

OBJECT_ENTRY_AUTO(__uuidof(MKPAppData), CMKPAppData)
