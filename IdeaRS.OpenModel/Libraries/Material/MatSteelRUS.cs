using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaRS.OpenModel.Material
{
    /// <summary>
	/// Material steel RUS
	/// </summary>
	[OpenModelClass("CI.StructModel.Libraries.Material.RUS.MatSteelRUS,CI.Material", "CI.StructModel.Libraries.Material.IMatSteel,CI.BasicTypes", typeof(MatSteel))]
    public class MatSteelRUS : MatSteel
	{
        /// <summary>
		/// Yield strength
		/// </summary>
		public double fy { get; set; }

        /// <summary>
        /// Ultimate strength
        /// </summary>
        public double fu { get; set; }
    }
}
