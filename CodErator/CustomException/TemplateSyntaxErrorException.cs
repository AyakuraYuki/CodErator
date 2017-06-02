using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodErator.CustomException
{
    class TemplateSyntaxErrorException : ApplicationException
    {
        public TemplateSyntaxErrorException() { }

        public TemplateSyntaxErrorException(string message)
            : base(message) { }

        public TemplateSyntaxErrorException(string message, Exception exception)
            : base(message, exception) { }
    }
}
