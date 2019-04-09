using System.Xml.Serialization;

namespace IdeaRS.OpenModel.Material
{
	/// <summary>
	/// Material concrete base class
	/// </summary>
	[XmlInclude(typeof(MatConcreteEc2))]
	[XmlInclude(typeof(MatConcreteSIA))]
	[XmlInclude(typeof(MatConcreteACI))]
	[XmlInclude(typeof(MatConcreteCAN))]
	[XmlInclude(typeof(MatConcreteRUS))]
	public abstract class MatConcrete : Material
	{
	}
}