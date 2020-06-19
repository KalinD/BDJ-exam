using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Models
{
    public class TrainIndexViewModel
    {
        public Guid TrainId { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public bool IsFast { get; set; }
    }
}
