using IdeaRS.OpenModel.Geometry3D;
using IdeaRS.OpenModel.Model;
using System;
using System.Collections.Generic;


namespace IdeaRS.OpenModel.Connection
{
	/// <summary>
	/// Provides data of the connection
	/// </summary>
	///
	public class ConnectionData
	{
		/// <summary>
		/// Connected beams
		/// </summary>
		public List<BeamData> Beams { get; set; }

		/// <summary>
		/// Plates of the connection
		/// </summary>
		public List<PlateData> Plates { get; set; }

		/// <summary>
		/// Bolt grids which belongs to the connection
		/// </summary>
		public List<BoltGrid> BoltGrids { get; set; }

		/// <summary>
		/// Welds of the connection
		/// </summary>
		public List<WeldData> Welds { get; set; }

		/// <summary>
		/// ConcreteBlocksof the connection
		/// </summary>
		public List<ConcreteBlockData> ConcreteBlocks { get; set; }
	}

	/// <summary>
	/// Provides data of the single concrete block
	/// </summary>
	public class ConcreteBlockData
	{
		/// <summary>
		/// Plate unique ID
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of the concrete block
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Depth of the concrete block
		/// </summary>
		public double Depth { get; set; }

		/// <summary>
		/// Name of the material
		/// </summary>
		public string Material { get; set; }

		/// <summary>
		/// Center of the concrete block LCS
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Point3D Center { get; set; }

		/// <summary>
		/// Outline points
		/// </summary>
		public List<IdeaRS.OpenModel.Geometry2D.Point2D> OutlinePoints { get; set; }

		/// <summary>
		/// Origin of the concrete block LCS
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Point3D Origin { get; set; }

		/// <summary>
		/// LCS - Axis X
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisX { get; set; }

		/// <summary>
		/// LCS - Axis Y
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisY { get; set; }

		/// <summary>
		/// LCS - Axis Z
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisZ { get; set; }

		/// <summary>
		/// Geometry of the concrete block in svg format
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// Get or set the identification in the original model
		/// In the case of the imported connection from another application
		/// </summary>
		public string OriginalModelId { get; set; }
	}

	/// <summary>
	/// Data of the bolt grid
	/// </summary>
	public class BoltGrid
	{
		/// <summary>
		/// Unique Id of the bolt grid
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Is Anchor
		/// </summary>
		public bool IsAnchor { get; set; }

		/// <summary>
		/// Anchor lenght
		/// </summary>
		public double AnchorLen { get; set; }

		/// <summary>
		/// The diameter of the hole
		/// </summary>
		public double HoleDiameter { get; set; }

		/// <summary>
		/// The diameter of bold
		/// </summary>
		public double Diameter { get; set; }

		/// <summary>
		/// The head diameter of bold
		/// </summary>
		public double HeadDiameter { get; set; }

		/// <summary>
		/// The Diagonal Head Diameter of bold
		/// </summary>
		public double DiagonalHeadDiameter { get; set; }

		/// <summary>
		/// The Head Height of bold
		/// </summary>
		public double HeadHeight { get; set; }

		/// <summary>
		/// The BoreHole of bold
		/// </summary>
		public double BoreHole { get; set; }

		/// <summary>
		/// The Tensile Stress Area of bold
		/// </summary>
		public double TensileStressArea { get; set; }

		/// <summary>
		/// The Nut Thickness of bold
		/// </summary>
		public double NutThickness { get; set; }

		/// <summary>
		/// The description of the bolt assembly
		/// </summary>
		public string BoltAssemblyName { get; set; }

		/// <summary>
		/// The standard of the bolt assembly
		/// </summary>
		public string Standard { get; set; }

		/// <summary>
		/// The material of the bolt assembly
		/// </summary>
		public string Material { get; set; }

		/// <summary>
		/// Origin of the bolt grid LCS
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Point3D Origin { get; set; }

		/// <summary>
		/// Bolt grid LCS - Axis X
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisX { get; set; }

		/// <summary>
		/// Bolt grid LCS - Axis Y
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisY { get; set; }

		/// <summary>
		/// Bolt grid LCS - Axis Z
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisZ { get; set; }

		/// <summary>
		/// Positions of holes in the local coodinate system of the bolt grid
		/// </summary>
		public List<IdeaRS.OpenModel.Geometry3D.Point3D> Positions { get; set; }

		/// <summary>
		/// Identifiers of the connected plates
		/// </summary>
		public List<int> ConnectedPlates { get; set; }

