//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Brokers.Loggings;
using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;

namespace Tarteeb.importer.Services.Clients
{
    internal class ClientServices
    {
        public readonly StorageBroker storageBroker;
        public readonly LoggingBroker loggingBroker;
        public ClientServices(StorageBroker storageBroker,LoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            try
            {
               return await storageBroker.InsertClientAsync(client);
            }
            catch (Exception)
            {
                var clientException = new NullClientException();
                this.loggingBroker.LogError(clientException);
                throw clientException;
            }
             
        }
    }
}
