using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkPatterns.DataContext.Models;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasData(
            new List<Location>
            {
                new() { Id = 1, Name = "General" },
                new() { Id = 2, Name = "Fantasy" },
                new() { Id = 3, Name = "Horror" },
                new() { Id = 4, Name = "Sci/Fi" },
                new() { Id = 5, Name = "Western" }
            }
        );
    }
}