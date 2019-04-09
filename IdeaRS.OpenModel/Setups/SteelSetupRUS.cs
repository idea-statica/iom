using System;

namespace IdeaRS.OpenModel
{
	/// <summary>
	/// Steel setup RUS class
	/// </summary>
	public class SteelSetupRUS : SteelSetup
	{
		/// <summary>
		/// Safety factor Structural_Fi
		/// </summary>
		public double Structural_Fi { get; set; }

		/// <summary>
		/// Safety factor Bolt_Fib
		/// </summary>
		public double Bolt_Fib { get; set; }

		/// <summary>
		/// Safety factor preloaded bolt
		/// </summary>
		public double Bolt_Fip { get; set; }

		/// <summary>
		/// Safety factor Weld_Fiw
		/// </summary>
		public double Weld_Fiw { get; set; }

		/// <summary>
		/// Safety factor Anchor_Fiar
		/// </summary>
		public double Anchor_Fiar { get; set; }

		/// <summary>
		/// Concrete bearing factor
		/// </summary>
		public double CrtBearing { get; set; }

	}
}
