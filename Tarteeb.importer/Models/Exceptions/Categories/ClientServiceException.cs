//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.importer.Models.Exceptions.Categories
{
    internal class ClientServiceException : Xeption
    {
        public ClientServiceException(Xeption innerException)
            : base("Client service error occured contact support", innerException)
        { }
    }
}
