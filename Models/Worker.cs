using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worker_Management.Models
{
    public class Worker
    {
        public int workerID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime hired_date { get; set; }

        public Supervisior Supervisior { get; set; }
        [ForeignKey("Supervisior")]
        public int SupervisiorFK { get; set; }
    }
}
