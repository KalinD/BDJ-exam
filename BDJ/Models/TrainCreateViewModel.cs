using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Models
{
    public class TrainCreateViewModel
    {
        [Display(Name = "Name")]
        public string Number { get; set; }
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
        [Display(Name = "Fast")]
        public bool IsFast { get; set; }
    }
}
