//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Brokers.DateTimes;
using Tarteeb.importer.Brokers.Loggings;
using Tarteeb.importer.Models.Clients;

namespace Tarteeb.importer.Services.Clients
{
    internal partial class ClientServices
    {
        public readonly StorageBroker storageBroker;
        public readonly LoggingBroker loggingBroker;
        public readonly DateTimeBroker dateTimeBroker;
        public ClientServices(StorageBroker storageBroker, LoggingBroker loggingBroker, DateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

         public Task<Client> AddClientAsync(Client client) =>
         TryCatch(() =>
         {
             ValidateClientOnAdd(client);

             return storageBroker.InsertClientAsync(client);
         });



    }
}