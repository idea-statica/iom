using System.Xml.Serialization;

namespace IdeaRS.OpenModel
{
	/// <summary>
	/// Open object base class
	/// POS - class can not be abstract -it causes problems with serialization
	/// </summary>
	[XmlInclude(typeof(IdeaRS.OpenModel.CrossSection.CrossSectionParameter))]
	[System.Runtime.Serialization.DataContract]
	public class OpenObject
	{
	}
}