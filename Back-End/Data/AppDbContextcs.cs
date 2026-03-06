using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sa3dny.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data
{
    public class AppDbContextcs : IdentityDbContext
    {

        public AppDbContextcs(DbContextOptions<AppDbContextcs> options) : base(options)
        {

        }
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Provider> Providers { get; set; }
    }
}
