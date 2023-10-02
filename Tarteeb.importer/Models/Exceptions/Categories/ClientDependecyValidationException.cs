using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Tarteeb.importer.Models.Exceptions.Categories
{
    internal class ClientDependecyValidationException : Xeption
    {
        public ClientDependecyValidationException(Xeption innerException)
            : base(message: "Client dependency validation error occured fix the errors and try again",
                  innerException)
        {  }
    }
}
