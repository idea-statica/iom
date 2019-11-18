using System.Xml.Serialization;

namespace IdeaRS.OpenModel.Material
{
	/// <summary>
	/// Material steel base class
	/// </summary>
	[XmlInclude(typeof(MatSteelEc2))]
	[XmlInclude(typeof(MatSteelAISC))]
	[XmlInclude(typeof(MatSteelCISC))]
	[XmlInclude(typeof(MatSteelAUS))]
	[XmlInclude(typeof(MatSteelRUS))]
	[XmlInclude(typeof(MatSteelCHN))]

	public abstract class MatSteel : Material
	{
	}
}