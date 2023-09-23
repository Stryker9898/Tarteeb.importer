﻿//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Brockers.Storages;
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
                using (var storageBroker = new StorageBroker())
                {
                    Client client = null;

                    var clientServices = new ClientServices(storageBroker);
                    Client persistedClient = await clientServices.AddClientAsync(client);
                    Console.WriteLine(persistedClient.Id);

                }
            } 
            catch (NullClientException exception) 
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
