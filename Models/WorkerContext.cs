using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Worker_Management.Models
{
    public class WorkerContext : DbContext
    {
        //Constructor for WorkerContext
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Supervisior> Supervisiors { get; set; }
    }
}
