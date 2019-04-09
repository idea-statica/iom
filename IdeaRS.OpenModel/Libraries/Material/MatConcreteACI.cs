﻿namespace IdeaRS.OpenModel.Material
{
	/// <summary>
	/// Material concrete ACI
	/// </summary>
	[OpenModelClass("CI.StructModel.Libraries.Material.American.MatConcreteACI,CI.Material", "CI.StructModel.Libraries.Material.IMatConcrete,CI.BasicTypes", typeof(MatConcrete))]
	public class MatConcreteACI : MatConcrete
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MatConcreteACI()
		{

		}

		/// <summary>
		/// Compressive strength of concrete
		/// </summary>
		public double Fcc { get; set; }

	}
}
