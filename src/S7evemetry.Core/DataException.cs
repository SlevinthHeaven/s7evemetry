using System;
namespace S7evemetry.Core
{
	[Serializable]
	public class DataException : Exception
	{
		public DataException() { }
		public DataException(string message) : base(message) { }
		public DataException(string message, Exception inner) : base(message, inner) { }
		protected DataException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
