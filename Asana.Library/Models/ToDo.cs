using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana.Library.Models
{
    public class ToDo
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDone { get; set; }
        public int? Priority { get; set; }

        
    }
}