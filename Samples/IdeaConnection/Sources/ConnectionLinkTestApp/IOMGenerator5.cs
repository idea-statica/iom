using IdeaRS.OpenModel;
using IdeaRS.OpenModel.Connection;
using IdeaRS.OpenModel.CrossSection;
using IdeaRS.OpenModel.Geometry2D;
using IdeaRS.OpenModel.Geometry3D;
using IdeaRS.OpenModel.Loading;
using IdeaRS.OpenModel.Material;
using IdeaRS.OpenModel.Model;
using IdeaRS.OpenModel.Result;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectionLinkTestApp
{
	internal class IOMGenerator5
	{
		private OpenModel openStructModel = null;
		private OpenModelResult openStructModelR = null;

		internal string CreateIOMTst(string filename)
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

			if (filename != null)
			{
				openStructModel.SaveToXmlFile(filename);
				openStructModelR.SaveToXmlFile(filename + "r");
				return filename;
			}
			else
			{
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
			openStructModel.OriginSettings.DateOfCreate = DateTime.Now;
		}

		private void AddMaterialsToOpenModel()
		{
			MatSteelEc2 matOM = new MatSteelEc2();
			matOM.Id = openStructModel.GetMaxId(matOM) + 1;
			matOM.Name = "S275";
			matOM.E = 210000000000;
			matOM.G = matOM.E / (2 * (1 + 0.3));
			matOM.Poisson = 0.3;
			matOM.UnitMass = 7870 / 9.81;
			matOM.fu = 430000000;
			matOM.fy = 275000000;
			matOM.fu40 = 410000000;
			matOM.fy40 = 255000000;
			matOM.SpecificHeat = 0.49;
			matOM.ThermalConductivity = 50.2;
			matOM.ThermalExpansion = 0.0000022;

			openStructModel.AddObject(matOM);
		}

		private void AddCrossSectionToOpenModel()
		{
			FillWeldedI();
			FillWeldedT();
			FillWeldedU();
			FillWeldedL();
			FillWeldedLMirrored();
			FillTGeneral();
			FillCSSByName();
			FillCssIarc();
			FillCssTarc();
		}

		private void FillWeldedI()
		{
			CrossSectionParameter css = new CrossSectionParameter();
			css.Id = 1;
			css.Material = new ReferenceElement(openStructModel.MatSteel.First());  // I have only one material, I take the first one
			double bu = 0.2;
			double hw = 0.4;
			double tw = 0.025;
			double tf = 0.02;
			CrossSectionFactory.FillWeldedI(css, bu, hw, tw, tf);
			openStructModel.AddObject(css);
		}

		private void FillWeldedT()
		{
			CrossSectionParameter css = new CrossSectionParameter();
			css.Id = 2;
			css.Material = new ReferenceElement(openStructModel.MatSteel.First());
			double b = 0.2;
			double h = 0.4;
			double tw = 0.02;
			double tf = 0.35;
			CrossSectionFactory.FillWeldedT(css, b, h, tw, tf);
			openStructModel.AddObject(css);
		}
		private void FillWeldedU()
		{
			CrossSectionParameter css = new CrossSectionParameter();
			css.Id = 3;
			css.Material = new ReferenceElement(openStructModel.MatSteel.First());
			double b = 0.2;
			double hw = 0.4;
			double tw = 0.025;
			double tf= 0.02;
			double rw= 0.004;
			double rf = 0.002;
			double taperF = 0.001;
			CrossSectionFactory.FillWeldedU(css, b, hw, tw, tf, rw, rf, taperF);
			openStructModel.AddObject(css);
		}

		private void FillWeldedL()
		{
			CrossSectionParameter css = new CrossSectionParameter();
			css.Id = 4;
			css.Material = new ReferenceElement(openStructModel.MatSteel.First());
			double B = 0.2;
			double D = 0.4;
			double t = 0.025;
			double rw = 0.004;
			double r2 = 0.002;
			double C = 0.0;
			bool mirrorZ = false;
			CrossSectionFactory.FillCssSteelAngle(css, B, D, t, rw, r2, C, mirrorZ);
			openStructModel.AddObject(css);
		}

		private void FillWeldedLMirrored()
		{
			CrossSectionParameter css = new CrossSectionParameter();
			css.Id = 5;
			css.Material = new ReferenceElement(openStructModel.MatSteel.First());
			double B = 0.2;
			double D = 0.4;
			double t = 0.025;
			double rw = 0.004;
			double r2 = 0.002;
			double C = 0.0;
			bool mirrorZ = true;
			CrossSectionFactory.FillCssSteelAngle(css, B, D, t, rw, r2, C, mirrorZ);
			openStructModel.AddObject(css);
		}


		private void FillTGeneral()
		{
			//Example of custom T section
			CrossSectionComponent css = new CrossSectionComponent();
			css.Name = "CSS1";
			css.Id = 6;


			LineSegment2D seg = null;

			//seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = -0.002, Y = -0.1 }; outline.Segments.Add(seg);
			//seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.002, Y = -0.1 }; outline.Segments.Add(seg);
			//seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.002, Y = -0.002 }; outline.Segments.Add(seg);
			//seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.002, Y = 0.002 }; outline.Segments.Add(seg);
			//seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.002, Y = 0.1 }; outline.Segments.Add(seg);
			//seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = -0.002, Y = 0.1 }; outline.Segments.Add(seg);
			//seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = -0.002, Y = 0.002 }; outline.Segments.Add(seg);

			{

				CssComponent comp = new CssComponent();
				comp.Material = new ReferenceElement(openStructModel.MatSteel.First());
				comp.Phase = 0;
				var reg = new Region2D();
				var outline = new PolyLine2D();
				outline.StartPoint = new Point2D() { X = -0.15, Y = 0.002 };
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = -0.15, Y = -0.002 }; outline.Segments.Add(seg);
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.15, Y = -0.002 }; outline.Segments.Add(seg);
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.15, Y = 0.002 }; outline.Segments.Add(seg);
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = -0.15, Y = 0.002 }; outline.Segments.Add(seg);
				reg.Outline = outline;
				comp.Geometry = reg;
				css.Components.Add(comp);
			}
			{

				CssComponent comp = new CssComponent();
				comp.Material = new ReferenceElement(openStructModel.MatSteel.First());
				comp.Phase = 0;
				var reg = new Region2D();
				var outline = new PolyLine2D();
				outline.StartPoint = new Point2D() { X = -0.002, Y = -0.002 };
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = -0.002, Y = -0.1 }; outline.Segments.Add(seg);
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.002, Y = -0.1 }; outline.Segments.Add(seg);
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = 0.002, Y = 0.002 }; outline.Segments.Add(seg);
				seg = new LineSegment2D(); seg.EndPoint = new Point2D() { X = -0.002, Y = -0.002 }; outline.Segments.Add(seg);
				reg.Outline = outline;
				comp.Geometry = reg;
				css.Components.Add(comp);
			}


			openStructModel.AddObject(css);
		}

		private void FillCSSByName()
		{
			CrossSectionParameter cssO = new CrossSectionParameter(); ;
			cssO.Id = 7;
			cssO.Material = new ReferenceElement(openStructModel.MatSteel.First());
			cssO.CrossSectionType = CrossSectionType.UniqueName;
			cssO.Name = "IPE200";
			cssO.Parameters.Add(new ParameterString() { Name = "UniqueName", Value = "IPE200" });
			openStructModel.AddObject(cssO);
		}
		private void FillCssIarc()
		{
			CrossSectionParameter css = new CrossSectionParameter();
			css.Id = 8;
			css.Material = new ReferenceElement(openStructModel.MatSteel.First());
			double cssGeomB = 0.25;
			double cssGeomH = 0.45;
			double cssGeomS = 0.02;
			double cssGeomT = 0.03;
			double cssGeomR2 = 0.012;
			double tapperF = Math.PI / 180.0 * 5.0;
			double r1 = 0.015;
			CrossSectionFactory.FillCssIarc(css, cssGeomB, cssGeomH, cssGeomS, cssGeomT, cssGeomR2, tapperF, r1);
			openStructModel.AddObject(css);
		}
		private void FillCssTarc()
		{
			CrossSectionParameter css = new CrossSectionParameter();
			css.Id = 9;
			css.Material = new ReferenceElement(openStructModel.MatSteel.First());
			double cssGeomB = 0.25;
			double cssGeomH = 0.45;
			double cssGeomTw = 0.02;
			double cssGeomTf = 0.03;
			double cssGeomR = 0.0012;
			double cssGeomR1 = 0.0010;
			double cssGeomR2 = 0.008;
			double tapperF = Math.PI / 180.0 * 5.0;
			double tapperW = Math.PI / 180.0 * 7.0;
			CrossSectionFactory.FillCssTarc(css, cssGeomB, cssGeomH, cssGeomTw, cssGeomTf, cssGeomR, cssGeomR1, cssGeomR2, tapperF, tapperW);
			openStructModel.AddObject(css);
		}

		private void AddNodesToOpenModel()
		{
			NewPoint(1, 0, 0, 0);
			NewPoint(2, 0, 0, 3.6);
			NewPoint(3, 1, 0, 0);
			NewPoint(4, 1, 0, 3.6);
			NewPoint(5, 2, 0, 0);
			NewPoint(6, 2, 0, 3.6);
			NewPoint(7, 3, 0, 0);
			NewPoint(8, 3, 0, 3.6);
			NewPoint(9, 4, 0, 0);
			NewPoint(10, 4, 0, 3.6);
			NewPoint(11, 5, 0, 0);
			NewPoint(12, 5, 0, 3.6);
			NewPoint(13, 6, 0, 0);
			NewPoint(14, 6, 0, 3.6);
			NewPoint(15, 7, 0, 0);
			NewPoint(16, 7, 0, 3.6);
			NewPoint(17, 8, 0, 0);
			NewPoint(18, 8, 0, 3.6);
		}

		private void NewPoint(int id, double x, double y, double z)
		{
			Point3D pointA = new Point3D() { X = x, Y = y, Z = z };
			pointA.Name = "N" + id.ToString();
			pointA.Id = id;
			openStructModel.AddObject(pointA);
		}

		private void CreateIDEAOpenModelConnection()
		{
			NewConnection(1, 1, 1, 2);
			NewConnection(2, 2, 3, 4);
			NewConnection(3, 3, 5, 6);
			NewConnection(4, 4, 7, 8);
			NewConnection(5, 5, 9, 10);
			NewConnection(6, 6, 11, 12);
			NewConnection(7, 7, 13, 14);
			NewConnection(8, 8, 15, 16);
			NewConnection(9, 9, 17, 18);
		}

		private void NewConnection(int idMember, int idCss, int idPointA, int idPointB)
		{
			ConnectionPoint connection = new ConnectionPoint();
			connection.Node = new ReferenceElement(openStructModel.Point3D.First(n => n.Id == idPointA));
			connection.Id = idPointA;
			connection.Name = "Con " + "N" + idPointA.ToString();

			ConnectedMember conMb = AddConnectedMember(idMember, idCss, idPointA, idPointB);
			connection.ConnectedMembers.Add(conMb);
			openStructModel.AddObject(connection);
		}


		private ConnectedMember AddConnectedMember(int idMember, int idCss, int idPointA, int idPointB)
		{
			PolyLine3D polyLine3D = new PolyLine3D();
			polyLine3D.Id = openStructModel.GetMaxId(polyLine3D) + 1;
			LineSegment3D ls = new LineSegment3D();
			ls.Id = openStructModel.GetMaxId(ls) + 1;

			openStructModel.AddObject(polyLine3D);
			openStructModel.AddObject(ls);

			ls.StartPoint = new ReferenceElement(openStructModel.Point3D.First(c => c.Id == idPointA));
			ls.EndPoint = new ReferenceElement(openStructModel.Point3D.First(c => c.Id == idPointB));
			polyLine3D.Segments.Add(new ReferenceElement(ls));

			Element1D el = new Element1D();
			el.Id = openStructModel.GetMaxId(el) + 1;
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