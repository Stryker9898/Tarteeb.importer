//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

using System.Text.RegularExpressions;
using Tarteeb.importer.Models.Clients;
using Tarteeb.importer.Models.Exceptions;

namespace Tarteeb.importer.Services.Clients
{
    internal partial class ClientServices
    {
        private void ValidateClientOnAdd(Client client)
        {
            ValidateClientNotNull(client);

            Validate(
               (Rule: IsInvalid(client.Id), Parameter: nameof(client.Id)),
               (Rule: IsInvalid(client.Email), Parameter: nameof(client.Email)),
               (Rule: IsInvalidEmail(client.Email), Parameter: nameof(client.Email)),
               (Rule: IsInvalid(client.Firstname), Parameter: nameof(client.Firstname)),
               (Rule: IsAgeLess12(client.BirthDate), Parameter: nameof(client.BirthDate))
               );
        }

        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic IsInvalidEmail(string email) => new
        {
            Condition = !Regex.IsMatch(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"),
            Message = "Text is required"
        };

        private dynamic IsAgeLess12(DateTimeOffset birthDate) => new
        {
            Condition = IsAgeLessThan12(birthDate),
            Message = "age is less than 12"
        };

        private bool IsAgeLessThan12(DateTimeOffset birthDate)
        {
            DateTimeOffset dateTimeOffsetNow = dateTimeBroker.GetCurrentDateTime();
            TimeSpan differenceDay = dateTimeOffsetNow - birthDate;
            return (differenceDay.TotalDays / 365) < 12;
        }

        private void ValidateClientNotNull(Client client)
        {
            if (client is null)
            {
                var clientException = new NullClientException();
                this.loggingBroker.LogError(new NullClientException());
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
