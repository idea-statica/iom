using System;
using System.Xml.Serialization;

namespace IdeaRS.OpenModel
{
	/// <summary>
	/// ISteelSetup
	/// </summary>
	[XmlInclude(typeof(SteelSetupECEN))]
	[XmlInclude(typeof(SteelSetupAISC))]
	[XmlInclude(typeof(SteelSetupCISC))]
	[XmlInclude(typeof(SteelSetupAUS))]
	public abstract class SteelSetup
	{
	}
}
