//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;

namespace Tarteeb.importer.Services.Clients
{
    internal partial class ClientServices
    {
        private delegate Task<Client> ReturningClientFunction();

        private Task<Client> TryCatch(ReturningClientFunction returningClientFunction)
        {
            try
            {
                return returningClientFunction();
            }
            catch (NullClientException nullClientException)
            {
                ClientValidationException clientValidationException =
                        new ClientValidationException(nullClientException);

                throw clientValidationException;
            }
            catch (InvalidClientException invalidClientException)
            {
                ClientValidationException clientValidationException =
                       new ClientValidationException(invalidClientException);

                throw clientValidationException;
            }
        }
    }
}
