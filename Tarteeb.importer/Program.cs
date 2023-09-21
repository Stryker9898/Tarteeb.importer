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
   
            using (var storageBroker = new StorageBroker())
            {
                IQueryable<Client> clients = storageBroker.SelectAllClients();

                foreach (var client in clients)
                {
                    Console.WriteLine(client.Id + " "+ client.Firstname + " " + client.Lastname);
                }
            }


        }
    }
}
