﻿namespace IdeaRS.OpenModel.Detail
{
	/// <summary>
	/// Representation of rectangular element2D in IDEA StatiCa Detail
	/// </summary>
	[OpenModelClass(typeof(Wall))]
	public class WallRect : Wall
	{

		/// <summary>
		/// Coonstructor
		/// </summary>
		public WallRect()
		{
		}

		/// <summary>
		/// Width of wall
		/// </summary>
		public double Width { get; set; }

		/// <summary>
		/// Height of wall
		/// </summary>
		public double Height { get; set; }
	}
}
