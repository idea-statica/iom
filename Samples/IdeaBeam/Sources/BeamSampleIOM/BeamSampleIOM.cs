using IdeaRS.OpenModel;
using IdeaRS.OpenModel.CrossSection;
using IdeaRS.OpenModel.Geometry3D;
using IdeaRS.OpenModel.Loading;
using IdeaRS.OpenModel.Material;
using IdeaRS.OpenModel.Model;
using IdeaRS.OpenModel.Result;
using System.Collections.Generic;
using System.Linq;

namespace SampleIOM
{
	/// <summary>
	/// The Beam IDEA Open Model Sample
	/// </summary>
	public class BeamSampleIOM
	{
		private OpenModel iom;
		private OpenModelResult iomResults;

		/// <summary>
		/// Constructor
		/// </summary>
		public BeamSampleIOM()
		{
			iom = null;
			iomResults = null;
		}

		/// <summary>
		/// Gets the Open Model
		/// </summary>
		public OpenModel IOM
		{
			get
			{
				if (iom == null)
				{
					GenerateIOM();
				}

				return iom;
			}
		}

		/// <summary>
		/// Gets the Open Model Results
		/// </summary>
		public OpenModelResult IOMResults
		{
			get
			{
				if (iomResults == null)
				{
					GenerateIOMResults();
				}

				return iomResults;
			}
		}

		/// <summary>
		/// Creates the Open Model
		/// </summary>
		private void GenerateIOM()
		{
			iom = new OpenModel();
			CreateSettings();
			CreateGeometry();
			CreateMaterials();
			CreateCrossSections();
			CreateModel();
			CreateLoad();
		}

		/// <summary>
		/// Creates the settings
		/// </summary>
		private void CreateSettings()
		{
			OriginSettings originSettings = new OriginSettings();
			originSettings.DateOfCreate = System.DateTime.Now;
			originSettings.CrossSectionConversionTable = CrossSectionConversionTable.Autodesk;
			iom.OriginSettings = originSettings;
		}

		/// <summary>
		/// Creates the geometry (points, lines, polylines)
		/// </summary>
		private void CreateGeometry()
		{
			// Points
			Point3D point379 = new Point3D();
			point379.Id = 379;
			point379.Name = "38";
			point379.X = 0;
			point379.Y = -46.28;
			point379.Z = 0;
			iom.AddObject(point379);

			Point3D point400 = new Point3D();
			point400.Id = 400;
			point400.Name = "41";
			point400.X = 14.510000002000002;
			point400.Y = -46.28;
			point400.Z = 0.38999995400000004;
			iom.AddObject(point400);

			Point3D point381 = new Point3D();
			point381.Id = 381;
			point381.Name = "40";
			point381.X = 29.020000000000003;
			point381.Y = -46.28;
			point381.Z = 0;
			iom.AddObject(point381);

			// Geometrical lines
			LineSegment3D lineSegment403 = new LineSegment3D();
			lineSegment403.Id = 403;

			// Simply reference existing point as first point of line
			lineSegment403.StartPoint = new ReferenceElement(point379);

			// Or, you can take a reference from existing points, that satisfies a condition - second point of line
			lineSegment403.EndPoint = new ReferenceElement(iom.Point3D.First(p => p.Id == 400));

			// Local coordinate system of line.
			CoordSystemByVector coordSystem = new CoordSystemByVector();
			coordSystem.VecX = new Vector3D();
			coordSystem.VecX.X = 0.99963898183111166;
			coordSystem.VecX.Y = 0;
			coordSystem.VecX.Z = 0.026868308537353808;
			coordSystem.VecY = new Vector3D();
			coordSystem.VecY.X = 0;
			coordSystem.VecY.Y = 1;
			coordSystem.VecY.Z = 0;
			coordSystem.VecZ = new Vector3D();
			coordSystem.VecZ.X = -0.026868308537353808;
			coordSystem.VecZ.Y = 0;
			coordSystem.VecZ.Z = 0.99963898183111166;

			lineSegment403.LocalCoordinateSystem = coordSystem;
			iom.AddObject(lineSegment403);

			LineSegment3D lineSegment405 = new LineSegment3D();
			lineSegment405.Id = 405;
			lineSegment405.StartPoint = new ReferenceElement(point400);
			lineSegment405.EndPoint = new ReferenceElement(point381);

			coordSystem = new CoordSystemByVector();
			coordSystem.VecX = new Vector3D();
			coordSystem.VecX.X = 0.99963898183091271;
			coordSystem.VecX.Y = 0;
			coordSystem.VecX.Z = -0.0268683085447553;
			coordSystem.VecY = new Vector3D();
			coordSystem.VecY.X = 0;
			coordSystem.VecY.Y = 1;
			coordSystem.VecY.Z = 0;
			coordSystem.VecZ = new Vector3D();
			coordSystem.VecZ.X = 0.0268683085447553;
			coordSystem.VecZ.Y = 0;
			coordSystem.VecZ.Z = 0.99963898183091271;

			lineSegment405.LocalCoordinateSystem = coordSystem;
			iom.AddObject(lineSegment405);

			//polyline
			PolyLine3D polyline = new PolyLine3D();
			polyline.Id = 403;
			polyline.Segments.Add(new ReferenceElement(lineSegment403));
			iom.AddObject(polyline);

			polyline = new PolyLine3D();
			polyline.Id = 405;
			polyline.Segments.Add(new ReferenceElement(lineSegment405));
			iom.AddObject(polyline);
		}

		/// <summary>
		/// Creates the materials
		/// </summary>
		private void CreateMaterials()
		{
			// Eurocode materials
			// Concrete      - MatConcreteEc2
			// Steel         - MatSteelEc2
			// Reinforcement - MatReinforcementEc2

			MatConcreteEc2 mat = new MatConcreteEc2();
			mat.Id = 268;
			mat.Name = "MY CONCRETE C16/20";
			mat.E = 29000000000;
			mat.G = 12083333333.333334;
			mat.Poisson = 0.2;
			mat.UnitMass = 2500.5096839959224;
			mat.CalculateDependentValues = true;
			mat.Fck = 16000000;
			mat.Ecm = 0;
			mat.Epsc1 = 0;
			mat.Epsc2 = 0;
			mat.Epsc3 = 0;
			mat.Epscu1 = 0;
			mat.Epscu2 = 0;
			mat.Epscu3 = 0;
			mat.Fctm = 0;
			mat.Fctk_0_05 = 0;
			mat.Fctk_0_95 = 0;
			mat.NFactor = 0;
			mat.Fcm = 0;
			mat.StoneDiameter = 0.016;
			mat.CementClass = ConcCementClass.S;
			mat.AggregateType = ConcAggregateType.Quartzite;
			mat.DiagramType = ConcDiagramType.Bilinear;
			mat.SilicaFume = false;
			mat.PlainConcreteDiagram = false;
			iom.AddObject(mat);
		}

		/// <summary>
		/// Creates the cross-sections
		/// </summary>
		private void CreateCrossSections()
		{
			CrossSectionParameter crossSection = new CrossSectionParameter();
			crossSection.Id = 555;
			crossSection.Name = "B R40x140";
			crossSection.CrossSectionType = CrossSectionType.Ign;
			CrossSectionFactory.FillShapeI(crossSection, 1.4000000000000001, 0.4, 0.4, 0.2, 0.3, 0.1);
			crossSection.Material = new ReferenceElement(iom.MatConcrete.FirstOrDefault(m => m.Id == 268));
			iom.AddObject(crossSection);

			crossSection = new CrossSectionParameter();
			crossSection.Id = 100555;
			crossSection.Name = "B R40x140";
			crossSection.CrossSectionType = CrossSectionType.Ign;
			CrossSectionFactory.FillShapeI(crossSection, 0.665, 0.4, 0.4, 0.2, 0.3, 0.1);
			crossSection.Material = new ReferenceElement(iom.MatConcrete.FirstOrDefault(m => m.Id == 268));
			iom.AddObject(crossSection);
		}

