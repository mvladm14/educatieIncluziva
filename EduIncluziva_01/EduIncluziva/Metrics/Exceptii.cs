using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduIncluziva.Metrics
{
    public class Exceptii
    {
    }

    public class InvalidUserException : Exception
    {
        public override string Message
        {
            get
            {
                return "Username invalid!";
            }
        }
    }
}