//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Brokers.DateTimes;
using Tarteeb.importer.Brokers.Loggings;
using Tarteeb.importer.Models.Clients;
using Tynamix.ObjectFiller;

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

        internal Client CreateRandomClient()
        {
            return CreateClientFiller().Create();
        }

        private Filler<Client> CreateClientFiller()
        {
            var filler = new Filler<Client>();
            DateTimeOffset dates = GetRandomDateTime();
            string email = GetRandomEmail();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            filler.Setup()
                .OnProperty(client => client.Email).Use(email);

            return filler;
        }

        private string GetRandomEmail() => 
            new MnemonicString().GetValue() + "@gmail.com";

        private DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
    }
}