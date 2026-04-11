using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sa3dny.Data.Models;

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
        public DbSet<Location> Locations { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

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
                .HasForeignKey(ps => ps.provider_id)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Provider_Service>()
                .HasOne(ps => ps.Service)
                .WithMany(s => s.provider_services)
                .HasForeignKey(ps => ps.service_id)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Review>().HasKey(r => r.Review_Id);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.customer)
                .WithMany(c => c.reviews)
                .HasForeignKey(r => r.Customer_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.provider)
                .WithMany(p => p.reviews)
                .HasForeignKey(r => r.Provider_Id)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Review>()
                .HasOne(r => r.requests)
                .WithMany(req => req.reviews)
                .HasForeignKey(r => r.Request_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Location)
                .WithMany(l => l.Customers)
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Governorate)
                .WithMany(g => g.Customers)
                .HasForeignKey(c => c.GovernorateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Provider>()
                .HasOne(p => p.Location)
                .WithMany()
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Provider>()
                .HasOne(p => p.Governorate)
                .WithMany(g => g.Providers)
                .HasForeignKey(p => p.GovernorateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Provider>()
                .HasOne(p => p.ServiceCategory)
                .WithMany(sc => sc.Providers)
                .HasForeignKey(p => p.ServiceCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Provider>()
                .HasOne(p => p.Service)
                .WithMany()
                .HasForeignKey(p => p.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            
            modelBuilder.Entity<ServiceCategory>().HasData(
                new ServiceCategory { Id_Category = 1, Name_Category = "Home Services" },
                new ServiceCategory { Id_Category = 2, Name_Category = "Educational Services" },
                new ServiceCategory { Id_Category = 3, Name_Category = "Healthcare Services" }
            );

            
            modelBuilder.Entity<Service>().HasData(
                new Service { service_id = 1, service_name = "Cleaning", Description = "Home cleaning service", Min_price = 0 },
                new Service { service_id = 2, service_name = "Plumbing", Description = "Plumbing service", Min_price = 0 },
                new Service { service_id = 3, service_name = "Electricity", Description = "Electrical service", Min_price = 0 },
                new Service { service_id = 4, service_name = "Carpentry", Description = "Carpentry service", Min_price = 0 },
                new Service { service_id = 5, service_name = "Word / Report", Description = "Word and report writing", Min_price = 0 },
                new Service { service_id = 6, service_name = "Presentation", Description = "Presentation design", Min_price = 0 },
                new Service { service_id = 7, service_name = "Excel", Description = "Excel sheets service", Min_price = 0 },
                new Service { service_id = 8, service_name = "CV Creation", Description = "CV writing service", Min_price = 0 },
                new Service { service_id = 9, service_name = "Home Nursing", Description = "Nursing at home", Min_price = 0 },
                new Service { service_id = 10, service_name = "Doctor Visit", Description = "Doctor home visit", Min_price = 0 },
                new Service { service_id = 11, service_name = "Injection Service", Description = "Injection at home", Min_price = 0 },
                new Service { service_id = 12, service_name = "Follow-up", Description = "Medical follow-up", Min_price = 0 }
            );

           
            modelBuilder.Entity<Governorate>().HasData(
                new Governorate { Id_Governorate = 1, Name_Governorate = "Cairo" },
                new Governorate { Id_Governorate = 2, Name_Governorate = "Giza" },
                new Governorate { Id_Governorate = 3, Name_Governorate = "Alexandria" },
                new Governorate { Id_Governorate = 4, Name_Governorate = "Assiut" },
                new Governorate { Id_Governorate = 5, Name_Governorate = "Aswan" },
                new Governorate { Id_Governorate = 6, Name_Governorate = "Luxor" },
                new Governorate { Id_Governorate = 7, Name_Governorate = "Sohag" },
                new Governorate { Id_Governorate = 8, Name_Governorate = "Qena" },
                new Governorate { Id_Governorate = 9, Name_Governorate = "Minya" },
                new Governorate { Id_Governorate = 10, Name_Governorate = "Beni Suef" },
                new Governorate { Id_Governorate = 11, Name_Governorate = "Fayoum" },
                new Governorate { Id_Governorate = 12, Name_Governorate = "Dakahlia" },
                new Governorate { Id_Governorate = 13, Name_Governorate = "Sharqia" },
                new Governorate { Id_Governorate = 14, Name_Governorate = "Gharbia" },
                new Governorate { Id_Governorate = 15, Name_Governorate = "Monufia" },
                new Governorate { Id_Governorate = 16, Name_Governorate = "Qalyubia" },
                new Governorate { Id_Governorate = 17, Name_Governorate = "Kafr El Sheikh" },
                new Governorate { Id_Governorate = 18, Name_Governorate = "Beheira" },
                new Governorate { Id_Governorate = 19, Name_Governorate = "Damietta" },
                new Governorate { Id_Governorate = 20, Name_Governorate = "Port Said" },
                new Governorate { Id_Governorate = 21, Name_Governorate = "Ismailia" },
                new Governorate { Id_Governorate = 22, Name_Governorate = "Suez" },
                new Governorate { Id_Governorate = 23, Name_Governorate = "North Sinai" },
                new Governorate { Id_Governorate = 24, Name_Governorate = "South Sinai" },
                new Governorate { Id_Governorate = 25, Name_Governorate = "Red Sea" },
                new Governorate { Id_Governorate = 26, Name_Governorate = "New Valley" },
                new Governorate { Id_Governorate = 27, Name_Governorate = "Matruh" }
            );

            
            modelBuilder.Entity<Location>().HasData(
                new Location { Id_Location = 1, Name_Location = "Ferial" },
                new Location { Id_Location = 2, Name_Location = "Mousna3 Sayed" },
                new Location { Id_Location = 3, Name_Location = "Governorate Street" },
                new Location { Id_Location = 4, Name_Location = "Libraries" },
                new Location { Id_Location = 5, Name_Location = "Asmaa Allah Square" },
                new Location { Id_Location = 6, Name_Location = "Station" },
                new Location { Id_Location = 7, Name_Location = "Fateh" },
                new Location { Id_Location = 8, Name_Location = "Hamraa" }
            );
        }
    }
}