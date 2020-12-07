using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worker_Management.Models
{
    public class Supervisior
    {
        public int supervisiorID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string department { get; set; }

        
    }
}
