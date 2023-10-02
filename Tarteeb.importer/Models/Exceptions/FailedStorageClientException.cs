//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.importer.Models.Exceptions
{
    internal class FailedStorageClientException : Xeption
    {
        public FailedStorageClientException(Exception innerException)
            : base("Failed storage error occured, contact support. ", innerException)
        { }
    }
}
