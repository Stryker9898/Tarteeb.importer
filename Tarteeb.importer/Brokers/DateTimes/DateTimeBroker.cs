//=================================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===============================

namespace Tarteeb.importer.Brokers.DateTimes
{
    public class DateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTime() =>
             DateTimeOffset.UtcNow;
    }
}
