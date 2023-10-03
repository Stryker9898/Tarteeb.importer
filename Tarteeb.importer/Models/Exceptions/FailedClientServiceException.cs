//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.importer.Models.Exceptions
{
    internal class FailedClientServiceException : Xeption
    {
        public FailedClientServiceException(Exception innerException)
           : base("Failed client service error occured conatact support. ", innerException)
        { }
    }
}
