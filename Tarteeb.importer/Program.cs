//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Models.Clients;

namespace Tarteeb.importer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var client = new Client();
            client.Id = Guid.NewGuid();
            client.Email = "dilshodbekkhamroev98@gmail.com";
            client.Firstname = "Dilshodbek";
            client.Lastname = "Khamroev";
            client.BirthDate = DateTime.Now;
            client.PhoneNumber = "1234567890";


            using (var storageBroker = new StorageBroker())
            {
                Client persistentClient = await storageBroker.InsertClientAsync(client);
                Console.WriteLine(persistentClient);
            }


        }
    }
}