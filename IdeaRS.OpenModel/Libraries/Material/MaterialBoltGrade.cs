﻿using System;

namespace IdeaRS.OpenModel.Material
{
	/// <summary>
	/// Material bolt grade
	/// </summary>
	[OpenModelClass("CI.StructModel.Libraries.Material.MaterialBoltGrade,CI.Material", "CI.StructModel.Libraries.Material.IMatBoltGrade,CI.BasicTypes", typeof(Material))]
	public class MaterialBoltGrade : Material
	{
		#region Properties


		/// <summary>
		/// Ultimate tensile strength
		/// </summary>
#pragma warning disable IDE1006 // Naming Styles
		public double fub
#pragma warning restore IDE1006 // Naming Styles
		{
			get; set;
		}

		/// <summary>
		/// Yield strength
		/// </summary>
#pragma warning disable IDE1006 // Naming Styles
		public double fyb
#pragma warning restore IDE1006 // Naming Styles
		{
			get; set;
		}

		/// <summary>
		/// Elongation after fracture - for 20% elongation use value 0.2
		/// </summary>
		public double Elongation
		{
			get; set;
		}

		/// <summary>
		/// Design code
		/// </summary>
		public CountryCode Code
		{
			get; set;
		}

		/// <summary>
		/// Name fo the bolt grade in MPRL database
		/// </summary>
		public Guid MprlElementID
		{
			get; set;
		}

		/// <summary>
		/// Unique ID of MPRL database table where the bolt grade was taken from.
		/// </summary>
		public Guid MprlTableID
		{
			get;set;
		}

		#endregion
	}
}
