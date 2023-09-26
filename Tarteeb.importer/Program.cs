//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Brokers.Loggings;
using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;
using Tarteeb.importer.Services.Clients;

namespace Tarteeb.importer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var storageBroker = new StorageBroker();
                Client client = new Client
                {
                    BirthDate = DateTime.Now,
                    Email = "testuhu@mail.ru",
                    Firstname = "Jasur",
                    Lastname = "test",
                    Id = Guid.NewGuid(),
                    GroupId = Guid.NewGuid(),
                    PhoneNumber = "12234",

                };
                var loggingBroker = new LoggingBroker();
                var clientServices = new ClientServices(storageBroker, loggingBroker);
                Client persistedClient = await clientServices.AddClientAsync(client);
                Console.WriteLine(persistedClient.Id);


            }
            catch (NullClientException exception)
            {
                Console.WriteLine(exception.Message);
            }

            catch(InvalidClientException exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}
