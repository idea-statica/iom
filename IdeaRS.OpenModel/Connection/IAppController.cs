using System;
using System.ServiceModel;

namespace IdeaRS.OpenModel.Connection
{
	/// <summary>
	/// Enables controlling of the application IdeaConnection
	/// </summary>
	[ServiceContract]
	public interface IAppController
	{
		/// <summary>
		/// Opens the application Idea Connection and waits till this application is closed
		/// </summary>
		/// <param name="iom">The input stream which includes IdeaOpenModel (in xml format)</param>
		/// <param name="results">The input stream which includes OpenModelResult (in xml format)</param>
		/// <param name="existingConProj">The input stream which includes Idea Connection project (binary data)</param>
		/// <param name="requiredTemplate">The input stream which includes Idea Connection remplate (CONTEMP file)</param>
		/// <param name="importSettings">Connection import settings</param>
		[OperationContract]
		void OpenIdeaConnection(byte[] iom,
			byte[] results,
			byte[] existingConProj,
			byte[] requiredTemplate,
			byte[] importSettings);

		/// <summary>
		///
		/// </summary>
		[OperationContract]
		void OpenIdeaConnectionService();

		/// <summary>
		///
		/// </summary>
		/// <param name="connectionId"></param>
		/// <returns></returns>
		[OperationContract]
		string GetConnectionData(Guid connectionId);

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		byte[] GetIdeaConnectionProject();
	}
}