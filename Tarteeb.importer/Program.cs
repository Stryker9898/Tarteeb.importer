//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================
using System.Collections;
using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Brokers.DateTimes;
using Tarteeb.importer.Brokers.Loggings;
using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;
using Tarteeb.importer.Models.Exceptions.Categories;
using Tarteeb.importer.Services.Clients;
using Xeptions;

namespace Tarteeb.importer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var storageBroker = new StorageBroker();
                var loggingBroker = new LoggingBroker();
                var dateTimeBroker = new DateTimeBroker();



                for (int i = 0; i < 200; i++)
                {
                    var clientServices = new ClientServices(storageBroker, loggingBroker, dateTimeBroker);
                    Client client =  clientServices.CreateRandomClient();
                    Client persistedClient = await clientServices.AddClientAsync(client);
                    Console.WriteLine(persistedClient.Id);
                }


            }

            catch (ClientValidationException clientValidationException)
                when (clientValidationException.InnerException is InvalidClientException)
            {

                Xeption innerException = (Xeption)clientValidationException.InnerException;
                Console.WriteLine(innerException.Message);
                foreach (DictionaryEntry item in innerException.Data)
                {
                    string errorSummary = ((List<string>)item.Value)
                        .Select((string value) => value)
                        .Aggregate((string current, string next) => current + ", " + next);
                    Console.WriteLine(item.Key + " - " + errorSummary);
                }

            }

            catch (ClientValidationException clientValidationException)
              when (clientValidationException.InnerException is NullClientException)
            {
                Console.WriteLine(clientValidationException.Message);
            }

            catch (ClientDependecyValidationException clientDependecyValidationException)
            {
                Console.WriteLine(clientDependecyValidationException.Message);
            }

            catch (ClientDependencyException clientDependencyException)
            {
                Console.WriteLine(clientDependencyException.Message);
            }

            catch (ClientServiceException clientServiceException)
            {
                Console.WriteLine(clientServiceException.Message);
            }
        }
    }
}
