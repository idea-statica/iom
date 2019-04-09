// MKPAppData.cpp : Implementation of CMKPAppData

#include "stdafx.h"
#include "MKPAppData.h"
#include "node.h"
#include "member.h"
#include "CrossSection.h"
#include "loadgroup.h"
#include "loadcase.h"
#include "combination.h"

//#include <atlstr.h>             // CString
//#include <atlcomcli.h>          // CComVariant
//#include <atlsafe.h>            // CComSafeArray
//
// CMKPAppData


HRESULT STDMETHODCALLTYPE CMKPAppData::CreateDefault()
{
	// Initialize COM.
	HRESULT hr = CoInitialize(NULL);
	
	CNode* pNode = new CComObject<CNode>;
	pNode->put_Id(1);
	pNode->put_X(0.0);
	pNode->put_Y(0.0);
	pNode->put_Z(0.0);
	Nodes->push_back(pNode);

	pNode = new CComObject<CNode>;
	pNode->put_Id(2);
	pNode->put_X(0.0);
	pNode->put_Y(0.0);
	pNode->put_Z(3.0);
	Nodes->push_back(pNode);

	pNode = new CComObject<CNode>;
	pNode->put_Id(3);
	pNode->put_X(4.0);
	pNode->put_Y(0.0);
	pNode->put_Z(3.0);
	Nodes->push_back(pNode);

	CCrossSection* css= new CComObject<CCrossSection>;
	css->put_Id(1);
	css->put_Name(_T("IPE300"));
	CrossSections->push_back(css);

	CMember* pMember = new CComObject<CMember>;
	pMember->put_Id(1);
	pMember->put_BeginNode(1);
	pMember->put_EndNode(2);
	pMember->put_CrossSection(1);
	Members->push_back(pMember);

	
	pMember = new CComObject<CMember>;
	pMember->put_Id(2);
	pMember->put_BeginNode(2);
	pMember->put_EndNode(3);
	pMember->put_CrossSection(1);
	Members->push_back(pMember);


	CLoadGroup* pLG = new CComObject<CLoadGroup>;
	pLG->put_Id(1);
	pLG->put_Type(eLoadGroupType::ePermanent);
	pLG->put_Name(_T("LG1"));
	LoadGroups->push_back(pLG);

	CLoadCase* pLC = new CComObject<CLoadCase>;
	pLC->put_Id(1);
	pLC->put_Name(_T("LC1"));
	LoadCases->push_back(pLC);

	CCombination* pC = new CComObject<CCombination>;
	pC->put_Id(1);
	pC->AddLoadCase(pLC, 1.35);
	Combinations->push_back(pC);
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_NumCrossSections( /* [retval][out] */ int *num)
{ 
	*num = CrossSections->size();
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_CrossSection( int id, /* [retval][out] */ ICrossSection **pVal)
{
	// Check pointer parameter
	if ( pVal == NULL )
		return E_POINTER;

	*pVal = NULL;

	// Result of operations
	HRESULT hr = S_OK;

	ICrossSection* mb = (ICrossSection*)CrossSections->at(id);
	*pVal = mb;

	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_NumNodes(/* [retval][out] */ int *num) 
{ 
	*num = Nodes->size();
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_NumMembers(/* [retval][out] */ int *num) 
{ 
	*num = Members->size();
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_NumLoadCases( /* [retval][out] */ int *num)
{ 
	*num = LoadCases->size();
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_NumLoadGroups( /* [retval][out] */ int *num)
{ 
	*num = LoadGroups->size();
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_NumCombinations( /* [retval][out] */ int *num)
{ 
	*num = Combinations->size();
	return S_OK;
}


HRESULT STDMETHODCALLTYPE CMKPAppData::get_Node( int id, /* [retval][out] */ INode **pVal) 
{ 
	// Check pointer parameter
	if ( pVal == NULL )
		return E_POINTER;

	*pVal = NULL;

	// Result of operations
	HRESULT hr = S_OK;

	INode* nd = (INode*)Nodes->at(id);
	*pVal = nd;

	return S_OK;
}
HRESULT STDMETHODCALLTYPE CMKPAppData::get_Member(/*[in] */int id,  /* [retval][out] */ IMember **pVal) 
{ 
	// Check pointer parameter
	if ( pVal == NULL )
		return E_POINTER;

	*pVal = NULL;

	// Result of operations
	HRESULT hr = S_OK;

	IMember* mb = (IMember*)Members->at(id);
	*pVal = mb;

	return S_OK;
}


HRESULT STDMETHODCALLTYPE CMKPAppData::get_LoadCase( int id, /* [retval][out] */ ILoadCase **pVal)
{ 
	// Check pointer parameter
	if ( pVal == NULL )
		return E_POINTER;

	*pVal = NULL;

	// Result of operations
	HRESULT hr = S_OK;

	ILoadCase* mb = (ILoadCase*)LoadCases->at(id);
	*pVal = mb;

	return S_OK;
}

HRESULT STDMETHODCALLTYPE CMKPAppData::get_LoadGroup( int id, /* [retval][out] */ ILoadGroup **pVal)
{ 
	// Check pointer parameter
	if ( pVal == NULL )
		return E_POINTER;

	*pVal = NULL;

	// Result of operations
	HRESULT hr = S_OK;

	ILoadGroup* mb = (ILoadGroup*)LoadGroups->at(id);
	*pVal = mb;

	return S_OK;
}
HRESULT STDMETHODCALLTYPE CMKPAppData::get_Combination( int id, /* [retval][out] */ ICombination **pVal)
{ 
	// Check pointer parameter
	if ( pVal == NULL )
		return E_POINTER;

	*pVal = NULL;

	// Result of operations
	HRESULT hr = S_OK;

	ICombination* mb = (ICombination*)Combinations->at(id);
	*pVal = mb;

	return S_OK;
}
