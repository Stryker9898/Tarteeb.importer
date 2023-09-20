﻿//=================================
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source = ..\\..\\..\\ Tarteeb.db";

            optionsBuilder.UseSqlite(connectionString);
        }
    }
}