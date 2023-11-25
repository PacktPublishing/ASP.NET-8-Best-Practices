using EntityFrameworkThemePark.DataContext.Models;
using EntityFrameworkThemePark.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace EntityFrameworkThemePark.DataContext.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Location");

        builder.Property(e => e.Id).ValueGeneratedNever();

        var records = JsonConvert.DeserializeObject<Location[]>(
            SeedResource.LocationRecords);
        if (records != null)
        {
            builder.HasData(records);
        }
    }
}