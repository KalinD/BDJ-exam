using System;

namespace BDJ.Models
{
    public class LineIndexViewModel
    {
        public Guid LineId { get; set; }
        public string TrainNumber { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set;}
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Date { get; set; }
    }
}
