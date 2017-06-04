using System;

namespace CodErator.CustomException
{
	[Serializable]
    class NoDatabaseSelectedException : ApplicationException
    {
        public NoDatabaseSelectedException() { }

        public NoDatabaseSelectedException(string message)
            : base(message) { }

        public NoDatabaseSelectedException(string message, Exception exception)
            : base(message, exception) { }
    }
}
