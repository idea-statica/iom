using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IdeaRS.OpenModel.Detail.Loading
{
	/// <summary>
	/// Load base object
	/// </summary>
	[XmlInclude(typeof(LineLoad))]
	public abstract class LoadBase : OpenObject
	{
		/// <summary>
		/// Element Id
		/// </summary>
		[DataMember]
		public System.Int32 Id { get; set; }
	}
}
