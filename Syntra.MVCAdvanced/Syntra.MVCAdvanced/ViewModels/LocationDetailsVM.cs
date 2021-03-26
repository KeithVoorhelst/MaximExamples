using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.ViewModels
{
    public class LocationDetailsVM
    {
        public int Id { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string StreetNumber{ get; set; }
        [Required]
        public string City { get; set; }
    }
}
