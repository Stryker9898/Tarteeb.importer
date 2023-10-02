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

                var dateTimeOffset = new DateTimeOffset(
                new DateTime(2020, 3, 16, 7, 0, 0),
                new TimeSpan(-7, 0, 0));

                Client client = new Client
                {
                    BirthDate = dateTimeOffset,
                    Email = "testuhumail.ru",
                    Firstname = "",
                    Lastname = "test",
                    Id = Guid.NewGuid(),
                    GroupId = Guid.NewGuid(),
                    PhoneNumber = "12234",
                };
                var clientServices = new ClientServices(storageBroker, loggingBroker, dateTimeBroker);
                Client persistedClient = await clientServices.AddClientAsync(client);
                Console.WriteLine(persistedClient.Id);


            }

            catch (ClientValidationException clientValidationException)
            {
                if(clientValidationException.InnerException.Message == "Client is Invalid fix the errors and try again")
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

                else
                {
                    Console.WriteLine(clientValidationException.Message);
                }
               
            }

            catch (ClientDependecyValidationException clientDependecyValidationException)
            {
                Console.WriteLine(clientDependecyValidationException.Message);
            }

            catch(ClientDependencyException clientDependencyException)
            {
                Console.WriteLine(clientDependencyException.Message);
            }

            catch(ClientServiceException clientServiceException)
            {
                Console.WriteLine(clientServiceException.Message);
            }
        }
    }
}
