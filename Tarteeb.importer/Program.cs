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
            //var client = new Client();
            //client.Id = Guid.NewGuid();
            //client.Email = "ShamshodAliyev.com";
            //client.Firstname = "Asliddinbek";
            //client.Lastname = "Jurayev";
            //client.BirthDate = DateTime.Now;
            //client.PhoneNumber = "1234567890";


            using (var storageBroker = new StorageBroker())
            {
                Client persistentClient = await storageBroker.SelectClientByIdAsync(new Guid("7B0DFB69-537B-4253-A644-364F241A8DD6"));
                Console.WriteLine(persistentClient.Firstname);
            }


        }
    }
}