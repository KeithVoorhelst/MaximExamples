using Syntra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.ViewModels
{
    public class CourseDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
