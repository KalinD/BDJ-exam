using System;
using System.ComponentModel.DataAnnotations;

namespace BDJ.Data
{
    public class Line
    {
        [Key]
        public Guid Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Guid TrainId { get; set; }
        public Train Train { get; set; }
    }
}
