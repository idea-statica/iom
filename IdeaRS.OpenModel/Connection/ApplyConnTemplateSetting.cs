namespace IdeaRS.OpenModel.Connection
{
	/// <summary>
	/// Defaults which are used for applying template
	/// </summary>
	public class ApplyConnTemplateSetting
	{
		/// <summary>
		/// ID of the bolt assembly which will be used as default (it must exists in the project)
		/// </summary>
		public int DefaultBoltAssemblyID { get; set; }

		/// <summary>
		/// ID of the cross section for cleats which will be used as default (it must exists in the project)
		/// </summary>
		public int DefaultCleatCrossSectionID { get; set; }

		/// <summary>
		/// ID of the material concrete which will be used as default (it must exists in the project)
		/// </summary>
		public int DefaultConcreteMaterialID { get; set; }

		/// <summary>
		/// ID of the cross-section for stiffening members concrete which will be used as default (it must exists in the project)
		/// </summary>

		public int DefaultStiffMemberCrossSectionID { get; set; }
	}
}
