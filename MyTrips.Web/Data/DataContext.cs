using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MyTrips.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrips.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserEntities> Users { get; set; }
    }
}
