// This is the main DLL file.

#include "stdafx.h"

#include "IOM_Wrapper.h"

// This is the main DLL file.



// Utilities for Native<>CLI conversions
#include <vcclr.h>
#using<System.Windows.Forms.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Diagnostics;
using namespace System::IO;
using namespace System::Windows::Forms;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Linq;
using namespace System::Xml::Serialization;
//using namespace IdeaRS::ConnectionLink;
//
namespace IDEARS {

	//namespace IOM_N {


	IOM_Wrapper::IOM_Wrapper(String^ IOMfile)
	{
		//MessageBox::Show("IOM #1", "Debug", MessageBoxButtons::OK, MessageBoxIcon::Information);
		//this->m_pOpenModel = NULL;
		//this->m_pOpenModelResult = NULL;
		//this->m_pConnectionLink = nullptr;
		this->IOMfile = IOMfile;

		//ConnectionLink létrehozása az IdeaRS.ConnectionLink.dll betöltésével
	};

	IOM_Wrapper::~IOM_Wrapper()
	{
		if (this->openStructModel != nullptr)
		{
			// Get the CLR handle wrapper
			//gcroot<Object^> *pIOM =  static_cast<gcroot<Object^>*>(this->m_pOpenModel);
			// Delete the wrapper; this will release the underlying CLR instance
			// Set to null
			this->openStructModel = nullptr;
		}
	}
	/*
	void IOM_Wrapper::SetIDEADir(System::String^ ideaInstallDir)
	{
	}
	*/

	int IOM_Wrapper::CreateIDEAOpenModel(void* pMKPData)
	{
		data = (IMKPAppData*)pMKPData;
		//gcroot<IMKPAppData*>* data = static_cast<gcroot<IMKPAppData*>*> pMKPData;

		openStructModel = gcnew OpenModel();
		openStructModel->OriginSettings = gcnew OriginSettings();
		openStructModel->OriginSettings->CrossSectionConversionTable= CrossSectionConversionTable::SCIA;
		openStructModel->OriginSettings->ProjectName = "Project 1";
		openStructModel->OriginSettings->Author = "Author prj";
		openStructModel->OriginSettings->ProjectDescription = "Part 27";
		openStructModel->OriginSettings->DateOfCreate = DateTime::Now;

		//// Managed type conversion into unmanaged pointer is not allowed unless
		//// we use "gcroot<>" wrapper.
		//gcroot<Object^> *pIOM = new gcroot<Object^>(openStructModel);

		//this->m_pOpenModel = static_cast<void*>(pIOM);

		CreateMaterialIOM();
		CreateCrossSectionsIOM();
		CreateNodesIOM();
		CreateMembersIOM();
		CreateLoadGroupsIOM();
		CreateLoadCasesIOM();
		CreateCombinationsIOM();
		CreateConnectionPointIOM();

		CreateIDEAOpenModelResults();

		openStructModel->SaveToXmlFile(IOMfile);

		return 0;
	}

	int IOM_Wrapper::CreateMaterialIOM()
	{
		MatSteelEc2^ matOM = gcnew MatSteelEc2();
		matOM->Id = 1;
		matOM->Name = "S275";
		matOM->E = 210000000000;
		matOM->G = matOM->E / (2 * (1 + 0.3));
		matOM->Poisson = 0.3;
		matOM->UnitMass = 7850 / 9.81;
		matOM->fu = 430000000;
		matOM->fy = 275000000;
		matOM->fu40 = 410000000;
		matOM->fy40 = 255000000;
		matOM->SpecificHeat = 0.49;
		matOM->ThermalConductivity = 50.2;
		matOM->ThermalExpansion = 0.000012;
		openStructModel->MatSteel->Add(matOM);
		return 0;
	}

	int IOM_Wrapper::CreateCrossSectionsIOM()
	{
		int numCss;
		numCss = data->GetNumCrossSections();
		CrossSectionParameter^ cssO = gcnew CrossSectionParameter();
		for (int i = 0; i < numCss; i++)
		{
			ICrossSectionPtr css = data->GetCrossSection(i);
			cssO->Name = "IPE200";
			cssO->Id = openStructModel->CrossSection->Count + 1;
			cssO->Material = gcnew ReferenceElement(openStructModel->MatSteel[0]);  // first material
			cssO->CrossSectionType = CrossSectionType::RolledI;
			ParameterString^ par = gcnew ParameterString();
			par->Name = "UniqueName";
			par->Value= "IPE200";
			cssO->Parameters->Add(par);
			openStructModel->CrossSection->Add(cssO);
		}
		return 0;

	}
	int IOM_Wrapper::CreateNodesIOM()
	{
		int numNodes;
		numNodes = data->GetNumNodes();
		for (int i = 0; i < numNodes; i++)
		{
			INodePtr nd = data->GetNode(i);
			Point3D^ ptOM  = gcnew Point3D();
			ptOM->X = nd->GetX(); 
			ptOM->Y = nd->GetY(); 
			ptOM->Z = nd->GetZ(); 
			ptOM->Id = nd->GetId();
			openStructModel->AddObject(ptOM);
		}
		return 0;
	}

