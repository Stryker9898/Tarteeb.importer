//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using Tarteeb.importer.Brockers.Storages;
using Tarteeb.importer.Brokers.Loggings;
using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;

namespace Tarteeb.importer.Services.Clients
{
    internal class ClientServices
    {
        public readonly StorageBroker storageBroker;
        public readonly LoggingBroker loggingBroker;
        public ClientServices(StorageBroker storageBroker, LoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        private dynamic isInvalid(Guid id) => new 
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic isInvalid(string text) => new 
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic isInvalidEmail(string email) => new
        {
            Condition = !Regex.IsMatch(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"),
            Message = "Text is required"
        };

        public async Task<Client> AddClientAsync(Client client)
        {
            try
            {
                Validate(
                    (isInvalid(client.Id), nameof(client.Id)),
                    (isInvalid(client.Firstname), nameof(client.Firstname)),
                    (isInvalidEmail(client.Email), nameof(client.Email))
                    );

               return await storageBroker.InsertClientAsync(client);
            }
            catch (ArgumentNullException)
            {
                var clientException = new NullClientException();
                this.loggingBroker.LogError(clientException);
                throw clientException;
            }
             
        }

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidClientException = new InvalidClientException();
            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidClientException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidClientException.ThrowIfContainsErrors();
        }
    }
}