		/// <summary>
		/// Creates the model (elements, members, beams, supports)
		/// </summary>
		private void CreateModel()
		{
			Element1D element = new Element1D();
			element.Id = 403;
			element.Name = "EB19";
			element.CrossSectionBegin = new ReferenceElement(iom.CrossSection.FirstOrDefault(cs => cs.Id == 100555));
			element.CrossSectionEnd = new ReferenceElement(iom.CrossSection.FirstOrDefault(cs => cs.Id == 555));
			element.Segment = new ReferenceElement(iom.LineSegment3D.FirstOrDefault(l => l.Id == 403));
			element.RotationRx = 0;
			element.EccentricityBeginX = 0;
			element.EccentricityBeginY = 0;
			element.EccentricityBeginZ = 0;
			element.EccentricityEndX = 0;
			element.EccentricityEndY = 0;
			element.EccentricityEndZ = 0;
			iom.AddObject(element);

			element = new Element1D();
			element.Id = 405;
			element.Name = "EB21";
			element.CrossSectionBegin = new ReferenceElement(iom.CrossSection.FirstOrDefault(cs => cs.Id == 555));
			element.CrossSectionEnd = new ReferenceElement(iom.CrossSection.FirstOrDefault(cs => cs.Id == 100555));
			element.Segment = new ReferenceElement(iom.LineSegment3D.FirstOrDefault(l => l.Id == 405));
			element.RotationRx = 0;
			element.EccentricityBeginX = 0;
			element.EccentricityBeginY = 0;
			element.EccentricityBeginZ = 0;
			element.EccentricityEndX = 0;
			element.EccentricityEndY = 0;
			element.EccentricityEndZ = 0;
			iom.AddObject(element);

			Member1D member = new Member1D();
			member.Id = 403;
			member.Name = "B19 B R40x140/B R40x140";
			member.Elements1D.Add(new ReferenceElement(iom.Element1D.FirstOrDefault(e => e.Id == 403)));
			member.Member1DType = Member1DType.Beam;
			iom.AddObject(member);

			member = new Member1D();
			member.Id = 405;
			member.Name = "B21 B R40x140/B R40x140";
			member.Elements1D.Add(new ReferenceElement(iom.Element1D.FirstOrDefault(e => e.Id == 405)));
			member.Member1DType = Member1DType.Beam;
			iom.AddObject(member);

			PointSupportNode pointSupport = new PointSupportNode();
			pointSupport.Id = 1;
			pointSupport.Point = new ReferenceElement(iom.Point3D.FirstOrDefault(p => p.Id == 379));
			pointSupport.FlexibleStiffnessX = 0;
			pointSupport.FlexibleStiffnessY = 0;
			pointSupport.FlexibleStiffnessZ = 0;
			pointSupport.FlexibleStiffnessRX = 0;
			pointSupport.FlexibleStiffnessRY = 0;
			pointSupport.FlexibleStiffnessRZ = 0;
			pointSupport.SupportTypeX = SupportTypeInDirrection.Rigid;
			pointSupport.SupportTypeY = SupportTypeInDirrection.Rigid;
			pointSupport.SupportTypeZ = SupportTypeInDirrection.Rigid;
			pointSupport.SupportTypeRX = SupportTypeInDirrection.Free;
			pointSupport.SupportTypeRY = SupportTypeInDirrection.Free;
			pointSupport.SupportTypeRZ = SupportTypeInDirrection.Free;
			iom.AddObject(pointSupport);

			pointSupport = new PointSupportNode();
			pointSupport.Id = 2;
			pointSupport.Point = new ReferenceElement(iom.Point3D.FirstOrDefault(p => p.Id == 381));
			pointSupport.FlexibleStiffnessX = 0;
			pointSupport.FlexibleStiffnessY = 0;
			pointSupport.FlexibleStiffnessZ = 0;
			pointSupport.FlexibleStiffnessRX = 0;
			pointSupport.FlexibleStiffnessRY = 0;
			pointSupport.FlexibleStiffnessRZ = 0;
			pointSupport.SupportTypeX = SupportTypeInDirrection.Free;
			pointSupport.SupportTypeY = SupportTypeInDirrection.Rigid;
			pointSupport.SupportTypeZ = SupportTypeInDirrection.Rigid;
			pointSupport.SupportTypeRX = SupportTypeInDirrection.Free;
			pointSupport.SupportTypeRY = SupportTypeInDirrection.Free;
			pointSupport.SupportTypeRZ = SupportTypeInDirrection.Free;
			iom.AddObject(pointSupport);
		}

