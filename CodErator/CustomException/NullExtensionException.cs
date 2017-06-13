using System;

namespace CodErator.CustomException
{
	class NullExtensionException : ApplicationException
	{
		public NullExtensionException() { }

		public NullExtensionException(string message)
			: base(message) { }

		public NullExtensionException(string message, Exception exception)
			: base(message, exception) { }
	}
}