		/// <summary>
		/// Id of the weld
		/// </summary>
		public List<string> ConnectedPartIds { get; set; }
	}

	/// <summary>
	/// Provides data of the connected beam
	/// </summary>
	public class BeamData
	{
		/// <summary>
		/// Id of the beam
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of the beam
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Plates of the beam
		/// </summary>
		public List<PlateData> Plates { get; set; }

		/// <summary>
		/// Type of cross section
		/// </summary>
		public string CrossSectionType { get; set; }

		/// <summary>
		/// MPRL name of beam
		/// </summary>
		public string MPRLName { get; set; }

		/// <summary>
		/// Get or set the identification in the original model
		/// In the case of the imported connection from another application
		/// </summary>
		public string OriginalModelId { get; set; }

		/// <summary>
		/// Cuts on the beam
		/// </summary>
		public List<CutData> Cuts { get; set; }

		/// <summary>
		/// Is addes beam
		/// </summary>
		public bool IsAdded { get; set; }

		/// <summary>
		/// Added member
		/// </summary>
		public Member1D AddedMember { get; set; }

		/// <summary>
		/// Mirro by Y
		/// </summary>
		public bool MirrorY { get; set; }
	}

	/// <summary>
	///enum of weld types
	/// </summary>
	public enum WeldType : int
	{
		/// <summary>
		/// NotSpecified
		/// </summary>
		NotSpecified = 0,

		/// <summary>
		/// Fillet
		/// </summary>
		Fillet = 1,

		/// <summary>
		/// DoubleFillet
		/// </summary>
		DoubleFillet = 2,

		/// <summary>
		/// Bevel
		/// </summary>
		Bevel = 4,

		/// <summary>
		/// Square
		/// </summary>
		Square = 8,

		/// <summary>
		/// Plug
		/// </summary>
		Plug = 16,

		/// <summary>
		/// LengthAtHaunch
		/// </summary>
		LengthAtHaunch = 32,

		/// <summary>
		/// FilletRear
		/// </summary>
		FilletRear = 64,

		/// <summary>
		/// Contact
		/// </summary>
		Contact = 128,

		/// <summary>
		/// Intermittent
		/// </summary>
		Intermittent = 256,
	}

	/// <summary>
	/// Provides data of the single weld
	/// </summary>
	public class WeldData
	{
		/// <summary>
		/// Id of the weld
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of the weld
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Thickness of the weld
		/// </summary>
		public double Thickness { get; set; }

		/// <summary>
		/// Name of the material
		/// </summary>
		public string Material { get; set; }

		/// <summary>
		/// Type of the weld
		/// </summary>
		public WeldType WeldType { get; set; }

		/// <summary>
		/// Id of the weld
		/// </summary>
		public List<string> ConnectedPartIds { get; set; }

		/// <summary>
		/// Start of the weld
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Point3D Start { get; set; }

		/// <summary>
		/// End of the weld
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Point3D End { get; set; }
	}

	/// <summary>
	/// Provides data of the single plate
	/// </summary>
	public class PlateData
	{
		/// <summary>
		/// Plate unique ID
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of the plate
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Thickness of the plate
		/// </summary>
		public double Thickness { get; set; }

		/// <summary>
		/// Name of the material
		/// </summary>
		public string Material { get; set; }

		/// <summary>
		/// Outline points
		/// </summary>
		public List<IdeaRS.OpenModel.Geometry2D.Point2D> OutlinePoints { get; set; }

		/// <summary>
		/// Origin of the plate LCS
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Point3D Origin { get; set; }

		/// <summary>
		/// LCS - Axis X
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisX { get; set; }

		/// <summary>
		/// LCS - Axis Y
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisY { get; set; }

		/// <summary>
		/// LCS - Axis Z
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D AxisZ { get; set; }

		/// <summary>
		/// Geometry of the plate in svg format
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// Get or set the identification in the original model
		/// In the case of the imported connection from another application
		/// </summary>
		public string OriginalModelId { get; set; }
	}

	/// <summary>
	/// Provides data of the cut beam
	/// </summary>
	public class CutData
	{
		/// <summary>
		/// 3DPlane Point
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Point3D PlanePoint { get; set; }

		/// <summary>
		/// 3DPlane Normal AxisX
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D PlaneNormalX { get; set; }

		/// <summary>
		/// 3DPlane Normal AxisY
		/// </summary>
		public IdeaRS.OpenModel.Geometry3D.Vector3D PlaneNormalY { get; set; }
	}
}