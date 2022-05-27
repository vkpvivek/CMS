using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class cusDBContext :DbContext
    {
        public cusDBContext(DbContextOptions<cusDBContext> options) : base(options) 
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
