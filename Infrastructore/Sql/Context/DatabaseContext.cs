using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructore.Sql.Context
{
   public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _iConfiguration;
        public DatabaseContext(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_iConfiguration["connection"]);
        }
    }
}
