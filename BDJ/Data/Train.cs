using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Data
{
    public class Train
    {
        [Key]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
    }
}
