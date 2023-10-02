//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================
using Tarteeb.importer.Models.Exceptions;

namespace Tarteeb.importer.Brokers.Loggings
{
    internal class LoggingBroker
    {
        public void LogError(Exception exception) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
        }

    }
}