		/// <summary>
		/// Creates loads (load groups, load cases, combinations)
		/// </summary>
		private void CreateLoad()
		{
			//Load groups
			LoadGroupEC loadGroup = new LoadGroupEC();
			loadGroup.Id = 1;
			loadGroup.Name = "Permanent";
			loadGroup.Relation = Relation.Standard;
			loadGroup.GroupType = LoadGroupType.Permanent;
			loadGroup.GammaQ = 1.5;
			loadGroup.Dzeta = 0.85;
			loadGroup.GammaGInf = 1;
			loadGroup.GammaGSup = 1.35;
			loadGroup.Psi0 = 0.7;
			loadGroup.Psi1 = 0.5;
			loadGroup.Psi2 = 0.3;
			iom.AddObject(loadGroup);

			loadGroup = new LoadGroupEC();
			loadGroup.Id = 2;
			loadGroup.Name = "Variable";
			loadGroup.Relation = Relation.Standard;
			loadGroup.GroupType = LoadGroupType.Variable;
			loadGroup.GammaQ = 1.5;
			loadGroup.Dzeta = 0.85;
			loadGroup.GammaGInf = 1;
			loadGroup.GammaGSup = 1.35;
			loadGroup.Psi0 = 0.7;
			loadGroup.Psi1 = 0.5;
			loadGroup.Psi2 = 0.3;
			iom.AddObject(loadGroup);

			loadGroup = new LoadGroupEC();
			loadGroup.Id = 4;
			loadGroup.Name = "Snow";
			loadGroup.Relation = Relation.Standard;
			loadGroup.GroupType = LoadGroupType.Variable;
			loadGroup.GammaQ = 1.5;
			loadGroup.Dzeta = 0.85;
			loadGroup.GammaGInf = 1;
			loadGroup.GammaGSup = 1.35;
			loadGroup.Psi0 = 0.7;
			loadGroup.Psi1 = 0.5;
			loadGroup.Psi2 = 0.3;
			iom.AddObject(loadGroup);

			loadGroup = new LoadGroupEC();
			loadGroup.Id = 3;
			loadGroup.Name = "Wind";
			loadGroup.Relation = Relation.Standard;
			loadGroup.GroupType = LoadGroupType.Variable;
			loadGroup.GammaQ = 1.5;
			loadGroup.Dzeta = 0.85;
			loadGroup.GammaGInf = 1;
			loadGroup.GammaGSup = 1.35;
			loadGroup.Psi0 = 0.7;
			loadGroup.Psi1 = 0.5;
			loadGroup.Psi2 = 0.3;
			iom.AddObject(loadGroup);

			//Load cases
			LoadCase loadCase = new LoadCase();
			loadCase.Id = 1;
			loadCase.Name = "STA1";
			loadCase.LoadType = LoadCaseType.Permanent;
			loadCase.Type = LoadCaseSubType.PermanentSelfweight;
			loadCase.Variable = VariableType.Standard;
			loadCase.LoadGroup = new ReferenceElement(iom.LoadGroup.FirstOrDefault(lg => lg.Id == 1));
			iom.AddObject(loadCase);

			loadCase = new LoadCase();
			loadCase.Id = 2;
			loadCase.Name = "EKSP2";
			loadCase.LoadType = LoadCaseType.Variable;
			loadCase.Type = LoadCaseSubType.VariableStatic;
			loadCase.Variable = VariableType.Standard;
			loadCase.LoadGroup = new ReferenceElement(iom.LoadGroup.FirstOrDefault(lg => lg.Id == 2));
			iom.AddObject(loadCase);

			loadCase = new LoadCase();
			loadCase.Id = 3;
			loadCase.Name = "SN1";
			loadCase.LoadType = LoadCaseType.Variable;
			loadCase.Type = LoadCaseSubType.VariableStatic;
			loadCase.Variable = VariableType.Standard;
			loadCase.LoadGroup = new ReferenceElement(iom.LoadGroup.FirstOrDefault(lg => lg.Id == 4));
			iom.AddObject(loadCase);

			loadCase = new LoadCase();
			loadCase.Id = 4;
			loadCase.Name = "WIATR1";
			loadCase.LoadType = LoadCaseType.Variable;
			loadCase.Type = LoadCaseSubType.VariableStatic;
			loadCase.Variable = VariableType.Standard;
			loadCase.LoadGroup = new ReferenceElement(iom.LoadGroup.FirstOrDefault(lg => lg.Id == 3));
			iom.AddObject(loadCase);

			loadCase = new LoadCase();
			loadCase.Id = 5;
			loadCase.Name = "WIATR2";
			loadCase.LoadType = LoadCaseType.Variable;
			loadCase.Type = LoadCaseSubType.VariableStatic;
			loadCase.Variable = VariableType.Standard;
			loadCase.LoadGroup = new ReferenceElement(iom.LoadGroup.FirstOrDefault(lg => lg.Id == 3));
			iom.AddObject(loadCase);

			loadCase = new LoadCase();
			loadCase.Id = 6;
			loadCase.Name = "WIATR3";
			loadCase.LoadType = LoadCaseType.Variable;
			loadCase.Type = LoadCaseSubType.VariableStatic;
			loadCase.Variable = VariableType.Standard;
			loadCase.LoadGroup = new ReferenceElement(iom.LoadGroup.FirstOrDefault(lg => lg.Id == 3));
			iom.AddObject(loadCase);

			loadCase = new LoadCase();
			loadCase.Id = 7;
			loadCase.Name = "WIATR4";
			loadCase.LoadType = LoadCaseType.Variable;
			loadCase.Type = LoadCaseSubType.VariableStatic;
			loadCase.Variable = VariableType.Standard;
			loadCase.LoadGroup = new ReferenceElement(iom.LoadGroup.FirstOrDefault(lg => lg.Id == 3));
			iom.AddObject(loadCase);

			// SLS linear combination
			CombiInputEC combi = new CombiInputEC();
			combi.Id = 1;
			combi.Name = "SGU:QPR/51=1*1.00";
			combi.Items.Add(new CombiItem() { Id = 1, Coeff = 1, LoadCase = new ReferenceElement(iom.LoadCase.FirstOrDefault(lc => lc.Id == 1))});
			combi.Items.Add(new CombiItem() { Id = 2, Coeff = 1, LoadCase = new ReferenceElement(iom.LoadCase.FirstOrDefault(lc => lc.Id == 2))});
			combi.Items.Add(new CombiItem() { Id = 3, Coeff = 1, LoadCase = new ReferenceElement(iom.LoadCase.FirstOrDefault(lc => lc.Id == 3))});
			combi.Items.Add(new CombiItem() { Id = 4, Coeff = 1, LoadCase = new ReferenceElement(iom.LoadCase.FirstOrDefault(lc => lc.Id == 4))});
			combi.Items.Add(new CombiItem() { Id = 5, Coeff = 1, LoadCase = new ReferenceElement(iom.LoadCase.FirstOrDefault(lc => lc.Id == 5))});
			combi.Items.Add(new CombiItem() { Id = 6, Coeff = 1, LoadCase = new ReferenceElement(iom.LoadCase.FirstOrDefault(lc => lc.Id == 6))});
			combi.Items.Add(new CombiItem() { Id = 7, Coeff = 1, LoadCase = new ReferenceElement(iom.LoadCase.FirstOrDefault(lc => lc.Id == 7))});
			combi.TypeCombiEC = TypeOfCombiEC.SLS_Char;
			// If you want SLS code-dependent combination, change TypeCalculationCombi to Code610. (For ULS code-dependent combination,
			// you can use Code610 or Code610ab.)
			combi.TypeCalculationCombi = TypeCalculationCombiEC.Linear;
			iom.AddObject(combi);
		}

		/// <summary>
		/// Creates the Open Model Results
		/// </summary>
		private void GenerateIOMResults()
		{
			iomResults = new OpenModelResult();

			ResultOnMembers resultOnMembers = new ResultOnMembers();

			foreach (int member in new List<int>() { 403, 405 })
			{
				// Members loop
				ResultOnMember resultOnMember = new ResultOnMember();
				resultOnMember.Member = new Member(MemberType.Member1D, member);
				resultOnMember.ResultType = ResultType.InternalForces;

				for (int i = 0; i < 11; i++)
				{
					// Member sections loop
					ResultOnSection resultOnSection = new ResultOnSection();
					resultOnSection.AbsoluteRelative = AbsoluteRelative.Relative;
					resultOnSection.Position = 0.1 * i;

					for (int iLc = 1; iLc < 8; iLc++)
					{
						// Member section load cases loop
						ResultOfInternalForces resultOfInternalForces = new ResultOfInternalForces();
						resultOfInternalForces.Loading = new ResultOfLoading();
						resultOfInternalForces.Loading.LoadingType = LoadingType.LoadCase;
						resultOfInternalForces.Loading.Id = iLc;
						resultOfInternalForces.Loading.Items.Add(new ResultOfLoadingItem() { Loading = new Loading(LoadingType.LoadCase, iLc), Coefficient = 1 });

						SetInternalForces(member, i, iLc, resultOfInternalForces);
						resultOnSection.Results.Add(resultOfInternalForces);
					}

					resultOnMember.Results.Add(resultOnSection);
				}

				resultOnMembers.Members.Add(resultOnMember);
			}

			iomResults.ResultOnMembers.Add(resultOnMembers);
		}

		/// <summary>
		/// Sets the internal forces
		/// </summary>
		/// <param name="member">The Id of the member</param>
		/// <param name="inx">The index of section</param>
		/// <param name="lc">The Id of Load case</param>
		/// <param name="resultOfInternalForces">Filled the internal forces</param>
		private void SetInternalForces(int member, int inx, int lc, ResultOfInternalForces resultOfInternalForces)
		{
			if (member == 403)
			{
				SetSampleInternalForces403(inx, lc, resultOfInternalForces);
			}

			if (member == 405)
			{
				SetSampleInternalForces405(inx, lc, resultOfInternalForces);
			}
		}

		#region Sample internal forces

