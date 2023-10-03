//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

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
