using BDJ.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDJ.Models
{
    public class LineEditViewModel
    {
        public Guid LineId { get; set; }
        [Display(Name = "From")]
        public string Departure { get; set; }
        [Display(Name = "To")]
        public string Destination { get; set; }
        [Display(Name = "Departure Times")]
        [DisplayFormat(DataFormatString = "hh:mm")]
        public DateTime DepartureTime { get; set; }
        [Display(Name = "Arrival Time")]
        [DisplayFormat(DataFormatString = "hh:m")]
        public DateTime ArrivalTime { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime Date { get; set; }
        public Guid TrainId { get; set; }
        public List<Train> Trains { get; set; }
    }
}