		/// <summary>
		/// Sets the internal forces for member Id = 403
		/// </summary>
		/// <param name="inx">The index of section</param>
		/// <param name="lc">The Id of Load case</param>
		/// <param name="resultOfInternalForces">Filled the internal forces</param>
		private void SetSampleInternalForces403(int inx, int lc, ResultOfInternalForces resultOfInternalForces)
		{
			switch (inx)
			{
				case 0:
					switch (lc)
					{
						case 1:
							resultOfInternalForces.N = 31386.566859932838;
							resultOfInternalForces.Qy = 129.00679740530904;
							resultOfInternalForces.Qz = 105512.52746274776;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = -0;
							resultOfInternalForces.Mz = -0;
							break;

						case 2:
							resultOfInternalForces.N = 12785.332645068302;
							resultOfInternalForces.Qy = 14.989046922470124;
							resultOfInternalForces.Qz = 5473.3599668552633;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 3:

							resultOfInternalForces.N = 61347.441148914251;
							resultOfInternalForces.Qy = 71.921450927483249;
							resultOfInternalForces.Qz = 26262.643124079332;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 4:

							resultOfInternalForces.N = -29338.363114145752;
							resultOfInternalForces.Qy = -36.267593239498694;
							resultOfInternalForces.Qz = -10849.296713111922;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = -0;
							resultOfInternalForces.Mz = -0;
							break;

						case 5:

							resultOfInternalForces.N = -23032.99932384042;
							resultOfInternalForces.Qy = -26.468060083925479;
							resultOfInternalForces.Qz = -10349.028286246117;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = -0;
							resultOfInternalForces.Mz = -0;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}
					break;

				case 1:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 31725.78322232941;
							resultOfInternalForces.Qy = 1.2557124424037767;
							resultOfInternalForces.Qz = 97279.196016428628;
							resultOfInternalForces.Mx = -2219.7973160869878;
							resultOfInternalForces.My = 147354.45796112786;
							resultOfInternalForces.Mz = 75.925986269890515;
							break;

						case 2:

							resultOfInternalForces.N = 12808.316337312479;
							resultOfInternalForces.Qy = 5.5927654457134963;
							resultOfInternalForces.Qz = 5333.2619963692268;
							resultOfInternalForces.Mx = -782.094595248891;
							resultOfInternalForces.My = 7897.0359511748884;
							resultOfInternalForces.Mz = 17.747980295581364;
							break;

						case 3:

							resultOfInternalForces.N = 61457.723043558406;
							resultOfInternalForces.Qy = 26.835582498130861;
							resultOfInternalForces.Qz = 25590.415639729239;
							resultOfInternalForces.Mx = -3752.6987751037086;
							resultOfInternalForces.My = 37892.087891070667;
							resultOfInternalForces.Mz = 85.159550171757161;
							break;

						case 4:

							resultOfInternalForces.N = -29382.395058848873;
							resultOfInternalForces.Qy = -12.424336620569534;
							resultOfInternalForces.Qz = -10794.509225162678;
							resultOfInternalForces.Mx = 1777.3658879581126;
							resultOfInternalForces.My = -15788.973307390306;
							resultOfInternalForces.Mz = -41.351137942427663;
							break;

						case 5:

							resultOfInternalForces.N = -23076.892983439597;
							resultOfInternalForces.Qy = -10.192413203581964;
							resultOfInternalForces.Qz = -10020.441126747988;
							resultOfInternalForces.Mx = 1413.8993231949789;
							resultOfInternalForces.My = -14893.010249346664;
							resultOfInternalForces.Mz = -31.794712171304674;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 2:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 32090.22502547;
							resultOfInternalForces.Qy = -5.7714202268982149;
							resultOfInternalForces.Qz = 88723.146473985631;
							resultOfInternalForces.Mx = -3171.55033281364;
							resultOfInternalForces.My = 282333.26886884234;
							resultOfInternalForces.Mz = 69.458314600817829;
							break;

						case 2:

							resultOfInternalForces.N = 12842.707617524309;
							resultOfInternalForces.Qy = 1.3891033480423971;
							resultOfInternalForces.Qz = 5165.7285531704547;
							resultOfInternalForces.Mx = -1117.3566041815648;
							resultOfInternalForces.My = 15499.068653815488;
							resultOfInternalForces.Mz = 21.657817632386795;
							break;

						case 3:

							resultOfInternalForces.N = 61622.74159237706;
							resultOfInternalForces.Qy = 6.6652889060910638;
							resultOfInternalForces.Qz = 24786.545428974554;
							resultOfInternalForces.Mx = -5361.3754465811071;
							resultOfInternalForces.My = 74368.671396587379;
							resultOfInternalForces.Mz = 103.91999407122971;
							break;

						case 4:

							resultOfInternalForces.N = -29454.801195080079;
							resultOfInternalForces.Qy = -2.9749484035693285;
							resultOfInternalForces.Qz = -10622.779900932685;
							resultOfInternalForces.Mx = 2567.4925162922082;
							resultOfInternalForces.My = -31322.241155609408;
							resultOfInternalForces.Mz = -49.935893941120909;
							break;

						case 5:

							resultOfInternalForces.N = -23140.709804465521;
							resultOfInternalForces.Qy = -2.5632401113042533;
							resultOfInternalForces.Qz = -9657.8530446670484;
							resultOfInternalForces.Mx = 2011.9355084769413;
							resultOfInternalForces.My = -29134.214076343967;
							resultOfInternalForces.Mz = -38.948953627831877;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 3:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 32709.059801722611;
							resultOfInternalForces.Qy = 6.3870378762910605;
							resultOfInternalForces.Qz = 78594.803104372273;
							resultOfInternalForces.Mx = -3924.6699406229309;
							resultOfInternalForces.My = 403849.72283307969;
							resultOfInternalForces.Mz = 69.440448549165737;
							break;

						case 2:

							resultOfInternalForces.N = 12953.982073907348;
							resultOfInternalForces.Qy = 2.9027412996210842;
							resultOfInternalForces.Qz = 4530.6162047870457;
							resultOfInternalForces.Mx = -1379.6553807187338;
							resultOfInternalForces.My = 22554.278025489188;
							resultOfInternalForces.Mz = 24.103258880485004;
							break;

						case 3:

							resultOfInternalForces.N = 62156.666156931926;
							resultOfInternalForces.Qy = 13.928128112268496;
							resultOfInternalForces.Qz = 21739.10673504509;
							resultOfInternalForces.Mx = -6619.9550396706618;
							resultOfInternalForces.My = 108221.45049682293;
							resultOfInternalForces.Mz = 115.65387438425331;
							break;

						case 4:

							resultOfInternalForces.N = -29696.390324584136;
							resultOfInternalForces.Qy = -6.6726843072256088;
							resultOfInternalForces.Qz = -9691.7479708180763;
							resultOfInternalForces.Mx = 3303.7828929360185;
							resultOfInternalForces.My = -46114.767012903489;
							resultOfInternalForces.Mz = -55.302443079197182;
							break;

						case 5:

							resultOfInternalForces.N = -23345.10157457467;
							resultOfInternalForces.Qy = -5.2259688198685126;
							resultOfInternalForces.Qz = -8363.3003972475417;
							resultOfInternalForces.Mx = 2446.0723946414146;
							resultOfInternalForces.My = -42243.43543037057;
							resultOfInternalForces.Mz = -43.424452369409977;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 4:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 33154.342477996048;
							resultOfInternalForces.Qy = 10.741024446629126;
							resultOfInternalForces.Qz = 68971.107377836321;
							resultOfInternalForces.Mx = -3999.4978076703846;
							resultOfInternalForces.My = 511044.45928890037;
							resultOfInternalForces.Mz = 82.360190092695476;
							break;

						case 2:

							resultOfInternalForces.N = 13018.730508030611;
							resultOfInternalForces.Qy = 4.0017116229860221;
							resultOfInternalForces.Qz = 4171.56622732454;
							resultOfInternalForces.Mx = -1404.7437158943794;
							resultOfInternalForces.My = 28893.405696622813;
							resultOfInternalForces.Mz = 29.305825500020479;
							break;

						case 3:

							resultOfInternalForces.N = 62467.346438976005;
							resultOfInternalForces.Qy = 19.20128127218868;
							resultOfInternalForces.Qz = 20016.289036396891;
							resultOfInternalForces.Mx = -6740.33557326044;
							resultOfInternalForces.My = 138638.27832350248;
							resultOfInternalForces.Mz = 140.61717869264612;
							break;

						case 4:

							resultOfInternalForces.N = -29838.85528338069;
							resultOfInternalForces.Qy = -9.12474958276107;
							resultOfInternalForces.Qz = -9118.99378448259;
							resultOfInternalForces.Mx = 3422.4705228937673;
							resultOfInternalForces.My = -59805.337367710526;
							resultOfInternalForces.Mz = -67.195483274851952;
							break;

						case 5:

							resultOfInternalForces.N = -23463.493453037576;
							resultOfInternalForces.Qy = -7.2257058213958771;
							resultOfInternalForces.Qz = -7644.70736299362;
							resultOfInternalForces.Mx = 2473.8072667994566;
							resultOfInternalForces.My = -53907.986178067251;
							resultOfInternalForces.Mz = -52.809890292955743;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 5:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 33972.090973514525;
							resultOfInternalForces.Qy = 26.716323612674387;
							resultOfInternalForces.Qz = 57694.60967154165;
							resultOfInternalForces.Mx = -3414.58843871305;
							resultOfInternalForces.My = 603426.66874033131;
							resultOfInternalForces.Mz = 107.81927178998357;
							break;

						case 2:

							resultOfInternalForces.N = 13201.598470582831;
							resultOfInternalForces.Qy = 9.3840026712423423;
							resultOfInternalForces.Qz = 3315.33925002208;
							resultOfInternalForces.Mx = -1193.6006428381443;
							resultOfInternalForces.My = 34477.790774768036;
							resultOfInternalForces.Mz = 38.381860298318266;
							break;

						case 3:

							resultOfInternalForces.N = 63344.795769686112;
							resultOfInternalForces.Qy = 45.026951393942;
							resultOfInternalForces.Qz = 15907.883290540427;
							resultOfInternalForces.Mx = -5727.214709847176;
							resultOfInternalForces.My = 165433.64958788251;
							resultOfInternalForces.Mz = 184.16641797318073;
							break;

						case 4:

							resultOfInternalForces.N = -30243.543607410305;
							resultOfInternalForces.Qy = -21.423585577285394;
							resultOfInternalForces.Qz = -7722.4719358123839;
							resultOfInternalForces.Mx = 3171.6386543257977;
							resultOfInternalForces.My = -72287.435029256085;
							resultOfInternalForces.Mz = -87.864585936723813;
							break;

						case 5:

							resultOfInternalForces.N = -23797.2009255999;
							resultOfInternalForces.Qy = -16.93681068440219;
							resultOfInternalForces.Qz = -5939.8416040935554;
							resultOfInternalForces.Mx = 2026.6648211663924;
							resultOfInternalForces.My = -64063.304466789;
							resultOfInternalForces.Mz = -69.205546465363625;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 6:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 34506.913709975968;
							resultOfInternalForces.Qy = 48.44684999932042;
							resultOfInternalForces.Qz = 47346.135678045517;
							resultOfInternalForces.Mx = -2963.6466370737471;
							resultOfInternalForces.My = 680046.95594414778;
							resultOfInternalForces.Mz = 153.79777285580337;
							break;

						case 2:

							resultOfInternalForces.N = 13294.940962550638;
							resultOfInternalForces.Qy = 17.028580030824514;
							resultOfInternalForces.Qz = 2884.8601903821109;
							resultOfInternalForces.Mx = -1031.873733347129;
							resultOfInternalForces.My = 39104.425809357832;
							resultOfInternalForces.Mz = 54.548825870971584;
							break;

						case 3:

							resultOfInternalForces.N = 63792.677979127155;
							resultOfInternalForces.Qy = 81.7076755211101;
							resultOfInternalForces.Qz = 13842.329776042141;
							resultOfInternalForces.Mx = -4951.2057988644519;
							resultOfInternalForces.My = 187633.48031644424;
							resultOfInternalForces.Mz = 261.73983717668079;
							break;

						case 4:

							resultOfInternalForces.N = -30450.584348142351;
							resultOfInternalForces.Qy = -38.895575716626354;
							resultOfInternalForces.Qz = -7006.1588945491239;
							resultOfInternalForces.Mx = 2925.9940651405486;
							resultOfInternalForces.My = -83187.924735463632;
							resultOfInternalForces.Mz = -124.81668391293914;
							break;

						case 5:

							resultOfInternalForces.N = -23967.4022656538;
							resultOfInternalForces.Qy = -30.728632156731237;
							resultOfInternalForces.Qz = -5086.753926535137;
							resultOfInternalForces.Mx = 1699.4628690413592;
							resultOfInternalForces.My = -72317.182064290435;
							resultOfInternalForces.Mz = -98.3723481649744;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 7:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 35059.029558111339;
							resultOfInternalForces.Qy = 116.96334074524748;
							resultOfInternalForces.Qz = 36519.302472278694;
							resultOfInternalForces.Mx = -2393.0229019594844;
							resultOfInternalForces.My = 740841.64104965131;
							resultOfInternalForces.Mz = 269.70095104751374;
							break;

						case 2:

							resultOfInternalForces.N = 13392.27050573827;
							resultOfInternalForces.Qy = 41.14998329976288;
							resultOfInternalForces.Qz = 2377.1905660266057;
							resultOfInternalForces.Mx = -827.38062441812508;
							resultOfInternalForces.My = 42886.648346917966;
							resultOfInternalForces.Mz = 95.3078840016495;
							break;

						case 3:

							resultOfInternalForces.N = 64259.691125324462;
							resultOfInternalForces.Qy = 197.44861152677731;
							resultOfInternalForces.Qz = 11406.395313281566;
							resultOfInternalForces.Mx = -3969.9932396007061;
							resultOfInternalForces.My = 205781.59433108289;
							resultOfInternalForces.Mz = 457.31268531640922;
							break;

						case 4:

							resultOfInternalForces.N = -30666.329348826664;
							resultOfInternalForces.Qy = -94.435063519949836;
							resultOfInternalForces.Qz = -6156.5121690309606;
							resultOfInternalForces.Mx = 2604.9698254094837;
							resultOfInternalForces.My = -92679.031035923588;
							resultOfInternalForces.Mz = -218.143888275807;
							break;

						case 5:

							resultOfInternalForces.N = -24144.913428696513;
							resultOfInternalForces.Qy = -74.129940816582348;
							resultOfInternalForces.Qz = -4082.0933424746618;
							resultOfInternalForces.Mx = 1288.7152984532586;
							resultOfInternalForces.My = -78898.898499291536;
							resultOfInternalForces.Mz = -171.8582611823945;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 8:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 35638.782360685145;
							resultOfInternalForces.Qy = 481.01453886495074;
							resultOfInternalForces.Qz = 24617.646517155968;
							resultOfInternalForces.Mx = -1502.5700565683655;
							resultOfInternalForces.My = 785060.818857192;
							resultOfInternalForces.Mz = 652.2322659330722;
							break;

						case 2:

							resultOfInternalForces.N = 13494.655834124947;
							resultOfInternalForces.Qy = 169.24951625623908;
							resultOfInternalForces.Qz = 1578.6842632594053;
							resultOfInternalForces.Mx = -508.3207199521421;
							resultOfInternalForces.My = 45692.108687558466;
							resultOfInternalForces.Mz = 229.94161198080718;
							break;

						case 3:

							resultOfInternalForces.N = 64750.963279445888;
							resultOfInternalForces.Qy = 812.104387661173;
							resultOfInternalForces.Qz = 7574.9487813860178;
							resultOfInternalForces.Mx = -2439.0585931397509;
							resultOfInternalForces.My = 219242.94241966325;
							resultOfInternalForces.Mz = 1103.3212744881328;
							break;

						case 4:

							resultOfInternalForces.N = -30889.40386141371;
							resultOfInternalForces.Qy = -391.87719014888353;
							resultOfInternalForces.Qz = -4818.406530380249;
							resultOfInternalForces.Mx = 2105.8111734854756;
							resultOfInternalForces.My = -100534.02323260591;
							resultOfInternalForces.Mz = -528.55195280680914;
							break;

						case 5:

							resultOfInternalForces.N = -24332.753232010466;
							resultOfInternalForces.Qy = -303.90532847275244;
							resultOfInternalForces.Qz = -2502.365181135945;
							resultOfInternalForces.Mx = 647.35629088665883;
							resultOfInternalForces.My = -83548.031851537773;
							resultOfInternalForces.Mz = -413.984545779469;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 9:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 35789.71860244398;
							resultOfInternalForces.Qy = 973.35592450017793;
							resultOfInternalForces.Qz = 12917.251115624615;
							resultOfInternalForces.Mx = -765.41481397589087;
							resultOfInternalForces.My = 812370.7989893849;
							resultOfInternalForces.Mz = 1710.5316045069285;
							break;

						case 2:

							resultOfInternalForces.N = 13448.068817789987;
							resultOfInternalForces.Qy = 342.60607838723718;
							resultOfInternalForces.Qz = 945.77558252518065;
							resultOfInternalForces.Mx = -245.70085776982887;
							resultOfInternalForces.My = 47537.073362388874;
							resultOfInternalForces.Mz = 602.55944602160025;
							break;

						case 3:

							resultOfInternalForces.N = 64527.426331189112;
							resultOfInternalForces.Qy = 1643.9154785532082;
							resultOfInternalForces.Qz = 4538.0838736300357;
							resultOfInternalForces.Mx = -1178.9383453924966;
							resultOfInternalForces.My = 228095.57574299275;
							resultOfInternalForces.Mz = 2891.2411731598977;
							break;

						case 4:

							resultOfInternalForces.N = -30772.669923671288;
							resultOfInternalForces.Qy = -798.04094601089673;
							resultOfInternalForces.Qz = -3765.8783903117292;
							resultOfInternalForces.Mx = 1700.1000514246698;
							resultOfInternalForces.My = -106786.09044510106;
							resultOfInternalForces.Mz = -1394.2122934801932;
							break;

						case 5:

							resultOfInternalForces.N = -24251.634831235278;
							resultOfInternalForces.Qy = -613.820379462677;
							resultOfInternalForces.Qz = -1247.9404625711031;
							resultOfInternalForces.Mx = 117.9792358273553;
							resultOfInternalForces.My = -86295.068706109;
							resultOfInternalForces.Mz = -1082.2282692301551;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 10:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 35497.571158765692;
							resultOfInternalForces.Qy = 1155.4030643425358;
							resultOfInternalForces.Qz = 1764.1930319341454;
							resultOfInternalForces.Mx = -324.95636427780846;
							resultOfInternalForces.My = 822812.64178607834;
							resultOfInternalForces.Mz = 3383.4831460694886;
							break;

						case 2:

							resultOfInternalForces.N = 13245.59221207691;
							resultOfInternalForces.Qy = 407.65260627651151;
							resultOfInternalForces.Qz = 600.85919631909428;
							resultOfInternalForces.Mx = -96.868910563345707;
							resultOfInternalForces.My = 48571.206246943562;
							resultOfInternalForces.Mz = 1191.5359532370103;
							break;

						case 3:

							resultOfInternalForces.N = 63555.889493086608;
							resultOfInternalForces.Qy = 1956.0260941281813;
							resultOfInternalForces.Qz = 2883.0829212863173;
							resultOfInternalForces.Mx = -464.80290780379437;
							resultOfInternalForces.My = 233057.62155347306;
							resultOfInternalForces.Mz = 5717.30777792237;
							break;

						case 4:

							resultOfInternalForces.N = -30296.112332221295;
							resultOfInternalForces.Qy = -958.52693818797343;
							resultOfInternalForces.Qz = -3198.3652420514845;
							resultOfInternalForces.Mx = 1459.0528077063791;
							resultOfInternalForces.My = -111697.03971697576;
							resultOfInternalForces.Mz = -2776.2601583344735;
							break;

						case 5:

							resultOfInternalForces.N = -23890.280197610089;
							resultOfInternalForces.Qy = -727.79585022570973;
							resultOfInternalForces.Qz = -562.57824182177137;
							resultOfInternalForces.Mx = -178.85147910330852;
							resultOfInternalForces.My = -87432.952573369243;
							resultOfInternalForces.Mz = -2134.5568684296727;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;
			}
		}

