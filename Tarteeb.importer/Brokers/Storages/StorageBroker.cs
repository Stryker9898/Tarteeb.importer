//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Tarteeb.importer.Models.Clients;

namespace Tarteeb.importer.Brockers.Storages
{
    internal class StorageBroker : EFxceptionsContext
    {
        public DbSet<Client> Clients { get; set; }
        public StorageBroker() => 
            this.Database.EnsureCreated();

        public async Task<Client> InsertClientAsync(Client client)
        {
            await this.Clients.AddAsync(client);
            await this.SaveChangesAsync();
            return client;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source = ..\\..\\..\\ Tarteeb.db";
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(connectionString);
        }

        public async Task<Client> SelectClientByIdAsync(Guid id)
        {
            return await this.Clients.FindAsync(id);
        }
    }
}
