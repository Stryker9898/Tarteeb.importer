//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.importer.Models.Exceptions
{
    public class InvalidClientException : Xeption
    {
        public InvalidClientException()
            : base(message: "Client is Invalid fix the errors and try again")
        { }
    }
}
