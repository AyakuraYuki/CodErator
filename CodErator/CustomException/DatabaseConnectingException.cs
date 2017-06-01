using System;

namespace CodErator.CustomException
{
    class DatabaseConnectingException : ApplicationException
    {
        public DatabaseConnectingException() { }

        public DatabaseConnectingException(string message)
            : base(message) { }

        public DatabaseConnectingException(string message, Exception exception)
            : base(message, exception) { }
    }
}
