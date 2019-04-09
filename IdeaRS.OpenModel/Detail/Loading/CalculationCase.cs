﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IdeaRS.OpenModel.Detail.Loading
{
	/// <summary>
	/// load case/combination data
	/// </summary>
	[XmlInclude(typeof(LoadCase))]
	public abstract class CalculationCase : OpenElementId
	{
		/// <summary>
		/// constructor
		/// </summary>
		public CalculationCase()
		{
			IsActive = true;
		}

		/// <summary>
		/// Gets or set the name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// active load case/combination
		/// </summary>
		public bool IsActive { get; set; }
	}
}
