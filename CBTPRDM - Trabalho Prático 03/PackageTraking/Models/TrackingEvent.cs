/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using System;

namespace PackageTraking.Models
{
    public class TrackingEvent
    {
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string DateString => Date == default ? "-" : Date.ToString("g");
    }
}