using ZooApi.Models;

namespace ZooApi.Data
{
    public static class DbSeeder
    {
        public static void Seed(DataContext db)
        {
            // Seed Animals if table empty
            if (!db.Animals.Any())
            {
                db.Animals.AddRange(
                    new Animal { Name = "Henri", Species = "Elephant", Count = 5, Gender = "Male", Health = "Healthy", Status = "Open", Latitude = 45.5, Longitude = -90.7, Feeding = "5:00 PM", Image = "/images/elephant.png" },
                    new Animal { Name = "Aurora", Species = "Tiger", Count = 8, Gender = "Female", Health = "Healthy", Status = "Open", Latitude = 44.5, Longitude = -91.2, Feeding = "8:00 PM", Image = "/images/tiger.png" },
                    new Animal { Name = "Cliff", Species = "Panda", Count = 4, Gender = "Male", Health = "Healthy", Status = "Open", Latitude = 43.5, Longitude = -89.6, Feeding = "12:00 PM", Image = "/images/panda.png" },
                    new Animal { Name = "Caesar", Species = "Monkey", Count = 7, Gender = "Male", Health = "Sick", Status = "Open", Latitude = 40.5, Longitude = -90.3, Feeding = "9:00 PM", Image = "/images/monkey.png" }
                );
            }

            // Seed ZooStatus
            if (!db.ZooStatuses.Any())
            {
                db.ZooStatuses.Add(new ZooStatus { Status = "Open" });
            }

            // Seed Visitors
            if (!db.Visitors.Any())
            {
                db.Visitors.Add(new Visitor { Count = 60 });
            }

            db.SaveChanges();
        }
    }
}
