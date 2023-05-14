using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ThemePark.DataContext.Models;
using ThemePark.SeedData;

namespace ThemePark.DataContext.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property<int>(e => e.Id).ValueGeneratedNever();

        var records = JsonConvert.DeserializeObject<Location[]>(
            SeedResource.LocationRecords);
        if (records != null)
        {
            builder.HasData(records);
        }
    }
}