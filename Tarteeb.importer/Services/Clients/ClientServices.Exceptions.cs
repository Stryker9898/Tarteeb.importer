//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using EFxceptions.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;
using Tarteeb.importer.Models.Exceptions.Categories;
using Xeptions;

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
                throw CreateValidationException(nullClientException);
            }
            catch (InvalidClientException invalidClientException)
            {
                throw CreateValidationException(invalidClientException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsClientException =
                    new AlreadyExistsClientException(duplicateKeyException);

                throw ClreateDependecyValidationException(alreadyExistsClientException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedClientException =
                    new LockedClientException(dbUpdateConcurrencyException);

                throw CreateDependencyException(lockedClientException);
            }

            catch (DbUpdateException dbUpdateException)
            {
                var failedStorageClientException =
                    new FailedStorageClientException(dbUpdateException);

                throw CreateDependencyException(failedStorageClientException);
            }
            catch (Exception exception)
            {
                var failedClientServiceException =
                    new FailedClientServiceException(exception);

                throw CreateClientServiceException(failedClientServiceException);
            }
        }



        private ClientValidationException CreateValidationException(Xeption xeption)
        {
            ClientValidationException clientValidationException =
                       new ClientValidationException(xeption);
            return clientValidationException;
        }

        private ClientDependecyValidationException ClreateDependecyValidationException(Xeption exception)
        {
            var clientDependecyValidationException = new ClientDependecyValidationException(exception);
            return clientDependecyValidationException;
        }

        private ClientDependencyException CreateDependencyException(Xeption lockedClientException)
        {
            var clientDependencyException =
                new ClientDependencyException(lockedClientException);

            throw clientDependencyException;
        }

        private ClientServiceException CreateClientServiceException(Xeption failedClientServiceException)
        {
            ClientServiceException clientServiceException =
                new ClientServiceException(failedClientServiceException);

            return clientServiceException;
        }
    }
}
