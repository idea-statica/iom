﻿namespace IdeaRS.OpenModel.Material
{
	/// <summary>
	/// Material reinforcement HKG
	/// </summary>
	[OpenModelClass("CI.StructModel.Libraries.Material.American.MatReinforcementHKG,CI.Material", "CI.StructModel.Libraries.Material.IMatReinforcement,CI.BasicTypes", typeof(MatReinforcement))]
	public class MatReinforcementHKG : MatReinforcement
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MatReinforcementHKG()
		{
		}

		/// <summary>
		/// Characteristic strain of reinforcement
		/// </summary>
		public double Epssu { get; set; }

		/// <summary>
		/// Characteristic yield strength of reinforcement
		/// </summary>
		public double Fy { get; set; }
	}
}
