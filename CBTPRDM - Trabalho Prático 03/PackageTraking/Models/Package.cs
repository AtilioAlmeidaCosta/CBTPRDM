/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using System;
using System.Collections.ObjectModel;

namespace PackageTraking.Models
{
    public class Package
    {
        public string Id { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ShippedDate { get; set; }
        public DateTime ExpectedDelivery { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public ObservableCollection<TrackingEvent> Events { get; set; } = new();

        public string ShippedDateString => ShippedDate == default ? "-" : ShippedDate.ToString("g");
        public string ExpectedDeliveryString => ExpectedDelivery == default ? "-" : ExpectedDelivery.ToString("g");
    }
}