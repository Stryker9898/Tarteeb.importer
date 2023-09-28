using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Tarteeb.importer.Models.Exceptions
{
    internal class ClientValidationException : Xeption
    {
        public ClientValidationException(Xeption innerException)
            : base("Client validation error occured Fix the errors and try again", 
                  innerException)
        { }
    }
}