		/// <summary>
		/// Sets the internal forces for member Id = 405
		/// </summary>
		/// <param name="inx">The index of section</param>
		/// <param name="lc">The Id of Load case</param>
		/// <param name="resultOfInternalForces">Filled the internal forces</param>
		private void SetSampleInternalForces405(int inx, int lc, ResultOfInternalForces resultOfInternalForces)
		{
			switch (inx)
			{
				case 0:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 34097.041791308046;
							resultOfInternalForces.Qy = -1142.8161428474705;
							resultOfInternalForces.Qz = -1688.0214885667888;
							resultOfInternalForces.Mx = 68.59445862051507;
							resultOfInternalForces.My = 822774.3775057958;
							resultOfInternalForces.Mz = 3420.2121611206821;
							break;

						case 2:

							resultOfInternalForces.N = 12749.570780202514;
							resultOfInternalForces.Qy = -403.58462915471137;
							resultOfInternalForces.Qz = -575.33225969102932;
							resultOfInternalForces.Mx = 14.893024130535196;
							resultOfInternalForces.My = 48557.352070289824;
							resultOfInternalForces.Mz = 1204.9959448330919;
							break;

						case 3:

							resultOfInternalForces.N = 61175.846169592813;
							resultOfInternalForces.Qy = -1936.5068532881487;
							resultOfInternalForces.Qz = -2760.5978606261779;
							resultOfInternalForces.Mx = 71.4607079520938;
							resultOfInternalForces.My = 232991.14551316592;
							resultOfInternalForces.Mz = 5781.8924129283223;
							break;

						case 4:

							resultOfInternalForces.N = -29247.393531820737;
							resultOfInternalForces.Qy = 912.15101991684423;
							resultOfInternalForces.Qz = -519.84697927464731;
							resultOfInternalForces.Mx = 1208.7691316284327;
							resultOfInternalForces.My = -111675.64192814005;
							resultOfInternalForces.Mz = -2738.3207652000528;
							break;

						case 5:

							resultOfInternalForces.N = -22971.118622262497;
							resultOfInternalForces.Qy = 731.050511661073;
							resultOfInternalForces.Qz = 1562.2012606993085;
							resultOfInternalForces.Mx = -381.95689690027211;
							resultOfInternalForces.My = -87405.024536076584;
							resultOfInternalForces.Mz = -2178.4698172470407;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 1:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 31649.03190610107;
							resultOfInternalForces.Qy = -1056.1336531002544;
							resultOfInternalForces.Qz = -13121.621583836813;
							resultOfInternalForces.Mx = 637.39007816957019;
							resultOfInternalForces.My = 812357.70940363756;
							resultOfInternalForces.Mz = 1737.3375104152076;
							break;

						case 2:

							resultOfInternalForces.N = 11981.924331432907;
							resultOfInternalForces.Qy = -371.15592220059807;
							resultOfInternalForces.Qz = -1019.1428114786977;
							resultOfInternalForces.Mx = 208.15219653247186;
							resultOfInternalForces.My = 47530.888781303292;
							resultOfInternalForces.Mz = 612.1975157337688;
							break;

						case 3:

							resultOfInternalForces.N = 57492.473460604437;
							resultOfInternalForces.Qy = -1780.9052551859022;
							resultOfInternalForces.Qz = -4890.1194357448258;
							resultOfInternalForces.Mx = 998.76983912085416;
							resultOfInternalForces.My = 228065.90047097849;
							resultOfInternalForces.Mz = 2937.4872060838197;
							break;

						case 4:

							resultOfInternalForces.N = -27470.900236962363;
							resultOfInternalForces.Qy = 841.47604546373441;
							resultOfInternalForces.Qz = 787.81166595465038;
							resultOfInternalForces.Mx = 646.54291644408659;
							resultOfInternalForces.My = -111868.84913001831;
							resultOfInternalForces.Mz = -1399.2007526536841;
							break;

						case 5:

							resultOfInternalForces.N = -21592.471146674361;
							resultOfInternalForces.Qy = 671.56139584615448;
							resultOfInternalForces.Qz = 2279.0904322452843;
							resultOfInternalForces.Mx = -696.18623046384891;
							resultOfInternalForces.My = -84827.65553976917;
							resultOfInternalForces.Mz = -1104.4851093304956;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 2:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 28173.815930944955;
							resultOfInternalForces.Qy = -502.00759709466729;
							resultOfInternalForces.Qz = -24540.266010678552;
							resultOfInternalForces.Mx = 1283.3609343392309;
							resultOfInternalForces.My = 784946.64484365028;
							resultOfInternalForces.Mz = 636.03068015506119;
							break;

						case 2:

							resultOfInternalForces.N = 10851.097911365796;
							resultOfInternalForces.Qy = -176.28463900926363;
							resultOfInternalForces.Qz = -1551.9488822314888;
							resultOfInternalForces.Mx = 438.61383405304514;
							resultOfInternalForces.My = 45648.744888214409;
							resultOfInternalForces.Mz = 224.84057698728844;
							break;

						case 3:

							resultOfInternalForces.N = 52066.46623952128;
							resultOfInternalForces.Qy = -845.86078579540481;
							resultOfInternalForces.Qz = -7446.6652822829783;
							resultOfInternalForces.Mx = 2104.586335072061;
							resultOfInternalForces.My = 219034.87132728062;
							resultOfInternalForces.Mz = 1078.8451460384708;
							break;

						case 4:

							resultOfInternalForces.N = -24860.839617533609;
							resultOfInternalForces.Qy = 403.28345419670586;
							resultOfInternalForces.Qz = 2354.273622197099;
							resultOfInternalForces.Mx = -62.400760110816918;
							resultOfInternalForces.My = -109543.26914214919;
							resultOfInternalForces.Mz = -516.46920959053773;
							break;

						case 5:

							resultOfInternalForces.N = -19559.600691474043;
							resultOfInternalForces.Qy = 317.93269750949912;
							resultOfInternalForces.Qz = 3140.7105044680648;
							resultOfInternalForces.Mx = -1059.9080607843061;
							resultOfInternalForces.My = -80867.4105418414;
							resultOfInternalForces.Mz = -404.90278642860278;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 3:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 22921.197503015243;
							resultOfInternalForces.Qy = -137.44351787979031;
							resultOfInternalForces.Qz = -36453.365422590316;
							resultOfInternalForces.Mx = 2229.2017715550755;
							resultOfInternalForces.My = 740580.34354633442;
							resultOfInternalForces.Mz = 226.07506817842932;
							break;

						case 2:

							resultOfInternalForces.N = 9093.2275041218381;
							resultOfInternalForces.Qy = -46.379864420890044;
							resultOfInternalForces.Qz = -2354.2165489676408;
							resultOfInternalForces.Mx = 777.43432279651461;
							resultOfInternalForces.My = 42789.38044133842;
							resultOfInternalForces.Mz = 81.993264645387839;
							break;

						case 3:

							resultOfInternalForces.N = 43631.734476832673;
							resultOfInternalForces.Qy = -222.54297811016841;
							resultOfInternalForces.Qz = -11296.159843189642;
							resultOfInternalForces.Mx = 3730.337543208967;
							resultOfInternalForces.My = 205314.87693860362;
							resultOfInternalForces.Mz = 393.42558514705877;
							break;

						case 4:

							resultOfInternalForces.N = -20804.96665173769;
							resultOfInternalForces.Qy = 107.42515150937561;
							resultOfInternalForces.Qz = 4700.5489643802866;
							resultOfInternalForces.Mx = -1092.4477974050242;
							resultOfInternalForces.My = -104353.57052842969;
							resultOfInternalForces.Mz = -188.54895865271112;
							break;

						case 5:

							resultOfInternalForces.N = -16399.082823900506;
							resultOfInternalForces.Qy = 83.269052145808928;
							resultOfInternalForces.Qz = 4441.6323876781389;
							resultOfInternalForces.Mx = -1598.1392510414007;
							resultOfInternalForces.My = -75324.31464774342;
							resultOfInternalForces.Mz = -147.59803351360893;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 4:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 19381.475922100031;
							resultOfInternalForces.Qy = -85.155566668840947;
							resultOfInternalForces.Qz = -47253.14335176535;
							resultOfInternalForces.Mx = 2791.2004447451909;
							resultOfInternalForces.My = 679776.37477047357;
							resultOfInternalForces.Mz = 70.871517773094808;
							break;

						case 2:

							resultOfInternalForces.N = 7936.2560302263591;
							resultOfInternalForces.Qy = -25.22779743901242;
							resultOfInternalForces.Qz = -2852.386883839732;
							resultOfInternalForces.Mx = 978.62295648712461;
							resultOfInternalForces.My = 39002.811054498372;
							resultOfInternalForces.Mz = 31.940552113701564;
							break;

						case 3:

							resultOfInternalForces.N = 38080.27630386129;
							resultOfInternalForces.Qy = -121.04971075639151;
							resultOfInternalForces.Qz = -13686.514177216217;
							resultOfInternalForces.Mx = 4695.69434761288;
							resultOfInternalForces.My = 187145.90557987307;
							resultOfInternalForces.Mz = 153.25930074365726;
							break;

						case 4:

							resultOfInternalForces.N = -18135.785256677307;
							resultOfInternalForces.Qy = 59.313093930781179;
							resultOfInternalForces.Qz = 6160.2442565592937;
							resultOfInternalForces.Mx = -1706.8046855481371;
							resultOfInternalForces.My = -96449.33578434863;
							resultOfInternalForces.Mz = -72.047249752664385;
							break;

						case 5:

							resultOfInternalForces.N = -14318.861886649393;
							resultOfInternalForces.Qy = 45.041704012757236;
							resultOfInternalForces.Qz = 5248.65226982045;
							resultOfInternalForces.Mx = -1916.9579257831792;
							resultOfInternalForces.My = -68278.5255098113;
							resultOfInternalForces.Mz = -57.89757097861829;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 5:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 13107.473336811174;
							resultOfInternalForces.Qy = -105.35538025093501;
							resultOfInternalForces.Qz = -58893.155998968272;
							resultOfInternalForces.Mx = 3438.8322116472846;
							resultOfInternalForces.My = 603155.15246194613;
							resultOfInternalForces.Mz = -53.948517630839824;
							break;

						case 2:

							resultOfInternalForces.N = 5808.706758674467;
							resultOfInternalForces.Qy = -23.873530229322341;
							resultOfInternalForces.Qz = -3744.3714270065539;
							resultOfInternalForces.Mx = 1210.8518374783162;
							resultOfInternalForces.My = 34375.157514167586;
							resultOfInternalForces.Mz = -0.8504949597833944;
							break;

						case 3:

							resultOfInternalForces.N = 27871.726604526863;
							resultOfInternalForces.Qy = -114.55157495043022;
							resultOfInternalForces.Qz = -17966.494275541045;
							resultOfInternalForces.Mx = 5809.9905497648288;
							resultOfInternalForces.My = 164941.18778871754;
							resultOfInternalForces.Mz = -4.0809019954304793;
							break;

						case 4:

							resultOfInternalForces.N = -13229.210234817118;
							resultOfInternalForces.Qy = 57.198914927442274;
							resultOfInternalForces.Qz = 8786.49463400431;
							resultOfInternalForces.Mx = -2461.3714752451342;
							resultOfInternalForces.My = -86076.921245333535;
							resultOfInternalForces.Mz = 5.7754246690006514;
							break;

						case 5:

							resultOfInternalForces.N = -10493.047968509607;
							resultOfInternalForces.Qy = 42.318127155639104;
							resultOfInternalForces.Qz = 6690.0284680840559;
							resultOfInternalForces.Mx = -2271.9869505909664;
							resultOfInternalForces.My = -59871.266679008841;
							resultOfInternalForces.Mz = 0.43966628146827791;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 6:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 9610.4318985061436;
							resultOfInternalForces.Qy = -73.082784658246965;
							resultOfInternalForces.Qz = -68949.286055997683;
							resultOfInternalForces.Mx = 3606.4471550565067;
							resultOfInternalForces.My = 510738.43817486626;
							resultOfInternalForces.Mz = -208.29763945330649;
							break;

						case 2:

							resultOfInternalForces.N = 4649.4157790779136;
							resultOfInternalForces.Qy = -16.154574491817129;
							resultOfInternalForces.Qz = -4163.823253543349;
							resultOfInternalForces.Mx = 1271.6272746331088;
							resultOfInternalForces.My = 28778.093435728035;
							resultOfInternalForces.Mz = -35.370253744151384;
							break;

						case 3:

							resultOfInternalForces.N = 22309.138823643327;
							resultOfInternalForces.Qy = -77.513963496758151;
							resultOfInternalForces.Qz = -19979.136179920286;
							resultOfInternalForces.Mx = 6101.6073310634238;
							resultOfInternalForces.My = 138084.97929419309;
							resultOfInternalForces.Mz = -169.71592529100124;
							break;

						case 4:

							resultOfInternalForces.N = -10557.549106777646;
							resultOfInternalForces.Qy = 38.656401627195009;
							resultOfInternalForces.Qz = 10042.398901048116;
							resultOfInternalForces.Mx = -2715.3903829353076;
							resultOfInternalForces.My = -72839.46939410067;
							resultOfInternalForces.Mz = 88.593182635071386;
							break;

						case 5:

							resultOfInternalForces.N = -8407.8361695171334;
							resultOfInternalForces.Qy = 28.649411143568614;
							resultOfInternalForces.Qz = 7361.8517369925976;
							resultOfInternalForces.Mx = -2348.7440511169989;
							resultOfInternalForces.My = -49900.609758049606;
							resultOfInternalForces.Mz = 61.597428447026289;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 7:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 6810.574783120147;
							resultOfInternalForces.Qy = 109.9328914608468;
							resultOfInternalForces.Qz = -78485.624962986229;
							resultOfInternalForces.Mx = 3585.9574355025397;
							resultOfInternalForces.My = 403600.19692531845;
							resultOfInternalForces.Mz = -190.55000421749554;
							break;

						case 2:

							resultOfInternalForces.N = 3727.4829817665741;
							resultOfInternalForces.Qy = 19.3294089367746;
							resultOfInternalForces.Qz = -4491.3153197173961;
							resultOfInternalForces.Mx = 1265.5606296786282;
							resultOfInternalForces.My = 22459.407237098505;
							resultOfInternalForces.Mz = -34.871910446796264;
							break;

						case 3:

							resultOfInternalForces.N = 17885.459002611227;
							resultOfInternalForces.Qy = 92.747667196526891;
							resultOfInternalForces.Qz = -21550.530590721406;
							resultOfInternalForces.Mx = 6072.4979480923212;
							resultOfInternalForces.My = 107766.2351128212;
							resultOfInternalForces.Mz = -167.32474103988943;
							break;

						case 4:

							resultOfInternalForces.N = -8434.4532304718159;
							resultOfInternalForces.Qy = -48.147206210050172;
							resultOfInternalForces.Qz = 11036.542664058507;
							resultOfInternalForces.Mx = -2787.5422059740376;
							resultOfInternalForces.My = -57430.623801369395;
							resultOfInternalForces.Mz = 86.086420300559382;
							break;

						case 5:

							resultOfInternalForces.N = -6749.1144036334008;
							resultOfInternalForces.Qy = -33.738774470323733;
							resultOfInternalForces.Qz = 7882.5054530017078;
							resultOfInternalForces.Mx = -2313.22263121773;
							resultOfInternalForces.My = -38777.222410766648;
							resultOfInternalForces.Mz = 61.089145583412616;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 8:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = 894.42414207378681;
							resultOfInternalForces.Qy = 2265.9082251454911;
							resultOfInternalForces.Qz = -88612.59748102077;
							resultOfInternalForces.Mx = 2705.1036940140766;
							resultOfInternalForces.My = 282144.3511690711;
							resultOfInternalForces.Mz = 768.45258094376732;
							break;

						case 2:

							resultOfInternalForces.N = 1688.7690246684942;
							resultOfInternalForces.Qy = 432.65312535044325;
							resultOfInternalForces.Qz = -5125.4829024802893;
							resultOfInternalForces.Mx = 955.96733602381573;
							resultOfInternalForces.My = 15427.034383567947;
							resultOfInternalForces.Mz = 141.54670518483684;
							break;

						case 3:

							resultOfInternalForces.N = 8103.16487103235;
							resultOfInternalForces.Qy = 2075.98526239179;
							resultOfInternalForces.Qz = -24593.436046833172;
							resultOfInternalForces.Mx = 4586.9866289255151;
							resultOfInternalForces.My = 74023.031726589776;
							resultOfInternalForces.Mz = 679.17890032744344;
							break;

						case 4:

							resultOfInternalForces.N = -3739.7630774602294;
							resultOfInternalForces.Qy = -1056.3060545030094;
							resultOfInternalForces.Qz = 13057.058842666913;
							resultOfInternalForces.Mx = -2211.6028697205475;
							resultOfInternalForces.My = -39822.769181991745;
							resultOfInternalForces.Mz = -347.55209918573189;
							break;

						case 5:

							resultOfInternalForces.N = -3081.0430099102668;
							resultOfInternalForces.Qy = -761.28880671737454;
							resultOfInternalForces.Qz = 8863.4554624748416;
							resultOfInternalForces.Mx = -1717.0617771669276;
							resultOfInternalForces.My = -26528.493290482609;
							resultOfInternalForces.Mz = -248.49987582967751;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 9:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = -2559.3425326759834;
							resultOfInternalForces.Qy = 3232.9240725669042;
							resultOfInternalForces.Qz = -97268.601432629686;
							resultOfInternalForces.Mx = 1624.5679899018287;
							resultOfInternalForces.My = 147277.5664412932;
							resultOfInternalForces.Mz = 4829.3785769381466;
							break;

						case 2:

							resultOfInternalForces.N = 607.81710193865;
							resultOfInternalForces.Qy = 648.89929442406583;
							resultOfInternalForces.Qz = -5327.1586678934982;
							resultOfInternalForces.Mx = 574.376398542503;
							resultOfInternalForces.My = 7866.8381623419082;
							resultOfInternalForces.Mz = 900.76091947324892;
							break;

						case 3:

							resultOfInternalForces.N = 2916.4688102975488;
							resultOfInternalForces.Qy = 3113.5921436275021;
							resultOfInternalForces.Qz = -25561.130239401944;
							resultOfInternalForces.Mx = 2756.0113832384523;
							resultOfInternalForces.My = 37747.190833978289;
							resultOfInternalForces.Mz = 4322.0914959400952;
							break;

						case 4:

							resultOfInternalForces.N = -1238.121669662185;
							resultOfInternalForces.Qy = -1573.8097042142181;
							resultOfInternalForces.Qz = 13767.67259050021;
							resultOfInternalForces.Mx = -1360.6609787423658;
							resultOfInternalForces.My = -20465.485259117842;
							resultOfInternalForces.Mz = -2205.8050192472006;
							break;

						case 5:

							resultOfInternalForces.N = -1139.7444020016119;
							resultOfInternalForces.Qy = -1144.7783508093817;
							resultOfInternalForces.Qz = 9155.9691295383964;
							resultOfInternalForces.Mx = -1022.5645853494571;
							resultOfInternalForces.My = -13482.663696292368;
							resultOfInternalForces.Mz = -1583.0682537779389;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;

				case 10:
					switch (lc)
					{
						case 1:

							resultOfInternalForces.N = -3546.227107477504;
							resultOfInternalForces.Qy = -6092.4672922034952;
							resultOfInternalForces.Qz = -105563.84001317604;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 2.766000761766918E-10;
							resultOfInternalForces.Mz = 1.1823431123048067E-11;
							break;

						case 2:

							resultOfInternalForces.N = -61.323432624107227;
							resultOfInternalForces.Qy = -1193.0044694479439;
							resultOfInternalForces.Qz = -5492.5451639468083;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 1.5006662579253316E-10;
							resultOfInternalForces.Mz = -1.8189894035458565E-12;
							break;

						case 3:

							resultOfInternalForces.N = -294.24621007591486;
							resultOfInternalForces.Qy = -5724.3541105579934;
							resultOfInternalForces.Qz = -26354.698824259453;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 3.8198777474462986E-10;
							resultOfInternalForces.Mz = -6.3664629124104977E-12;
							break;

						case 4:

							resultOfInternalForces.N = 241.09501381358132;
							resultOfInternalForces.Qy = 2903.0143234945426;
							resultOfInternalForces.Qz = 14350.34978080634;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = -7.2759576141834259E-12;
							resultOfInternalForces.Mz = -1.0459189070388675E-11;
							break;

						case 5:

							resultOfInternalForces.N = 81.796144786290824;
							resultOfInternalForces.Qy = 2101.949746787941;
							resultOfInternalForces.Qz = 9395.8681797530735;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = -7.8216544352471828E-11;
							resultOfInternalForces.Mz = -6.8212102632969618E-12;
							break;

						case 6:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;

						case 7:

							resultOfInternalForces.N = -0;
							resultOfInternalForces.Qy = 0;
							resultOfInternalForces.Qz = 0;
							resultOfInternalForces.Mx = -0;
							resultOfInternalForces.My = 0;
							resultOfInternalForces.Mz = -0;
							break;
					}

					break;
			}
		}

		#endregion Sample internal forces
	}
}