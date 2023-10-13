using DonateMedicine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Data
{
    public class HealthcareDbContext : DbContext
    {
        public HealthcareDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
        
        public DbSet<Donation> Donations { get; set; }

        public DbSet<Request> Requests { get; set; }
    }
}
