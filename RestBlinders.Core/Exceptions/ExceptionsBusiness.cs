using System;
using System.Collections.Generic;
using System.Text;

namespace RestBlinders.Core.Exceptions
{
    public class ExceptionsBusiness : Exception
    {
        public ExceptionsBusiness() { }
        public ExceptionsBusiness(string message) : base(message) { }
    }
}
