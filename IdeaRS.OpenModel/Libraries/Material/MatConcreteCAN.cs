namespace IdeaRS.OpenModel.Material
{
	/// <summary>
	/// Material concrete CAN
	/// </summary>
	[OpenModelClass("CI.StructModel.Libraries.Material.Canadian.MatConcreteCAN,CI.Material", "CI.StructModel.Libraries.Material.IMatConcrete,CI.BasicTypes", typeof(MatConcrete))]
	public class MatConcreteCAN : MatConcrete
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MatConcreteCAN()
		{

		}

		/// <summary>
		/// Compressive strength of concrete
		/// </summary>
		public double Fcc { get; set; }
	}
}
