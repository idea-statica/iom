﻿using IdeaRS.OpenModel;
using IdeaRS.OpenModel.Connection;
using IdeaRS.OpenModel.CrossSection;
using IdeaRS.OpenModel.Geometry3D;
using IdeaRS.OpenModel.Loading;
using IdeaRS.OpenModel.Material;
using IdeaRS.OpenModel.Model;
using IdeaRS.OpenModel.Result;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOM_IDEAConnectionRunnerTestApp
{
	internal class IOMGenerator
	{
		private OpenModel openStructModel = null;
		private OpenModelResult openStructModelR = null;

		internal string CreateIOMTst()
		{
			CreateIDEAOpenModel();

			AddMaterialsToOpenModel();

			AddCrossSectionToOpenModel();

			AddNodesToOpenModel();

			CreateIDEAOpenModelConnection();

			AddLoadCasesToOpenModel();

			AddCombinationToOpenModel();

			CreateIDEAOpenModelResults();

			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.DefaultExt = "*.xml";
			saveFileDialog.Filter = "xml file (*.xml)|*.xml";
			saveFileDialog.Title = string.Format("Name of file");
			bool? result = saveFileDialog.ShowDialog();

			if (result == true)
			{
				openStructModel.SaveToXmlFile(saveFileDialog.FileName);
				openStructModelR.SaveToXmlFile(saveFileDialog.FileName + "r");
				return saveFileDialog.FileName;
			}

			return null;
		}

		private void CreateIDEAOpenModel()
		{
			openStructModel = new OpenModel();
			openStructModel.OriginSettings = new OriginSettings() { CrossSectionConversionTable = CrossSectionConversionTable.SCIA };
			openStructModel.OriginSettings.ProjectName = "Project 1";
			openStructModel.OriginSettings.Author = "Author prj";
			openStructModel.OriginSettings.ProjectDescription = "Part 27";
		}

		private void AddMaterialsToOpenModel()
		{
			MatSteelEc2 matOM = new MatSteelEc2();
			matOM.Id = openStructModel.GetMaxId(matOM) + 1;
			matOM.Name = "S275";
			matOM.E = 210000000000;
			matOM.G = matOM.E / (2 * (1 + 0.3));
			matOM.Poisson = 0.3;
			matOM.UnitMass = 7850 / 9.81;
			matOM.fu = 430000000;
			matOM.fy = 275000000;
			matOM.fu40 = 410000000;
			matOM.fy40 = 255000000;
			matOM.SpecificHeat = 0.49;
			matOM.ThermalConductivity = 50.2;
			matOM.ThermalExpansion = 0.000012;

			openStructModel.AddObject(matOM);
		}

		private void AddCrossSectionToOpenModel()
		{
			AddRolledCSS();
			AddWeldedI();
		}

		private void AddRolledCSS()
		{
			CrossSectionParameter cssO = new CrossSectionParameter();
			cssO.Material = new ReferenceElement(openStructModel.MatSteel.First()); // I have only one material, I take the first one
			cssO.CrossSectionType = CrossSectionType.RolledI;
			string ideaName = "IPE200";
			cssO.Name = "IPE200";
			cssO.Parameters.Add(new ParameterString() { Name = "UniqueName", Value = ideaName });

			openStructModel.AddObject(cssO);
		}

		private void AddWeldedI()
		{
			//Example of custom I section
			CrossSectionParameter cssWI = new CrossSectionParameter();
			cssWI.Material = new ReferenceElement(openStructModel.MatSteel.First());  // I have only one material, I take the first one
			cssWI.Name = "I 400, welded";
			CrossSectionFactory.FillWeldedI(cssWI, 0.2, 0.4, 0.025, 0.020);
			openStructModel.AddObject(cssWI);
		}

		private void AddNodesToOpenModel()
		{
			Point3D pointA = new Point3D() { X = 0, Y = 0, Z = 0.0 };
			pointA.Name = "N1";
			pointA.Id = 1;
			openStructModel.AddObject(pointA);

			Point3D pointB = new Point3D() { X = 0, Y = 0, Z = 3.6 };
			pointB.Name = "N2";
			pointB.Id = 2;
			openStructModel.AddObject(pointB);

			Point3D pointC = new Point3D() { X = 6.0, Y = 0, Z = 3.6 };
			pointC.Name = "N3";
			pointC.Id = 3;
			openStructModel.AddObject(pointC);
		}

		private void CreateIDEAOpenModelConnection()
		{
			ConnectionPoint connection = new ConnectionPoint();
			connection.Node = new ReferenceElement(openStructModel.Point3D.First(n => n.Id == 2));
			connection.Id = 1;
			connection.Name = "Con " + "N2";

			ConnectedMember conMb1 = AddConnectedMember(1, 1, 1, 2);
			ConnectedMember conMb2 = AddConnectedMember(2, 2, 2, 3);

			connection.ConnectedMembers.Add(conMb1);
			connection.ConnectedMembers.Add(conMb2);

			openStructModel.AddObject(connection);
		}

		private ConnectedMember AddConnectedMember(int idMember, int idCss, int idPointA, int idPointB)
		{
			PolyLine3D polyLine3D = new PolyLine3D();
			polyLine3D.Id = idMember;
			LineSegment3D ls = new LineSegment3D();
			ls.Id = idMember;

			openStructModel.AddObject(polyLine3D);
			openStructModel.AddObject(ls);

			ls.StartPoint = new ReferenceElement(openStructModel.Point3D.First(c => c.Id == idPointA));
			ls.EndPoint = new ReferenceElement(openStructModel.Point3D.First(c => c.Id == idPointB));
			polyLine3D.Segments.Add(new ReferenceElement(ls));

			Element1D el = new Element1D();
			el.Id = idMember;
			el.Name = "E" + el.Id.ToString();
			el.Segment = new ReferenceElement(ls);
			el.CrossSectionBegin = new ReferenceElement(openStructModel.CrossSection.First(c => c.Id == idCss));
			el.CrossSectionEnd = new ReferenceElement(openStructModel.CrossSection.First(c => c.Id == idCss));
			openStructModel.AddObject(el);

			Member1D mb = new Member1D();
			mb.Id = idMember;
			mb.Name = "B" + mb.Id.ToString();
			mb.Elements1D.Add(new ReferenceElement(el));
			openStructModel.Member1D.Add(mb);

			ConnectedMember conMb = new ConnectedMember();
			conMb.Id = mb.Id;
			conMb.MemberId = new ReferenceElement(mb);
			return conMb;
		}

		private void AddLoadCasesToOpenModel()
		{
			LoadCase loadCase = new LoadCase();
			loadCase.Name = "LC1";
			loadCase.Id = 1;
			loadCase.Type = LoadCaseSubType.PermanentStandard;

			LoadGroupEC loadGroup = null;

			loadGroup = new LoadGroupEC();
			loadGroup.Id = 1;
			loadGroup.Name = "LG1";
			loadGroup.GammaQ = 1.5;
			loadGroup.Psi0 = 0.7;
			loadGroup.Psi1 = 0.5;
			loadGroup.Psi2 = 0.3;
			loadGroup.GammaGInf = 1.0;
			loadGroup.GammaGSup = 1.35;
			loadGroup.Dzeta = 0.85;
			openStructModel.AddObject(loadGroup);

			loadCase.LoadGroup = new ReferenceElement(loadGroup);

			openStructModel.AddObject(loadCase);
		}

		private void AddCombinationToOpenModel()
		{
			CombiInputEC combi = new CombiInputEC();
			combi.Name = "CO1";
			combi.TypeCombiEC = TypeOfCombiEC.ULS;
			combi.TypeCalculationCombi = TypeCalculationCombiEC.Linear;
			combi.Items = new List<CombiItem>();
			CombiItem it = new CombiItem();
			it.Id = 1;
			it.LoadCase = new ReferenceElement(openStructModel.LoadCase.First());
			it.Coeff = 1.0;
			combi.Items.Add(it);
			openStructModel.AddObject(combi);
		}

		private double GetLength(OpenModel openStructModel, Member1D mb)
		{
			Element1D el = openStructModel.Element1D.First(c => c.Id == mb.Elements1D[0].Id);
			LineSegment3D seg = openStructModel.LineSegment3D.First(c => c.Id == el.Segment.Id);
			Point3D pA = openStructModel.Point3D.First(c => c.Id == seg.StartPoint.Id);
			Point3D pB = openStructModel.Point3D.First(c => c.Id == seg.EndPoint.Id);
			Vector3D vector = new Vector3D();
			vector.X = pA.X - pB.X;
			vector.Y = pA.Y - pB.Y;
			vector.Z = pA.Z - pB.Z;
			return Math.Sqrt(((vector.X * vector.X) + (vector.Y * vector.Y) + (vector.Z * vector.Z)));
		}

		private void CreateIDEAOpenModelResults()
		{
			openStructModelR = new OpenModelResult();
			openStructModelR.ResultOnMembers = new List<ResultOnMembers>();
			ResultOnMembers resIF = new ResultOnMembers();
			for (int ib = 0; ib < openStructModel.Member1D.Count; ib++)
			{
				Member1D mb = openStructModel.Member1D[ib];
				for (int iel = 0; iel < mb.Elements1D.Count; iel++)
				{
					Element1D elem = openStructModel.Element1D.First(c => c.Id == mb.Elements1D[iel].Id);
					ResultOnMember resMember = new ResultOnMember(new Member() { Id = elem.Id, MemberType = MemberType.Element1D }, ResultType.InternalForces);
					int numPoints = 1;
					for (int ip = 0; ip <= numPoints; ip++)
					{
						ResultOnSection resSec = new ResultOnSection();

						resSec.AbsoluteRelative = AbsoluteRelative.Relative;
						resSec.Position = (double)ip / (double)numPoints;
						int count = openStructModel.LoadCase.Count;
						for (int i = 0; i < count; i++)
						{
							ResultOfInternalForces resLc = new ResultOfInternalForces();
							resLc.Loading = new ResultOfLoading() { Id = openStructModel.LoadCase[i].Id, LoadingType = LoadingType.LoadCase };
							resLc.Loading.Items.Add(new ResultOfLoadingItem() { Coefficient = 1.0 });
							resLc.N = 5000;
							resLc.Qy = 2;
							resLc.Qz = 3;
							resLc.Mx = 4;
							resLc.My = (ip + 1) * 5000;
							resLc.Mz = 6;
							resSec.Results.Add(resLc);
						}

						resMember.Results.Add(resSec);
					}

					resIF.Members.Add(resMember);
				}
			}

			openStructModelR.ResultOnMembers.Add(resIF);
		}
	}
}