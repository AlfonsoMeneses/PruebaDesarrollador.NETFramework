using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() { }

        public BusinessException(string message) : base(message) { }
    }
}
