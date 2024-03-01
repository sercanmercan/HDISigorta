using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Exceptions
{
    public class RequiredAreaException : Exception
    {
        public RequiredAreaException(string? message) : base(message)
        {
        }
    }
}