	int IOM_Wrapper::CreateMembersIOM()
	{
		int numMembers;
		numMembers = data->GetNumMembers();
		for (int i = 0; i < numMembers; i++)
		{
			IMemberPtr mb = data->GetMember(i);
			PolyLine3D^ polyLine3D = gcnew PolyLine3D();
			polyLine3D->Id = mb->GetId();
			LineSegment3D^ ls = gcnew LineSegment3D();
			ls->Id = mb->GetId();
			int begB = mb->GetBeginNode();
			int begE = mb->GetEndNode();
			Point3D^ ptA;
			Point3D^ ptB;
			for each (Point3D^ pt in openStructModel->Point3D)
			{
				if (pt->Id == begB)
				{
					ptA = pt;
				}
			}
			for each (Point3D^ pt in openStructModel->Point3D)
			{
				if (pt->Id == begE)
				{
					ptB = pt;
				}
			}
			ls->StartPoint = gcnew ReferenceElement(ptA);
			ls->EndPoint = gcnew ReferenceElement(ptB);
			polyLine3D->Segments->Add(gcnew ReferenceElement(ls));

			openStructModel->PolyLine3D->Add(polyLine3D);
			openStructModel->LineSegment3D->Add(ls);

			Element1D^ el = gcnew Element1D();
			el->Id = mb->GetId();
			el->Name = "E" + (mb->GetId()).ToString();
			el->Segment = gcnew ReferenceElement(ls);
			//el.RotationRx = Rot1x - Math.PI / 2; //  / 180.0 * Math.PI/* + Math.PI / 2*/;

			//long idCssBeg = 0;
			//long idCssEnd = 0;
			el->CrossSectionBegin = gcnew ReferenceElement(openStructModel-> CrossSection[0]);
			el->CrossSectionEnd = gcnew ReferenceElement(openStructModel-> CrossSection[0]);
			//String cssName = cssO->Name;
			openStructModel->Element1D->Add(el);

			Member1D^ mbO = gcnew Member1D();
			mbO->Id = mb->GetId();
			//String nameBar = mb->GetId()->ToString();
			//if (barPtr.Name.Length > 0)
			//{
			//  nameBar = barPtr.Name;
			//}
			mbO->Name = "M" + (mb->GetId()).ToString();
			mbO->Elements1D->Add(gcnew ReferenceElement(el));
			openStructModel->Member1D->Add(mbO);

		}
		return 0;
	}

	int IOM_Wrapper::CreateLoadGroupsIOM()
	{
		int numLoadGroups;
		numLoadGroups = data->GetNumLoadGroups();
		for (int i = 0; i < numLoadGroups; i++)
		{
			ILoadGroupPtr gr = data->GetLoadGroup(i);
			IdeaRS::OpenModel::Loading::LoadGroup^ loadGroup = gcnew IdeaRS::OpenModel::Loading::LoadGroupEC();
			loadGroup->Name = "LG" + (i + 1).ToString();
			loadGroup->Id = openStructModel->LoadGroup->Count + 1;
			openStructModel->AddObject(loadGroup);

		}
		return 0;
	}

	int IOM_Wrapper::CreateLoadCasesIOM()
	{
		int numLoadCases;
		numLoadCases = data->GetNumLoadCases();
		for (int i = 0; i < numLoadCases; i++)
		{
			ILoadCasePtr lc = data->GetLoadCase(i);
			IdeaRS::OpenModel::Loading::LoadCase^ loadCase = gcnew IdeaRS::OpenModel::Loading::LoadCase();
			loadCase->Name = "LC" + (i + 1).ToString();
			loadCase->Id = openStructModel->LoadCase->Count + 1;
			openStructModel->AddObject(loadCase);

		}
		return 0;
	}


