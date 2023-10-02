//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.importer.Models.Exceptions
{
    internal class AlreadyExistsClientException : Xeption
    {
        public AlreadyExistsClientException(Exception exception)
             : base("Client is already exists", exception)
        
        { }
    }
}
