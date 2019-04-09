﻿using IdeaRS.OpenModel.Geometry2D;

namespace IdeaRS.OpenModel.Material
{

	/// <summary>
	/// Material steel AISC
	/// </summary>
	[OpenModelClass("CI.StructModel.Libraries.Material.AUS.MatSteelAUS,CI.Material", "CI.StructModel.Libraries.Material.IMatSteel,CI.BasicTypes", typeof(MatSteel))]
  public class MatSteelAUS : MatSteel
	{
		/// <summary>
		/// Yield strength for nominal thickness of the element &lt;= 40mm - f<sub>y</sub>
		/// </summary>
		public double fy { get; set; }

		/// <summary>
		/// Ultimate strength  for nominal thickness of the element &lt;= 40mm - f<sub>u</sub>
		/// </summary>
		public double fu { get; set; }

		///// <summary>
		///// Yield strength for nominal thickness of the element &gt; 40mm and &lt;= 100mm - f<sub>y,(&gt;40)</sub>
		///// </summary>
		//public double fy40 { get; set; }

		///// <summary>
		///// Ultimate strength for nominal thickness of the element &gt; 40mm and &lt;= 100mm - f<sub>u,(&gt;40)</sub>
		///// </summary>
		//public double fu40 { get; set; }

	}
}