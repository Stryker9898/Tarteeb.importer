//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.importer.Models.Exceptions
{
    internal class LockedClientException : Xeption
    {
        public LockedClientException(Exception innerException)
            : base("Client is locked please try again later. ", innerException)
        { }
    }
}
