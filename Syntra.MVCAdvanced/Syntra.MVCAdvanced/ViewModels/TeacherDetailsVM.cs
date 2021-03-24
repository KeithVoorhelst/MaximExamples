using Syntra.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.ViewModels
{
    public class TeacherDetailsVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Range(100, 2000)]
        public double Salary { get; set; }
    }
}