	int IOM_Wrapper::CreateCombinationsIOM()
	{
		int numCombinations;
		numCombinations = data->GetNumCombinations();
		for (int i = 0; i < numCombinations; i++)
		{
			ICombinationPtr com = data->GetCombination(i);
			int numLc = com->GetNumLoadCases();
			CombiInputEC^ combi = gcnew CombiInputEC();
			combi->Name = "CO1";
			combi->TypeCombiEC = TypeOfCombiEC::ULS;
			combi->TypeCalculationCombi = TypeCalculationCombiEC::Linear;
			for (int iLc = 0; iLc < numLc; iLc++)
			{
				IdeaRS::OpenModel::Loading::CombiItem^ it = gcnew IdeaRS::OpenModel::Loading::CombiItem();
				it->Id = 1;
				ILoadCasePtr lcC;
				double coeff;
				com->LoadCase(iLc, &lcC, &coeff);
				IdeaRS::OpenModel::Loading::LoadCase^ lcF;
				for each (IdeaRS::OpenModel::Loading::LoadCase^ lcOp in openStructModel->LoadCase)
				{
					if (lcOp->Id == lcC->GetId())
					{
						lcF = lcOp;
					}
				}
				it->LoadCase = gcnew ReferenceElement(lcF);
				it->Coeff = coeff;
				combi->Items->Add(it);
			}
			openStructModel->AddObject(combi);
		}
		return 0;
	}

	int IOM_Wrapper::CreateConnectionPointIOM()
	{
		ConnectionPoint^ connection = gcnew ConnectionPoint();
		connection->Node = gcnew ReferenceElement(openStructModel->Point3D[1]);  // Connection in seccond Node 
		connection->Id = 1;
		connection->Name = "Con " + "N2";
		ConnectedMember^ conMb1 = gcnew ConnectedMember();
		conMb1->Id = 1;
		conMb1->MemberId = gcnew ReferenceElement(openStructModel->Member1D[0]);
		connection->ConnectedMembers->Add(conMb1);

		ConnectedMember^ conMb2 = gcnew ConnectedMember();
		conMb2->Id = 2;
		conMb2->MemberId = gcnew ReferenceElement(openStructModel->Member1D[1]);
		connection->ConnectedMembers->Add(conMb2);

		openStructModel->AddObject(connection);
		return 0;
	}

	int IOM_Wrapper::CreateIDEAOpenModelResults()
	{
		openStructModelR = gcnew OpenModelResult();
		ResultOnMembers^ resIF = gcnew ResultOnMembers();
		for (int ib = 0; ib < openStructModel->Member1D->Count; ib++)
		{
			Member1D^ mb = openStructModel->Member1D[ib];
			for (int iel = 0; iel < mb->Elements1D->Count; iel++)
			{
				Element1D^ elem;
				for each (Element1D^ elOp in openStructModel->Element1D)
				{
					if (elOp->Id == mb->Elements1D[iel]->Id)
					{
						elem = elOp;
					}
				}
				IdeaRS::OpenModel::Result::Member^ mbR = gcnew IdeaRS::OpenModel::Result::Member();
				mbR->Id = elem->Id;
				mbR->MemberType = MemberType::Element1D;
				ResultOnMember^ resMember = gcnew ResultOnMember(mbR, ResultType::InternalForces);
				int numPoints = 10;
				for (int ip = 0; ip <= numPoints; ip++)
				{
					ResultOnSection^ resSec = gcnew ResultOnSection();

					resSec->AbsoluteRelative = AbsoluteRelative::Relative;
					resSec->Position = (double)ip / (double)numPoints;
					int count = openStructModel->LoadCase->Count;
					for (int i = 1; i <= count; i++)
					{
						ResultOfInternalForces^ resLc = gcnew ResultOfInternalForces();
						int loadCaseNumber = i;
						resLc->Loading = gcnew ResultOfLoading() ;
						resLc->Loading->Id = loadCaseNumber;
						resLc->Loading->LoadingType = LoadingType::LoadCase;
						ResultOfLoadingItem^ resultOfLoadingItem = gcnew ResultOfLoadingItem();
						resultOfLoadingItem->Coefficient = 1.0;
						resLc->Loading->Items->Add(resultOfLoadingItem);
						resLc->N = 5000;
						resLc->Qy = 2;
						resLc->Qz = 3;
						resLc->Mx = 4;
						resLc->My = (ip + 1) * 5000;
						resLc->Mz = 6;
						resSec->Results->Add(resLc);
					}

					resMember->Results->Add(resSec);
				}

				resIF->Members->Add(resMember);
			}
		}

		openStructModelR->ResultOnMembers->Add(resIF);
		return 0;
	}



}
