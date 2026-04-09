using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sa3dny.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Home_Service> Home_Services { get; set; }
        public DbSet<Edu_Service> Edu_Services { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Provider_Service> Provider_Services { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Provider_Service>()
                .HasKey(ps => new { ps.provider_id, ps.service_id });

            modelBuilder.Entity<Requests>()
                .Property(r => r.Total_Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Service>()
                .Property(s => s.Min_price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Provider_Service>()
                .HasOne(ps => ps.Provider)
                .WithMany(p => p.provider_Services)
                .HasForeignKey(ps => ps.provider_id);

            modelBuilder.Entity<Provider_Service>()
                .HasOne(ps => ps.Service)
                .WithMany(s => s.provider_services)
                .HasForeignKey(ps => ps.service_id);



            modelBuilder.Entity<Review>()
                 .HasKey(r => r.Review_Id);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.customer)
                .WithMany(c => c.reviews)
                .HasForeignKey(r => r.Customer_Id)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Review>()
                .HasOne(r => r.provider)
                .WithMany(p => p.reviews)
                .HasForeignKey(r => r.Provider_Id)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Review>()
                .HasOne(r => r.requests)
                .WithMany(req => req.reviews)
                .HasForeignKey(r => r.Request_Id)
                .OnDelete(DeleteBehavior.Restrict); 

        }

    }
}
