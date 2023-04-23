using Microsoft.EntityFrameworkCore;

namespace ShelterApi.Models;

public class ShelterApiContext : DbContext
{
  public DbSet<Animal> Animals { get; set; }

  public ShelterApiContext(DbContextOptions<ShelterApiContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Animal>()
      .HasData(
        new Animal { AnimalId = 1, Name = "Taki", Species = "Dog", Age = 16, Weight = 53, Sex = "Male" },
        new Animal { AnimalId = 2, Name = "Ginger", Species = "Dog", Age = 43, Weight = 70, Sex = "Female" },
        new Animal { AnimalId = 3, Name = "Rollie", Species = "Rabbit", Age = 36, Weight = 6, Sex = "Male" },
        new Animal { AnimalId = 4, Name = "Gunther", Species = "Dog", Age = 26, Weight = 74, Sex = "Male" },
        new Animal { AnimalId = 5, Name = "Raina", Species = "Cat", Age = 60, Weight = 7, Sex = "Female" },
        new Animal { AnimalId = 6, Name = "Butterscotch", Species = "Cat", Age = 9, Weight = 11, Sex = "Male" }
      );
  }
}