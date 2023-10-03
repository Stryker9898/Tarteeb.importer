//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.importer.Models.Exceptions.Categories
{
    internal class ClientDependencyException : Xeption
    {
        public ClientDependencyException(Xeption innerException)
            : base("Client dependency error occured, contact support. ", innerException)
        { }
    }
}
