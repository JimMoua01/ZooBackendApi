using Microsoft.EntityFrameworkCore;
using ZooApi.Models;

namespace ZooApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<ZooStatus> ZooStatuses { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Henri", Species = "Elephant", Count = 5, Gender = "Male", Health = "Healthy", Status = "Open", Latitude = 45.5, Longitude = -90.7, Feeding = "5:00 PM", Image = "/images/elephant.png" },
                new Animal { Id = 2, Name = "Aurora", Species = "Tiger", Count = 8, Gender = "Female", Health = "Healthy", Status = "Open", Latitude = 44.5, Longitude = -91.2, Feeding = "8:00 PM", Image = "/images/tiger.png" },
                new Animal { Id = 3, Name = "Cliff", Species = "Panda", Count = 4, Gender = "Male", Health = "Healthy", Status = "Open", Latitude = 43.5, Longitude = -89.6, Feeding = "12:00 PM", Image = "/images/panda.png" },
                new Animal { Id = 4, Name = "Caesar", Species = "Monkey", Count = 7, Gender = "Male", Health = "Sick", Status = "Open", Latitude = 40.5, Longitude = -90.3, Feeding = "9:00 PM", Image = "/images/monkey.png" });

            modelBuilder.Entity<ZooStatus>().HasData(
                new ZooStatus { Id = 1, Status = "Open" });

            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { Id = 1, Count = 60 });
        }
    }
}
