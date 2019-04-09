using System;

namespace IdeaRS.OpenModel
{
	public interface ISimpleElement
	{
		void InitDefault();
	}
	public abstract class SimpleElementBase
	{
		public abstract Type GetStructClsType();
		public abstract void CopyToSM(object destination);
	}
}
