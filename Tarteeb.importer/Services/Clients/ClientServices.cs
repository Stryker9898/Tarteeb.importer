//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;

namespace Tarteeb.importer.Services.Clients
{
    internal class ClientServices
    {
        public readonly StorageBroker storageBroker;

        public ClientServices(StorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            if(client is null)
            {
                throw new NullClientException();
            }
            return await storageBroker.InsertClientAsync(client); 
        }
    }
}
