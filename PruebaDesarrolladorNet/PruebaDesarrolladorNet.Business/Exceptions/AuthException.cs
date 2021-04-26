using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Exceptions
{
    public class AuthException:Exception
    {
        public AuthException()
        {

        }

        public AuthException(string message) : base(message)
        {

        }
    }
}
